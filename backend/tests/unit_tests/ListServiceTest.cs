using NUnit.Framework;
using Moq;
using ToDoListAPI.Services;
using ToDoListAPI.Interfaces;
using AutoMapper;
using ToDoListAPI.DTOs;
using ToDoListAPI.Models;
using FluentAssertions;
using System;
using System.Collections.Generic;

[TestFixture]
public class ListServiceTest
{
    private IListService _listService;
    private Mock<IListRepository> _listRepository;
    private Mock<IMapper> _mapper;
    private List sampleList;
    private ListDto sampleListDto;
    private DateTime fixedTime;

    [SetUp]
    public void Setup()
    {
        _listRepository = new Mock<IListRepository>();
        _mapper = new Mock<IMapper>();
        _listService = new ListService(_listRepository.Object, _mapper.Object);

        fixedTime = new DateTime(2023, 1, 1, 12, 0, 0, DateTimeKind.Utc);

        // Initialize shared list data
        sampleList = new List
        {
            ListId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Title = "Sample List",
            Description = "This is a sample list for demonstration purposes.",
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CreatedAt = fixedTime,
            UpdatedAt = null,
            Tasks = new List<ToDoListAPI.Models.Task>()
        };

        sampleListDto = new ListDto
        {
            ListId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Title = "Sample List",
            Description = "This is a sample list for demonstration purposes.",
            UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            CreatedAt = fixedTime,
            UpdatedAt = null,
            Tasks = new List<TaskDto>()
        };
    }

    [Test]
    public void TestGetAllLists()
    {
        // Arrange
        var userId = Guid.Parse("22222222-2222-2222-2222-222222222222");
        var lists = new List<List> { sampleList };
        var listsDto = new List<ListDto> { sampleListDto };
        _listRepository.Setup(repo => repo.GetAllListsAsync(userId)).Returns(System.Threading.Tasks.Task.FromResult((IEnumerable<List>)lists));
        _mapper.Setup(mapper => mapper.Map<IEnumerable<ListDto>>(It.IsAny<IEnumerable<List>>())).Returns(listsDto);

        // Act
        var result = _listService.GetAllListsAsync(userId).Result;

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<List<ListDto>>();
        result.Should().HaveCount(lists.Count);
        result.Should().BeEquivalentTo(listsDto, options => options.ComparingByMembers<ListDto>());
        result.Should().ContainItemsAssignableTo<ListDto>();
        result.Should().BeEquivalentTo(listsDto, options => options.ComparingByMembers<ListDto>().WithStrictOrdering());

        _listRepository.Verify(repo => repo.GetAllListsAsync(userId), Times.Once);
        _mapper.Verify(mapper => mapper.Map<IEnumerable<ListDto>>(lists), Times.Once);
    }

    [Test]
    public void TestGetList()
    {
        // Arrange
        var listId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var userId = Guid.Parse("22222222-2222-2222-2222-222222222222");
        _listRepository.Setup(repo => repo.GetListAsync(listId, userId)).Returns(System.Threading.Tasks.Task.FromResult(sampleList));
        _mapper.Setup(mapper => mapper.Map<ListDto>(It.IsAny<List>())).Returns(sampleListDto);

        // Act
        var result = _listService.GetListAsync(listId, userId).Result;

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ListDto>();
        result.Should().BeEquivalentTo(sampleListDto, options => options.ComparingByMembers<ListDto>());

        _listRepository.Verify(repo => repo.GetListAsync(listId, userId), Times.Once);
        _mapper.Verify(mapper => mapper.Map<ListDto>(sampleList), Times.Once);
    }

    [Test]
    public void TestCreateList()
    {
        // Arrange
        var userId = Guid.Parse("22222222-2222-2222-2222-222222222222");
        _listRepository.Setup(repo => repo.CreateListAsync(It.IsAny<List>(), userId)).Returns(System.Threading.Tasks.Task.FromResult(sampleList));
        _mapper.Setup(mapper => mapper.Map<List>(It.IsAny<ListDto>())).Returns(sampleList);
        _mapper.Setup(mapper => mapper.Map<ListDto>(It.IsAny<List>())).Returns(sampleListDto);

        // Act
        var result = _listService.CreateListAsync(sampleListDto, userId).Result;

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ListDto>();
        result.Should().BeEquivalentTo(sampleListDto, options => options.ComparingByMembers<ListDto>());

        _listRepository.Verify(repo => repo.CreateListAsync(It.IsAny<List>(), userId), Times.Once);
        _mapper.Verify(mapper => mapper.Map<List>(sampleListDto), Times.Once);
        _mapper.Verify(mapper => mapper.Map<ListDto>(sampleList), Times.Once);
    }

    [Test]
    public void TestUpdateList()
    {
        // Arrange
        var listId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var userId = Guid.Parse("22222222-2222-2222-2222-222222222222");
        var updatedList = new List
        {
            ListId = listId,
            Title = "Updated List",
            Description = "This is an updated sample list for demonstration purposes.",
            UserId = userId,
            CreatedAt = fixedTime,
            UpdatedAt = fixedTime.AddHours(1),
            Tasks = new List<ToDoListAPI.Models.Task>()
        };

        var updatedListDto = new ListDto
        {
            ListId = updatedList.ListId,
            Title = updatedList.Title,
            Description = updatedList.Description,
            UserId = updatedList.UserId,
            CreatedAt = updatedList.CreatedAt,
            UpdatedAt = updatedList.UpdatedAt,
            Tasks = new List<TaskDto>()
        };

        _listRepository.Setup(repo => repo.GetListAsync(listId, userId)).Returns(System.Threading.Tasks.Task.FromResult(sampleList));
        _listRepository.Setup(repo => repo.UpdateListAsync(listId, It.IsAny<List>(), userId)).Returns(System.Threading.Tasks.Task.FromResult(updatedList));
        _mapper.Setup(mapper => mapper.Map<ListDto>(It.IsAny<List>())).Returns(updatedListDto);
        // Act
        var result = _listService.UpdateListAsync(listId, updatedListDto, userId).Result;

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ListDto>();
        result.Should().BeEquivalentTo(updatedListDto, options => options.ComparingByMembers<ListDto>());

        _listRepository.Verify(repo => repo.GetListAsync(listId, userId), Times.Once);
        _listRepository.Verify(repo => repo.UpdateListAsync(listId, It.IsAny<List>(), userId), Times.Once);
        _mapper.Verify(mapper => mapper.Map<ListDto>(updatedList), Times.Once);
    }

    [Test]
    public void TestDeleteList()
    {
        // Arrange
        var listId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var userId = Guid.Parse("22222222-2222-2222-2222-222222222222");
        _listRepository.Setup(repo => repo.DeleteListAsync(listId, userId)).Returns(System.Threading.Tasks.Task.FromResult(true));
        // Act
        var result = _listService.DeleteListAsync(listId, userId).Result;
        // Assert
        result.Should().BeTrue();
        _listRepository.Verify(repo => repo.DeleteListAsync(listId, userId), Times.Once);
    }
}

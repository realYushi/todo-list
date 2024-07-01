using NUnit.Framework;
using Moq;
using ToDoListAPI.Services;
using ToDoListAPI.Interfaces;
using AutoMapper;
using ToDoListAPI.DTOs;
using ToDoListAPI.Models;
using FluentAssertions;

[TestFixture]
public class ListServiceTest
{
    private IListService _listService;
    private Mock<IListRepository> _listRepository;
    private Mock<IMapper> _mapper;
    private List sampleList;
    private ListDto sampleListDto;
    [SetUp]
    public void Setup()
    {
        _listRepository = new Mock<IListRepository>();
        _mapper = new Mock<IMapper>();
        _listService = new ListService(_listRepository.Object, _mapper.Object);
        // Initialize shared list data

        sampleList = new List
        {
            Id = "1",
            Name = "Sample List",
            Description = "This is a sample list for demonstration purposes.",
            UserId = "user123"
        };

        sampleListDto = new ListDto
        {
            Id = "1",
            Name = "Sample List",
            Description = "This is a sample list for demonstration purposes.",
            UserId = "user123"
        };
    }

    [Test]
    public void TestGetAllLists()
    {
        // Arrange
        var lists = new List<List> { sampleList };
        var listsDto = new List<ListDto> { sampleListDto };
        _listRepository.Setup(repo => repo.GetAllLists()).Returns(lists);
        _mapper.Setup(mapper => mapper.Map<IEnumerable<ListDto>>(It.IsAny<IEnumerable<List>>())).Returns(listsDto);
        // Act
        var result = _listService.GetAllLists();
        // Assert
        result.Should().NotBeNull(); // Ensures the result is not null
        result.Should().BeOfType<List<ListDto>>(); // Checks that result is of type List<ListDto>
        result.Should().HaveCount(lists.Count); // Checks the count of returned lists
        result.Should().BeEquivalentTo(listsDto, options => options.ComparingByMembers<ListDto>()); // Deep compare the actual result to expected DTOs
        result.Should().ContainItemsAssignableTo<ListDto>(); // Ensures all items are of type ListDto
        result.Should().BeEquivalentTo(listsDto, options => options.ComparingByMembers<ListDto>().WithStrictOrdering()); // Ensures the items are in the same order as expected

        _listRepository.Verify(repo => repo.GetAllLists(), Times.Once); // Verify that the GetAllLists method was called exactly once
        _mapper.Verify(mapper => mapper.Map<IEnumerable<ListDto>>(lists), Times.Once); // Verify that the mapping was called exactly once with the specific input


    }

    [Test]
    public void TestGetList()
    {
        // Arrange
        var listId = "1";
        _listRepository.Setup(repo => repo.GetList(listId)).Returns(sampleList);
        _mapper.Setup(mapper => mapper.Map<ListDto>(It.IsAny<List>())).Returns(sampleListDto);
        // Act
        var result = _listService.GetList(listId);
        // Assert
        result.Should().NotBeNull(); // Ensures the result is not null
        result.Should().BeOfType<ListDto>(); // Checks that result is of type ListDto
        result.Should().BeEquivalentTo(sampleListDto, options => options.ComparingByMembers<ListDto>()); // Deep compare the actual result to expected DTO

        _listRepository.Verify(repo => repo.GetList(listId), Times.Once); // Verify that the GetList method was called exactly once
        _mapper.Verify(mapper => mapper.Map<ListDto>(sampleList), Times.Once); // Verify that the mapping was called exactly once with the specific input
    }

    [Test]
    public void TestCreateList()
    {
        // Arrange
        _listRepository.Setup(repo => repo.CreateList(It.IsAny<List>())).Returns(sampleList);
        _mapper.Setup(mapper => mapper.Map<List>(It.IsAny<ListDto>())).Returns(sampleList);
        _mapper.Setup(mapper => mapper.Map<ListDto>(It.IsAny<List>())).Returns(sampleListDto);
        // Act
        var result = _listService.CreateList(sampleListDto);
        // Assert
        result.Should().NotBeNull(); // Ensures the result is not null
        result.Should().BeOfType<List>(); // Checks that result is of type List
        result.Should().BeEquivalentTo(sampleList, options => options.ComparingByMembers<List>()); // Deep compare the actual result to expected DTO

        _listRepository.Verify(repo => repo.CreateList(It.IsAny<List>()), Times.Once); // Verify that the CreateList method was called exactly once
        _mapper.Verify(mapper => mapper.Map<List>(sampleListDto), Times.Once); // Verify that the mapping to List was called exactly once with the specific input
    }

    [Test]
    public void TestUpdateList()
    {
        // Arrange
        var listId = "1";
        var updatedList = new List
        {
            Id = "1",
            Name = "Updated List",
            Description = "This is a updated sample list for demonstration purposes.",
            UserId = "user124"
        };

        var updatedListDto = new ListDto
        {
            Id = updatedList.Id,
            Name = updatedList.Name,
            Description = updatedList.Description,
            UserId = updatedList.UserId
        };

        _listRepository.Setup(repo => repo.UpdateList(listId, It.IsAny<List>())).Returns(updatedList);
        _mapper.Setup(mapper => mapper.Map<List>(It.IsAny<ListDto>())).Returns(updatedList);
        _mapper.Setup(mapper => mapper.Map<ListDto>(It.IsAny<List>())).Returns(updatedListDto);

        // Act
        var result = _listService.UpdateList(listId, updatedListDto);

        // Assert
        result.Should().NotBeNull(); // Ensures the result is not null
        result.Should().BeOfType<ListDto>(); // Checks that result is of type ListDto
        result.Should().BeEquivalentTo(updatedListDto, options => options.ComparingByMembers<ListDto>()); // Deep compare the actual result to expected DTO

        _listRepository.Verify(repo => repo.UpdateList(listId, It.IsAny<List>()), Times.Once); // Verify that the UpdateList method was called exactly once
        _mapper.Verify(mapper => mapper.Map<List>(updatedListDto), Times.Once); // Verify that the mapping to List was called exactly once with the specific input
        _mapper.Verify(mapper => mapper.Map<ListDto>(updatedList), Times.Once); // Verify that the mapping to ListDto was called exactly once with the specific input
    }


    [Test]
    public void TestDeleteList()
    {
        // Arrange
        var listId = "1";
        _listRepository.Setup(repo => repo.DeleteList(listId));

        // Act
        _listService.DeleteList(listId);

        // Assert

        _listRepository.Verify(repo => repo.DeleteList(listId), Times.Once); // Verify that the DeleteList method was called exactly once
    }
}

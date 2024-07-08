using NUnit.Framework;
using ToDoListAPI.Models;
using ToDoListAPI.Data.Repositories;
using FluentAssertions;
using System;
using System.Collections.Generic;
using List = ToDoListAPI.Models.List;

[TestFixture]
public class testListRepository : RepositoryTestBase
{
    private ListRepository listRepository;
    private Guid userId1 = Guid.NewGuid();
    private Guid userId2 = Guid.NewGuid();
    private Guid listId1 = Guid.NewGuid();
    private Guid listId2 = Guid.NewGuid();

    [SetUp]
    public void SetUp()
    {
        base.SetUp();
        context.Database.EnsureCreated();
        listRepository = new ListRepository(context);
        SeedData();
    }

    private void SeedData()
    {
        context.Users.AddRange(
            new User { UserId = userId1, Username = "User1", Email = "user1@example.com", Password = "password1" },
            new User { UserId = userId2, Username = "User2", Email = "user2@example.com", Password = "password2" }
        );
        context.SaveChanges();

        context.Lists.AddRange(
            new List
            {
                ListId = listId1,
                Title = "Home Tasks",
                Description = "Tasks to do at home.",
                UserId = userId1
            },
            new List
            {
                ListId = listId2,
                Title = "Work Tasks",
                Description = "Tasks to do at work.",
                UserId = userId1
            }
        );
        context.SaveChanges();
    }

    [Test]
    public void TestGetAllLists()
    {
        // Arrange
        var expect = new List<List>()
        {
            new List
            {
            ListId = listId1,
                Title = "Home Tasks",
                Description = "Tasks to do at home.",
            UserId = userId1
            },
            new List
            {
                ListId = listId2,
                Title = "Work Tasks",
                Description = "Tasks to do at work.",
                UserId = userId1
    }
        };
        // Act
        var result = listRepository.GetAllListsAsync(userId1).Result;
        // Assert
        result.Should().BeEquivalentTo(expect, options => options
            .Excluding(x => x.CreatedAt)
            .Excluding(x => x.UpdatedAt)
            .Excluding(x => x.User));
    }

    [Test]
    public void TestGetList()
    {
        // Arrange
        var expect = new List
        {
            ListId = listId1,
            Title = "Home Tasks",
            Description = "Tasks to do at home.",
            UserId = userId1
        };

        // Act
        var result = listRepository.GetListAsync(listId1, userId1).Result;

        // Assert
        result.Should().BeEquivalentTo(expect, options => options
            .Excluding(x => x.CreatedAt)
            .Excluding(x => x.UpdatedAt)
            .Excluding(x => x.User));
    }

    [Test]
    public void TestCreateList()
    {
        // Arrange
        var list = new List
        {
            Title = "School Tasks",
            Description = "Tasks to do at school.",
            UserId = userId1
        };

        // Act
        var result = listRepository.CreateListAsync(list, userId1).Result;

        // Assert
        result.ListId.Should().NotBe(Guid.Empty);
        result.Title.Should().Be(list.Title);
        result.Description.Should().Be(list.Description);
        result.UserId.Should().Be(userId1);

        var createdList = listRepository.GetListAsync(result.ListId, userId1).Result;
        createdList.Should().NotBeNull();
    }

    [Test]
    public void TestUpdateList()
    {
        // Arrange
        var updatedList = new List
        {
            ListId = listId1,
            Title = "New Home Tasks",
            Description = "New Tasks to do at home.",
            UserId = userId1
        };

        // Act
        var result = listRepository.UpdateListAsync(listId1, updatedList, userId1).Result;

        // Assert
        result.Should().BeEquivalentTo(updatedList, options => options
            .Excluding(x => x.CreatedAt)
            .Excluding(x => x.UpdatedAt)
            .Excluding(x => x.User));
    }

    [Test]
    public void TestDeleteList()
    {
        // Act
        var deleteResult = listRepository.DeleteListAsync(listId1, userId1).Result;
        var getResult = listRepository.GetListAsync(listId1, userId1).Result;

        // Assert
        deleteResult.Should().BeTrue();
        getResult.Should().BeNull();
    }
}

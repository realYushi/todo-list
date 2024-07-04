using NUnit.Framework;
using ToDoListAPI.Models;
using ToDoListAPI.Data.Repositories;
using ToDoListAPI.Models.Generated;
using FluentAssertions;
[TestFixture]
public class testListRepository : RepositoryTestBase
{
    private ListRepository listRepository;
    [SetUp]
    public void SetUp()
    {
        listRepository = new ListRepository(context);
    }
    [Test]
    public void TestGetAllLists()
    {
        // Arrange
        var expect = new List<ToDoListAPI.Models.List>()
        {
            new ToDoListAPI.Models.List
                {
                    Id = "list1",
                    Name = "Home Tasks",
                    Description = "Tasks to do at home.",
                    UserId = "user1"
                },
            new ToDoListAPI.Models.List
                {
                    Id = "list2",
                    Name = "Work Tasks",
                    Description = "Tasks to do at work.",
                    UserId = "user1"
                }
        };

        // Act
        var result = listRepository.GetAllLists();
        // Assert
        result.Should().BeEquivalentTo(expect);
    }

    [Test]
    public void TestGetList()
    {
        // Arrange
        var expect = new ToDoListAPI.Models.List
        {
            Id = "list1",
            Name = "Home Tasks",
            Description = "Tasks to do at home.",
            UserId = "user1"
        };
        var id = "list1";
        // Act
        var result = listRepository.GetList(id);
        // Assert
        result.Should().BeEquivalentTo(expect);
    }

    [Test]
    public void TestCreateList()
    {
        // Arrange
        var list = new ToDoListAPI.Models.List
        {
            Name = "School Tasks",
            Description = "Tasks to do at school.",
            UserId = "user2"
        };
        // Act
        var result = listRepository.CreateList(list);
        context.SaveChanges();


        // Assert
        result.Id.Should().NotBeNull("ID should be assigned after creation.");
        result.Name.Should().Be("School Tasks");
        result.Description.Should().Be("Tasks to do at school.");
        result.UserId.Should().Be("user2");
        var createdList = listRepository.GetList(list.Id);
        createdList.Should().NotBeNull();
    }

    [Test]
    public void TestUpdateList()
    {
        // Arrange
        var list = new ToDoListAPI.Models.List
        {
            Id = "list1",
            Name = "New Home Tasks",
            Description = "New Tasks to do at home.",
            UserId = "user1"
        };
        // Act
        listRepository.UpdateList(list.Id, list);
        context.SaveChanges();
        var result = listRepository.GetList(list.Id);
        // Assert
        result.Should().BeEquivalentTo(list);

    }

    [Test]
    public void TestDeleteList()
    {
        // Arrange
        var id = "list1";


        // Act
        listRepository.DeleteList(id);
        context.SaveChanges();
        var result = listRepository.GetList(id);
        // Assert
        result.Should().BeNull();
    }
}
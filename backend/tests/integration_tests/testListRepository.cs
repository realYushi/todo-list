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
        var userId = "user1"; // Added user ID for filtering
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
        var result = listRepository.GetAllLists(userId); // Updated to include userId
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
        var userId = "user1"; // Added user ID for filtering
        // Act
        var result = listRepository.GetList(id, userId); // Updated to include userId
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
        var userId = "user2"; // Added user ID for creation
        // Act
        var result = listRepository.CreateList(list, userId); // Updated to include userId
        context.SaveChanges();


        // Assert
        result.Id.Should().NotBeNull("ID should be assigned after creation.");
        result.Name.Should().Be(list.Name);
        result.Description.Should().Be(list.Description);
        result.UserId.Should().Be(list.UserId);
        var createdList = listRepository.GetList(result.Id, userId); // Updated to include userId
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
        var userId = "user1"; // Added user ID for updating
        // Act
        listRepository.UpdateList(list.Id, list, userId); // Updated to include userId
        var result = listRepository.GetList(list.Id, userId); // Updated to include userId
        // Assert
        result.Should().BeEquivalentTo(list);

    }

    [Test]
    public void TestDeleteList()
    {
        // Arrange
        var id = "list1";
        var userId = "user1"; // Added user ID for deletion
        // Act
        listRepository.DeleteList(id, userId); // Updated to include userId
        var result = listRepository.GetList(id, userId); // Updated to include userId
        // Assert
        result.Should().BeNull();
    }
}
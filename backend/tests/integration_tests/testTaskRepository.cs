using NUnit.Framework;
using ToDoListAPI.Models;
using ToDoListAPI.Data.Repositories;
using FluentAssertions;

[TestFixture]
public class testTaskRepository : RepositoryTestBase
{
    private TaskRepository taskRepository;

    [SetUp]
    public void SetUp()
    {
        taskRepository = new TaskRepository(context);
    }

    [Test]
    public void TestGetAllTasks()
    {
        // Arrange
        var expect = new List<ToDoListAPI.Models.Task>()
        {
            new ToDoListAPI.Models.Task
            {
                Id = "task1",
                Title = "Wash dishes",
                Description = "Wash all the dishes from dinner.",
                DueDate = new DateTime(2023, 12, 31),
                Status = ToDoListAPI.Models.Task.StatusEnum.PendingEnum,
                ListId = "list1",
                UserId = "user1"  // Ensure the UserId is set in the expected object
            },
            new ToDoListAPI.Models.Task
            {
                Id = "task2",
                Title = "Prepare presentation",
                Description = "Prepare the monthly performance presentation.",
                DueDate = new DateTime(2023, 12, 31),
                Status = ToDoListAPI.Models.Task.StatusEnum.InProgressEnum,
                ListId = "list2",
                UserId = "user1"  // Ensure the UserId is set in the expected object
            }
};

        // Act
        var result = taskRepository.GetAllTasks("user1");  // Corrected to pass only the userId

        // Assert
        result.Should().BeEquivalentTo(expect);
    }

    [Test]
    public void TestGetTask()
    {
        // Arrange
        var expect = new ToDoListAPI.Models.Task
        {
            Id = "task1",
            Title = "Wash dishes",
            Description = "Wash all the dishes from dinner.",
            DueDate = new DateTime(2023, 12, 31),
            Status = ToDoListAPI.Models.Task.StatusEnum.PendingEnum,
            ListId = "list1",
            UserId = "user1"  // Ensure the UserId is set in the expected object
        };
        var id = "task1";
        var userId = "user1";  // Corrected to include userId parameter

        // Act
        var result = taskRepository.GetTask(id, userId);  // Corrected to pass the userId parameter

        // Assert
        result.Should().BeEquivalentTo(expect);
    }

    [Test]
    public void TestCreateTask()
    {
        // Arrange
        var task = new ToDoListAPI.Models.Task
        {
            Title = "Clean room",
            Description = "Clean the entire room thoroughly.",
            DueDate = DateTime.Now.AddDays(2),
            Status = ToDoListAPI.Models.Task.StatusEnum.PendingEnum,
            ListId = "list1",
            UserId = "user1"  // Ensure the UserId is set in the task object
        };

        // Act
        var result = taskRepository.CreateTask(task, "user1");  // Corrected to pass the userId parameter
        context.SaveChanges();

        // Assert
        result.Id.Should().NotBeNull("ID should be assigned after creation.");
        result.Title.Should().Be("Clean room");
        result.Description.Should().Be("Clean the entire room thoroughly.");
        result.Status.Should().Be(ToDoListAPI.Models.Task.StatusEnum.PendingEnum);
        result.ListId.Should().Be("list1");
        var createdTask = taskRepository.GetTask(result.Id, "user1");  // Corrected to pass the userId parameter
        createdTask.Should().NotBeNull();
    }

    [Test]
    public void TestUpdateTask()
    {
        // Arrange
        var task = new ToDoListAPI.Models.Task
        {
            Id = "task1",
            Title = "Wash dishes quickly",
            Description = "Wash all the dishes from dinner quickly.",
            DueDate = DateTime.Now.AddDays(1),
            Status = ToDoListAPI.Models.Task.StatusEnum.InProgressEnum,
            ListId = "list1",
            UserId = "user1"  // Ensure the UserId is set in the task object
        };

        // Act
        taskRepository.UpdateTask(task.Id, task, "user1");  // Corrected to pass the userId parameter
        context.SaveChanges();
        var result = taskRepository.GetTask(task.Id, "user1");  // Corrected to pass the userId parameter

        // Assert
        result.Should().BeEquivalentTo(task);
    }

    [Test]
    public void TestDeleteTask()
    {
        // Arrange
        var id = "task1";
        var userId = "user1";  // Corrected to include userId parameter

        // Act
        taskRepository.DeleteTask(id, userId);  // Corrected to pass the userId parameter
        context.SaveChanges();
        var result = taskRepository.GetTask(id, userId);  // Corrected to pass the userId parameter

        // Assert
        result.Should().BeNull();
    }
}
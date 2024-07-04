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
                ListId = "list1"
            },
            new ToDoListAPI.Models.Task
            {
                Id = "task2",
                Title = "Prepare presentation",
                Description = "Prepare the monthly performance presentation.",
                DueDate = new DateTime(2023, 12, 31),
                Status = ToDoListAPI.Models.Task.StatusEnum.InProgressEnum,
                ListId = "list2"
            }
        };

        // Act
        var result = taskRepository.GetAllTasks();

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
            ListId = "list1"
        };
        var id = "task1";

        // Act
        var result = taskRepository.GetTask(id);

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
            ListId = "list1"
        };

        // Act
        var result = taskRepository.CreateTask(task);
        context.SaveChanges();

        // Assert
        result.Id.Should().NotBeNull("ID should be assigned after creation.");
        result.Title.Should().Be("Clean room");
        result.Description.Should().Be("Clean the entire room thoroughly.");
        result.Status.Should().Be(ToDoListAPI.Models.Task.StatusEnum.PendingEnum);
        result.ListId.Should().Be("list1");
        var createdTask = taskRepository.GetTask(task.Id);
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
            ListId = "list1"
        };

        // Act
        taskRepository.UpdateTask(task.Id, task);
        context.SaveChanges();
        var result = taskRepository.GetTask(task.Id);

        // Assert
        result.Should().BeEquivalentTo(task);
    }

    [Test]
    public void TestDeleteTask()
    {
        // Arrange
        var id = "task1";

        // Act
        taskRepository.DeleteTask(id);
        context.SaveChanges();
        var result = taskRepository.GetTask(id);

        // Assert
        result.Should().BeNull();
    }
}
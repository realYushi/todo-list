using NUnit.Framework;
using ToDoListAPI.Models;
using ToDoListAPI.Data.Repositories;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

[TestFixture]
public class TestTaskRepository : RepositoryTestBase
{
    private TaskRepository taskRepository;
    private Guid userId;
    private Guid listId;
    private List<ToDoListAPI.Models.Task> tasks;

    [SetUp]
    public void SetUp()
    {
        base.SetUp();
        taskRepository = new TaskRepository(context);
        SeedTestData();
    }

    private void SeedTestData()
    {
        var user = new User
        {
            UserId = Guid.NewGuid(),
            Username = "TestUser",
            Email = "test@example.com",
            Password = "TestPassword123!" // Added password
        };
        context.Users.Add(user);
        context.SaveChanges();
        userId = (Guid)user.UserId;

        var list = new ToDoListAPI.Models.List
        {
            ListId = Guid.NewGuid(),
            UserId = userId,
            Title = "Test List Title" // Added title
        };
        context.Lists.Add(list);
        context.SaveChanges();
        listId = list.ListId;

        tasks = new List<ToDoListAPI.Models.Task>
        {
            new ToDoListAPI.Models.Task
            {
                TaskId = Guid.NewGuid(),
                Title = "Wash dishes",
                Description = "Wash all the dishes from dinner.",
                DueDate = new DateTime(2023, 12, 31),
            Status = ToDoListAPI.Models.Task.StatusEnum.Pending,
            ListId = listId,
            UserId = userId
            },
            new ToDoListAPI.Models.Task
            {
                TaskId = Guid.NewGuid(),
                Title = "Prepare presentation",
                Description = "Prepare the monthly performance presentation.",
                DueDate = new DateTime(2023, 12, 31),
            Status = ToDoListAPI.Models.Task.StatusEnum.InProgress,
            ListId = listId,
            UserId = userId
            }
        };

        context.Tasks.AddRange(tasks);
        context.SaveChanges();
    }

    [Test]
    public void TestGetAllTasks()
    {
        // Act
        var result = taskRepository.GetAllTasksAsync(userId).Result;
        // Assert
        result.Should().BeEquivalentTo(tasks, options => options
            .Excluding(x => x.List)
            .Excluding(x => x.User)
            .Excluding(x => x.RowVersion));
    }

    [Test]
    public void TestGetTask()
    {
        // Arrange
        var expectedTask = tasks.First();
        // Act
        var result = taskRepository.GetTaskAsync(expectedTask.TaskId.Value, userId).Result;
        // Assert
        result.Should().BeEquivalentTo(expectedTask, options => options
            .Excluding(x => x.List)
            .Excluding(x => x.User)
            .Excluding(x => x.RowVersion));
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
            Status = ToDoListAPI.Models.Task.StatusEnum.Pending,
            ListId = listId,
            UserId = userId
        };

        // Act
        var result = taskRepository.CreateTaskAsync(task, userId).Result;

        // Assert
        result.TaskId.Should().NotBeNull("ID should be assigned after creation.");
        result.Title.Should().Be("Clean room");
        result.Description.Should().Be("Clean the entire room thoroughly.");
        result.Status.Should().Be(ToDoListAPI.Models.Task.StatusEnum.Pending);
        result.ListId.Should().Be(listId);

        var createdTask = taskRepository.GetTaskAsync(result.TaskId.Value, userId).Result;
        createdTask.Should().NotBeNull();
    }

    [Test]
    public void TestUpdateTask()
    {
        // Arrange
        var taskToUpdate = tasks.First();
        var updatedTask = new ToDoListAPI.Models.Task
        {
            TaskId = taskToUpdate.TaskId,
            Title = "Wash dishes quickly",
            Description = "Wash all the dishes from dinner quickly.",
            DueDate = DateTime.Now.AddDays(1),
            Status = ToDoListAPI.Models.Task.StatusEnum.InProgress,
            ListId = listId,
            UserId = userId
        };

        // Act
        var result = taskRepository.UpdateTaskAsync(taskToUpdate.TaskId.Value, updatedTask, userId).Result;

        // Assert
        result.Should().BeEquivalentTo(updatedTask, options => options
            .Excluding(x => x.List)
            .Excluding(x => x.User)
            .Excluding(x => x.RowVersion));
    }

    [Test]
    public void TestDeleteTask()
    {
        // Arrange
        var taskToDelete = tasks.First();

        // Act
        var deleteResult = taskRepository.DeleteTaskAsync(taskToDelete.TaskId.Value, userId).Result;
        var getResult = taskRepository.GetTaskAsync(taskToDelete.TaskId.Value, userId).Result;

        // Assert
        deleteResult.Should().BeTrue();
        getResult.Should().BeNull();
    }


}
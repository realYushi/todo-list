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
public class TaskServiceTest
{
    private TaskService _taskService;
    private Mock<ITaskRepository> _taskRepository;
    private Mock<IMapper> _mapper;
    private ToDoListAPI.Models.Task _sampleTask;
    private TaskDto _sampleTaskDto;
    private Guid _userId;
    private Guid _listId;

    [SetUp]
    public void Setup()
    {
        _taskRepository = new Mock<ITaskRepository>();
        _mapper = new Mock<IMapper>();
        _taskService = new TaskService(_taskRepository.Object, _mapper.Object);

        // Initialize shared task data
        _userId = Guid.Parse("00000000-0000-0000-0000-000000000001");
        _listId = Guid.Parse("00000000-0000-0000-0000-000000000002");
        _sampleTask = new ToDoListAPI.Models.Task
        {
            TaskId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
            Title = "Sample Task",
            Description = "This is a sample task description",
            DueDate = new DateTime(2023, 7, 1, 12, 0, 0, DateTimeKind.Utc),
            Status = ToDoListAPI.Models.Task.StatusEnum.Pending,
            ListId = _listId,
            UserId = _userId,
            RowVersion = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 }
        };

        _sampleTaskDto = new TaskDto
        {
            TaskId = _sampleTask.TaskId,
            Title = _sampleTask.Title,
            Description = _sampleTask.Description,
            DueDate = _sampleTask.DueDate,
            Status = TaskDto.StatusEnum.Pending,
            ListId = _sampleTask.ListId,
            UserId = _sampleTask.UserId,
            RowVersion = _sampleTask.RowVersion
        };
    }

    [Test]
    public void TestGetAllTasks()
    {
        // Arrange
        var tasks = new List<ToDoListAPI.Models.Task> { _sampleTask };
        var tasksDto = new List<TaskDto> { _sampleTaskDto };
        _taskRepository.Setup(repo => repo.GetAllTasksAsync(_userId).Result).Returns(tasks);
        _mapper.Setup(mapper => mapper.Map<IEnumerable<TaskDto>>(It.IsAny<IEnumerable<ToDoListAPI.Models.Task>>())).Returns(tasksDto);

        // Act
        var result = _taskService.GetAllTasksAsync(_userId).Result;

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(tasksDto);
        _taskRepository.Verify(repo => repo.GetAllTasksAsync(_userId), Times.Once);
        _mapper.Verify(mapper => mapper.Map<IEnumerable<TaskDto>>(tasks), Times.Once);
    }

    [Test]
    public void TestGetTask()
    {
        // Arrange
        var taskId = _sampleTask.TaskId.Value;
        _taskRepository.Setup(repo => repo.GetTaskAsync(taskId, _userId).Result).Returns(_sampleTask);
        _mapper.Setup(mapper => mapper.Map<TaskDto>(It.IsAny<ToDoListAPI.Models.Task>())).Returns(_sampleTaskDto);

        // Act
        var result = _taskService.GetTaskAsync(taskId, _userId).Result;

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(_sampleTaskDto);
        _taskRepository.Verify(repo => repo.GetTaskAsync(taskId, _userId), Times.Once);
        _mapper.Verify(mapper => mapper.Map<TaskDto>(_sampleTask), Times.Once);
    }

    [Test]
    public void TestCreateTask()
    {
        // Arrange
        _taskRepository.Setup(repo => repo.CreateTaskAsync(It.IsAny<ToDoListAPI.Models.Task>(), _userId).Result).Returns(_sampleTask);
        _mapper.Setup(mapper => mapper.Map<ToDoListAPI.Models.Task>(It.IsAny<TaskDto>())).Returns(_sampleTask);
        _mapper.Setup(mapper => mapper.Map<TaskDto>(It.IsAny<ToDoListAPI.Models.Task>())).Returns(_sampleTaskDto);

        // Act
        var result = _taskService.CreateTaskAsync(_sampleTaskDto, _userId).Result;

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(_sampleTaskDto);
        _taskRepository.Verify(repo => repo.CreateTaskAsync(It.IsAny<ToDoListAPI.Models.Task>(), _userId), Times.Once);
        _mapper.Verify(mapper => mapper.Map<ToDoListAPI.Models.Task>(_sampleTaskDto), Times.Once);
        _mapper.Verify(mapper => mapper.Map<TaskDto>(_sampleTask), Times.Once);
    }

    [Test]
    public void TestUpdateTask()
    {
        // Arrange
        var taskId = _sampleTask.TaskId.Value;
        var updatedTask = new ToDoListAPI.Models.Task
        {
            TaskId = taskId,
            Title = "Updated Task",
            Description = "This is an updated task description",
            DueDate = new DateTime(2023, 7, 15, 12, 0, 0, DateTimeKind.Utc),
            Status = ToDoListAPI.Models.Task.StatusEnum.InProgress,
            ListId = _listId,
            UserId = _userId,
            RowVersion = new byte[] { 8, 9, 10, 11, 12, 13, 14, 15 }
        };

        var updatedTaskDto = new TaskDto
        {
            TaskId = updatedTask.TaskId,
            Title = updatedTask.Title,
            Description = updatedTask.Description,
            DueDate = updatedTask.DueDate,
            Status = TaskDto.StatusEnum.InProgress,
            ListId = updatedTask.ListId,
            UserId = updatedTask.UserId,
            RowVersion = updatedTask.RowVersion
        };

        _taskRepository.Setup(repo => repo.GetTaskAsync(taskId, _userId).Result).Returns(_sampleTask);
        _taskRepository.Setup(repo => repo.UpdateTaskAsync(taskId, It.IsAny<ToDoListAPI.Models.Task>(), _userId).Result).Returns(updatedTask);
        _mapper.Setup(mapper => mapper.Map<TaskDto>(It.IsAny<ToDoListAPI.Models.Task>())).Returns(updatedTaskDto);

        // Act
        var result = _taskService.UpdateTaskAsync(taskId, updatedTaskDto, _userId).Result;

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(updatedTaskDto);
        _taskRepository.Verify(repo => repo.GetTaskAsync(taskId, _userId), Times.Once);
        _taskRepository.Verify(repo => repo.UpdateTaskAsync(taskId, It.IsAny<ToDoListAPI.Models.Task>(), _userId), Times.Once);
        _mapper.Verify(mapper => mapper.Map<TaskDto>(updatedTask), Times.Once);
    }

    [Test]
    public void TestDeleteTask()
    {
        // Arrange
        var taskId = _sampleTask.TaskId.Value;
        _taskRepository.Setup(repo => repo.DeleteTaskAsync(taskId, _userId).Result).Returns(true);
        // Act
        var result = _taskService.DeleteTaskAsync(taskId, _userId).Result;

        // Assert
        result.Should().BeTrue();
        _taskRepository.Verify(repo => repo.DeleteTaskAsync(taskId, _userId), Times.Once);
    }
}

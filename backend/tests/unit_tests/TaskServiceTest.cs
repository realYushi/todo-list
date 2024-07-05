using NUnit.Framework;
using Moq;
using ToDoListAPI.Services;
using ToDoListAPI.Interfaces;
using AutoMapper;
using ToDoListAPI.DTOs;
using ToDoListAPI.Models;
using Task = ToDoListAPI.Models.Task;
using FluentAssertions;
using ToDoListAPI.Data;


[TestFixture]
public class TaskServiceTest
{
    private ITaskService _taskService;
    private Mock<IUnitOfWork> _unitOfWork;
    private Mock<IMapper> _mapper;
    private Task sampleTask;
    private TaskDto sampleTaskDto;
    private string userId = "user1"; // Add a user ID for testing

    [SetUp]
    public void Setup()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _mapper = new Mock<IMapper>();
        _taskService = new TaskService(_unitOfWork.Object, _mapper.Object);
        // Initialize shared task data

        sampleTask = new Task
        {
            Id = "1",
            Title = "Sample Task",
            Description = "Sample Description",
            DueDate = DateTime.Now.AddDays(1),
            Status = Task.StatusEnum.PendingEnum,
            ListId = "1",
        };

        sampleTaskDto = new TaskDto
        {
            Id = sampleTask.Id,
            Title = sampleTask.Title,
            Description = sampleTask.Description,
            DueDate = sampleTask.DueDate,
            Status = TaskDto.StatusEnum.PendingEnum,
            ListId = sampleTask.Id
        };
    }

    [Test]
    public void TestGetAllTasks()
    {
        // Arrange
        var tasks = new List<Task> { sampleTask };
        var tasksDto = new List<TaskDto> { sampleTaskDto };
        _unitOfWork.Setup(repo => repo.TaskRepository.GetAllTasks(userId)).Returns(tasks); // Include userId
        _mapper.Setup(mapper => mapper.Map<IEnumerable<TaskDto>>(It.IsAny<IEnumerable<Task>>())).Returns(tasksDto);
        // Act
        var result = _taskService.GetAllTasks(userId); // Include userId
        // Assert
        result.Should().NotBeNull(); // Ensures the result is not null
        result.Should().BeOfType<List<TaskDto>>(); // Checks that result is of type List<TaskDto>
        result.Should().HaveCount(tasks.Count); // Checks the count of returned tasks
        result.Should().BeEquivalentTo(tasksDto, options => options.ComparingByMembers<TaskDto>()); // Deep compare the actual result to expected DTOs
        result.Should().ContainItemsAssignableTo<TaskDto>(); // Ensures all items are of type TaskDto
        result.Should().BeEquivalentTo(tasksDto, options => options.ComparingByMembers<TaskDto>().WithStrictOrdering()); // Ensures the items are in the same order as expected

        _unitOfWork.Verify(repo => repo.TaskRepository.GetAllTasks(userId), Times.Once); // Verify that the GetAllTasks method was called exactly once
        _mapper.Verify(mapper => mapper.Map<IEnumerable<TaskDto>>(tasks), Times.Once); // Verify that the mapping was called exactly once with the specific input


    }

    [Test]
    public void TestGetTask()
    {
        // Arrange
        var taskId = "1";
        _unitOfWork.Setup(repo => repo.TaskRepository.GetTask(taskId, userId)).Returns(sampleTask); // Include userId
        _mapper.Setup(mapper => mapper.Map<TaskDto>(It.IsAny<Task>())).Returns(sampleTaskDto);
        // Act
        var result = _taskService.GetTask(taskId, userId); // Include userId
        // Assert
        result.Should().NotBeNull(); // Ensures the result is not null
        result.Should().BeOfType<TaskDto>(); // Checks that result is of type TaskDto
        result.Should().BeEquivalentTo(sampleTaskDto, options => options.ComparingByMembers<TaskDto>()); // Deep compare the actual result to expected DTO

        _unitOfWork.Verify(repo => repo.TaskRepository.GetTask(taskId, userId), Times.Once); // Verify that the GetTask method was called exactly once
        _mapper.Verify(mapper => mapper.Map<TaskDto>(sampleTask), Times.Once); // Verify that the mapping was called exactly once with the specific input
    }

    [Test]
    public void TestCreateTask()
    {
        // Arrange
        _unitOfWork.Setup(repo => repo.TaskRepository.CreateTask(It.IsAny<Task>(), userId)).Returns(sampleTask); // Include userId
        _mapper.Setup(mapper => mapper.Map<Task>(It.IsAny<TaskDto>())).Returns(sampleTask);
        _mapper.Setup(mapper => mapper.Map<TaskDto>(It.IsAny<Task>())).Returns(sampleTaskDto);

        // Act
        var result = _taskService.CreateTask(sampleTaskDto, userId); // Include userId

        // Assert
        result.Should().NotBeNull(); // Ensures the result is not null
        result.Should().BeOfType<TaskDto>(); // Checks that result is of type TaskDto
        result.Should().BeEquivalentTo(sampleTaskDto, options => options.ComparingByMembers<TaskDto>()); // Deep compare the actual result to expected DTO

        _unitOfWork.Verify(repo => repo.TaskRepository.CreateTask(It.IsAny<Task>(), userId), Times.Once); // Verify that the CreateTask method was called exactly once
        _mapper.Verify(mapper => mapper.Map<Task>(sampleTaskDto), Times.Once); // Verify that the mapping to Task was called exactly once with the specific input
        _mapper.Verify(mapper => mapper.Map<TaskDto>(sampleTask), Times.Once); // Verify that the mapping back to TaskDto was called exactly once
    }


    [Test]
    public void TestUpdateTask()
    {
        // Arrange
        var taskId = "1";
        var updatedTask = new Task
        {
            Id = taskId,
            Title = "Updated Task",
            Description = "Updated Description",
            DueDate = DateTime.Now.AddDays(2),
            Status = Task.StatusEnum.InProgressEnum,
            ListId = "1"
        };

        var updatedTaskDto = new TaskDto
        {
            Id = updatedTask.Id,
            Title = updatedTask.Title,
            Description = updatedTask.Description,
            DueDate = updatedTask.DueDate,
            Status = TaskDto.StatusEnum.InProgressEnum,
            ListId = updatedTask.ListId
        };

        _unitOfWork.Setup(repo => repo.TaskRepository.UpdateTask(taskId, It.IsAny<Task>(), userId)).Returns(updatedTask); // Include userId
        _mapper.Setup(mapper => mapper.Map<Task>(It.IsAny<TaskDto>())).Returns(updatedTask);
        _mapper.Setup(mapper => mapper.Map<TaskDto>(It.IsAny<Task>())).Returns(updatedTaskDto);

        // Act
        var result = _taskService.UpdateTask(taskId, updatedTaskDto, userId); // Include userId

        // Assert
        result.Should().NotBeNull(); // Ensures the result is not null
        result.Should().BeOfType<TaskDto>(); // Checks that result is of type TaskDto
        result.Should().BeEquivalentTo(updatedTaskDto, options => options.ComparingByMembers<TaskDto>()); // Deep compare the actual result to expected DTO

        _unitOfWork.Verify(repo => repo.TaskRepository.UpdateTask(taskId, It.IsAny<Task>(), userId), Times.Once); // Verify that the UpdateTask method was called exactly once
        _mapper.Verify(mapper => mapper.Map<Task>(updatedTaskDto), Times.Once); // Verify that the mapping to Task was called exactly once with the specific input
        _mapper.Verify(mapper => mapper.Map<TaskDto>(updatedTask), Times.Once); // Verify that the mapping to TaskDto was called exactly once with the specific input
    }


    [Test]
    public void TestDeleteTask()
    {
        // Arrange
        var taskId = "1";
        _unitOfWork.Setup(repo => repo.TaskRepository.DeleteTask(taskId, userId)); // Include userId

        // Act
        _taskService.DeleteTask(taskId, userId); // Include userId

        // Assert

        _unitOfWork.Verify(repo => repo.TaskRepository.DeleteTask(taskId, userId), Times.Once); // Verify that the DeleteTask method was called exactly once
    }
}

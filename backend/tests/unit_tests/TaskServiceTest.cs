using NUnit.Framework;
using Moq;
using ToDoListAPI.Services;
using ToDoListAPI.Interfaces;
using AutoMapper;
using ToDoListAPI.DTOs;
using ToDoListAPI.Models;
using Task = ToDoListAPI.Models.Task;
using FluentAssertions;


[TestFixture]
public class TaskServiceTest
{
    private ITaskService _taskService;
    private Mock<ITaskRepository> _taskRepository;
    private Mock<IMapper> _mapper;
    private Task sampleTask;
    private TaskDto sampleTaskDto;
    [SetUp]
    public void Setup()
    {
        _taskRepository = new Mock<ITaskRepository>();
        _mapper = new Mock<IMapper>();
        _taskService = new TaskService(_taskRepository.Object, _mapper.Object);
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
        _taskRepository.Setup(repo => repo.GetAllTasks()).Returns(tasks);
        _mapper.Setup(mapper => mapper.Map<IEnumerable<TaskDto>>(It.IsAny<IEnumerable<Task>>())).Returns(tasksDto);
        // Act
        var result = _taskService.GetAllTasks();
        // Assert
        result.Should().NotBeNull(); // Ensures the result is not null
        result.Should().BeOfType<List<TaskDto>>(); // Checks that result is of type List<TaskDto>
        result.Should().HaveCount(tasks.Count); // Checks the count of returned tasks
        result.Should().BeEquivalentTo(tasksDto, options => options.ComparingByMembers<TaskDto>()); // Deep compare the actual result to expected DTOs
        result.Should().ContainItemsAssignableTo<TaskDto>(); // Ensures all items are of type TaskDto
        result.Should().BeEquivalentTo(tasksDto, options => options.ComparingByMembers<TaskDto>().WithStrictOrdering()); // Ensures the items are in the same order as expected

        _taskRepository.Verify(repo => repo.GetAllTasks(), Times.Once); // Verify that the GetAllTasks method was called exactly once
        _mapper.Verify(mapper => mapper.Map<IEnumerable<TaskDto>>(tasks), Times.Once); // Verify that the mapping was called exactly once with the specific input


    }

    [Test]
    public void TestGetTask()
    {
        // Arrange
        var taskId = "1";
        _taskRepository.Setup(repo => repo.GetTask(taskId)).Returns(sampleTask);
        _mapper.Setup(mapper => mapper.Map<TaskDto>(It.IsAny<Task>())).Returns(sampleTaskDto);
        // Act
        var result = _taskService.GetTask(taskId);
        // Assert
        result.Should().NotBeNull(); // Ensures the result is not null
        result.Should().BeOfType<TaskDto>(); // Checks that result is of type TaskDto
        result.Should().BeEquivalentTo(sampleTaskDto, options => options.ComparingByMembers<TaskDto>()); // Deep compare the actual result to expected DTO

        _taskRepository.Verify(repo => repo.GetTask(taskId), Times.Once); // Verify that the GetTask method was called exactly once
        _mapper.Verify(mapper => mapper.Map<TaskDto>(sampleTask), Times.Once); // Verify that the mapping was called exactly once with the specific input
    }

    [Test]
    public void TestCreateTask()
    {
        // Arrange
        _taskRepository.Setup(repo => repo.CreateTask(It.IsAny<Task>())).Returns(sampleTask);
        _mapper.Setup(mapper => mapper.Map<Task>(It.IsAny<TaskDto>())).Returns(sampleTask);
        _mapper.Setup(mapper => mapper.Map<TaskDto>(It.IsAny<Task>())).Returns(sampleTaskDto);
        // Act
        var result = _taskService.CreateTask(sampleTaskDto);
        // Assert
        result.Should().NotBeNull(); // Ensures the result is not null
        result.Should().BeOfType<Task>(); // Checks that result is of type Task
        result.Should().BeEquivalentTo(sampleTask, options => options.ComparingByMembers<Task>()); // Deep compare the actual result to expected DTO

        _taskRepository.Verify(repo => repo.CreateTask(It.IsAny<Task>()), Times.Once); // Verify that the CreateTask method was called exactly once
        _mapper.Verify(mapper => mapper.Map<Task>(sampleTaskDto), Times.Once); // Verify that the mapping to Task was called exactly once with the specific input
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

        _taskRepository.Setup(repo => repo.UpdateTask(taskId, It.IsAny<Task>())).Returns(updatedTask);
        _mapper.Setup(mapper => mapper.Map<Task>(It.IsAny<TaskDto>())).Returns(updatedTask);
        _mapper.Setup(mapper => mapper.Map<TaskDto>(It.IsAny<Task>())).Returns(updatedTaskDto);

        // Act
        var result = _taskService.UpdateTask(taskId, updatedTaskDto);

        // Assert
        result.Should().NotBeNull(); // Ensures the result is not null
        result.Should().BeOfType<TaskDto>(); // Checks that result is of type TaskDto
        result.Should().BeEquivalentTo(updatedTaskDto, options => options.ComparingByMembers<TaskDto>()); // Deep compare the actual result to expected DTO

        _taskRepository.Verify(repo => repo.UpdateTask(taskId, It.IsAny<Task>()), Times.Once); // Verify that the UpdateTask method was called exactly once
        _mapper.Verify(mapper => mapper.Map<Task>(updatedTaskDto), Times.Once); // Verify that the mapping to Task was called exactly once with the specific input
        _mapper.Verify(mapper => mapper.Map<TaskDto>(updatedTask), Times.Once); // Verify that the mapping to TaskDto was called exactly once with the specific input
    }


    [Test]
    public void TestDeleteTask()
    {
        // Arrange
        var taskId = "1";
        _taskRepository.Setup(repo => repo.DeleteTask(taskId));

        // Act
        _taskService.DeleteTask(taskId);

        // Assert

        _taskRepository.Verify(repo => repo.DeleteTask(taskId), Times.Once); // Verify that the DeleteTask method was called exactly once
    }
}

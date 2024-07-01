using NUnit.Framework;
using Moq;
using ToDoListAPI.Services;
using ToDoListAPI.Interfaces;
using AutoMapper;
namespace unit_tests.TaskServiceTest


{
    [TestFixture]
    public class TaskServiceTest
    {
        private ITaskService _taskService;
        private Mock<ITaskRepository> _taskRepository;
        private Mock<IMapper> _mapper;
        [SetUp]
        public void Setup()
        {
            _taskRepository = new Mock<ITaskRepository>();
            _mapper = new Mock<IMapper>();
            _taskService = new TaskService(_taskRepository.Object, _mapper.Object);
        }

        [Test]
        public void TestGetAllTasks()
        {
            // Arrange
            // Act
            // Assert
        }

        [Test]
        public void TestGetTask()
        {
            // Arrange
            // Act
            // Assert
        }

        [Test]
        public void TestCreateTask()
        {
            // Arrange
            // Act
            // Assert
        }

        [Test]
        public void TestUpdateTask()
        {
            // Arrange
            // Act
            // Assert
        }

        [Test]
        public void TestDeleteTask()
        {
            // Arrange
            // Act
            // Assert
        }
    }
}

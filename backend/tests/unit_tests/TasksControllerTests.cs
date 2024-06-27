
using Moq;
using ToDoListAPI.Controllers;
using ToDoListAPI.Models;
using NUnit.Framework;

namespace ToDoListAPI.Tests
{
    [TestFixture]
    public class TasksControllerTests
    {
        private Mock<ITasksRepository> _mockTasksRepository;
        private TasksController _tasksController;

        [SetUp]
        public void SetUp()
        {
            _mockTasksRepository = new Mock<ITasksRepository>();
            _tasksController = new TasksController(_mockTasksRepository.Object);
        }

        [Test]
        public void GetTasks_ReturnsTasks()
        {
            // Arrange
            var tasks = new List<TaskModel>
            {
                new TaskModel { Id = "1", Name = "Task 1", ListId = "1" },
                new TaskModel { Id = "2", Name = "Task 2", ListId = "1" },
                new TaskModel { Id = "3", Name = "Task 3", ListId = "2" }
            };

            _mockTasksRepository.Setup(x => x.GetTasks()).Returns(tasks);

            // Act
            var result = _tasksController.GetTasks();

            // Assert
            Assert.That(result, Is.EqualTo(tasks));
        }
    }
}

namespace ToDoListAPI.Tests
{
    [TestFixture]
    public class TasksControllerTests
    {
        private Mock<ITasksRepository> _mockTasksRepository;
        private TasksController _tasksController;

        [SetUp]
        public void SetUp()
        {
            _mockTasksRepository = new Mock<ITasksRepository>();
            _tasksController = new TasksController(_mockTasksRepository.Object);
        }

        [Test]
        public void GetTasks_ReturnsTasks()
        {
            // Arrange
            var tasks = new List<TaskModel>
            {
                new TaskModel { Id = "1", Name = "Task 1", ListId = "1" },
                new TaskModel { Id = "2", Name = "Task 2", ListId = "1" },
                new TaskModel { Id = "3", Name = "Task 3", ListId = "2" }
            };

            _mockTasksRepository.Setup(x => x.GetTasks()).Returns(tasks);

            // Act
            var result = _tasksController.GetTasks();

            // Assert
            Assert.That(result, Is.EqualTo(tasks));
        }
    }
}
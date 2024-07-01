using NUnit.Framework;
using Moq;
using ToDoListAPI.Services;
using ToDoListAPI.Interfaces;
using AutoMapper;
namespace unit_tests.UserServiceTest


{
    [TestFixture]
    public class UserServiceTest
    {
        private IUserService _userService;
        private Mock<IUserRepository> _userRepository;
        private Mock<IMapper> _mapper;
        [SetUp]
        public void Setup()
        {
            _userRepository = new Mock<IUserRepository>();
            _mapper = new Mock<IMapper>();
            _userService = new UserService(_userRepository.Object, _mapper.Object);
        }
        [Test]
        public void TestCreateUser()
        {
            // Arrange
            // Act
            // Assert
        }

        [Test]
        public void TestDeleteUser()
        {
            // Arrange
            // Act
            // Assert
        }

        [Test]
        public void TestGetAllUsers()
        {
            // Arrange
            // Act
            // Assert
        }

        [Test]
        public void TestGetUser()
        {
            // Arrange
            // Act
            // Assert
        }

        [Test]
        public void TestUpdateUser()
        {
            // Arrange
            // Act
            // Assert
        }
    }
}

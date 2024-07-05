using NUnit.Framework;
using Moq;
using ToDoListAPI.Services;
using ToDoListAPI.Interfaces;
using AutoMapper;
using ToDoListAPI.DTOs;
using ToDoListAPI.Models;
using FluentAssertions;


[TestFixture]
public class UserServiceTest
{
    private IUserService _userService;
    private Mock<IUnitOfWork> _unitOfWork;
    private Mock<IMapper> _mapper;
    private User sampleUser;
    private UserDto sampleUserDto;
    [SetUp]
    public void Setup()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _mapper = new Mock<IMapper>();
        _userService = new UserService(_unitOfWork.Object, _mapper.Object);
        // Initialize shared user data

        sampleUser = new User
        {
            UserId = "1",
            Username = "john_doe",
            Email = "john.doe@example.com",
            Role = "Administrator",
            Status = "Active"
        };

        sampleUserDto = new UserDto
        {
            UserId = "1",
            Username = "john_doe",
            Email = "john.doe@example.com",
            Role = "Administrator",
            Status = "Active"
        };
    }

    [Test]
    public void TestGetAllUsers()
    {
        // Arrange
        var userId = "1"; // Assuming you want to test with a specific user ID
        var users = new List<User> { sampleUser };
        var usersDto = new List<UserDto> { sampleUserDto };
        _unitOfWork.Setup(repo => repo.UserRepository.GetAllUsers(userId)).Returns(users);
        _mapper.Setup(mapper => mapper.Map<IEnumerable<UserDto>>(It.IsAny<IEnumerable<User>>())).Returns(usersDto);
        // Act
        var result = _userService.GetAllUsers(userId);
        // Assert
        result.Should().NotBeNull(); // Ensures the result is not null
        result.Should().BeOfType<List<UserDto>>(); // Checks that result is of type List<UserDto>
        result.Should().HaveCount(users.Count); // Checks the count of returned users
        result.Should().BeEquivalentTo(usersDto, options => options.ComparingByMembers<UserDto>()); // Deep compare the actual result to expected DTOs
        result.Should().ContainItemsAssignableTo<UserDto>(); // Ensures all items are of type UserDto

        _unitOfWork.Verify(repo => repo.UserRepository.GetAllUsers(userId), Times.Once); // Verify that the GetAllUsers method was called exactly once
        _mapper.Verify(mapper => mapper.Map<IEnumerable<UserDto>>(users), Times.Once); // Verify that the mapping was called exactly once with the specific input
    }

    [Test]
    public void TestGetUser()
    {
        // Arrange
        var userId = "1";
        _unitOfWork.Setup(repo => repo.UserRepository.GetUser(userId)).Returns(sampleUser);
        _mapper.Setup(mapper => mapper.Map<UserDto>(It.IsAny<User>())).Returns(sampleUserDto);
        // Act
        var result = _userService.GetUser(userId);
        // Assert
        result.Should().NotBeNull(); // Ensures the result is not null
        result.Should().BeOfType<UserDto>(); // Checks that result is of type UserDto
        result.Should().BeEquivalentTo(sampleUserDto, options => options.ComparingByMembers<UserDto>()); // Deep compare the actual result to expected DTO

        _unitOfWork.Verify(repo => repo.UserRepository.GetUser(userId), Times.Once); // Verify that the GetUser method was called exactly once
        _mapper.Verify(mapper => mapper.Map<UserDto>(sampleUser), Times.Once); // Verify that the mapping was called exactly once with the specific input
    }

    [Test]
    public void TestCreateUser()
    {
        // Arrange
        _unitOfWork.Setup(repo => repo.UserRepository.CreateUser(It.IsAny<User>())).Returns(sampleUser);
        _mapper.Setup(mapper => mapper.Map<User>(It.IsAny<UserDto>())).Returns(sampleUser);
        _mapper.Setup(mapper => mapper.Map<UserDto>(It.IsAny<User>())).Returns(sampleUserDto);

        // Act
        var result = _userService.CreateUser(sampleUserDto);

        // Assert
        result.Should().NotBeNull(); // Ensures the result is not null
        result.Should().BeOfType<UserDto>(); // Checks that result is of type UserDto
        result.Should().BeEquivalentTo(sampleUserDto, options => options.ComparingByMembers<UserDto>()); // Deep compare the actual result to expected DTO

        _unitOfWork.Verify(repo => repo.UserRepository.CreateUser(It.IsAny<User>()), Times.Once); // Verify that the CreateUser method was called exactly once
        _mapper.Verify(mapper => mapper.Map<User>(sampleUserDto), Times.Once); // Verify that the mapping to User was called exactly once with the specific input
        _mapper.Verify(mapper => mapper.Map<UserDto>(sampleUser), Times.Once); // Verify that the mapping back to UserDto was called exactly once
    }

    [Test]
    public void TestUpdateUser()
    {
        // Arrange
        var userId = "1";
        var updatedUser = new User
        {
            UserId = userId,
            Username = "Updated User",
            Email = "update@example.com",
            Role = "User",
            Status = "Inactive"
        };

        var updatedUserDto = new UserDto
        {
            UserId = updatedUser.UserId,
            Username = updatedUser.Username,
            Email = updatedUser.Email,
            Role = updatedUser.Role,
            Status = updatedUser.Status
        };

        _unitOfWork.Setup(repo => repo.UserRepository.UpdateUser(userId, It.IsAny<User>())).Returns(updatedUser);
        _mapper.Setup(mapper => mapper.Map<User>(It.IsAny<UserDto>())).Returns(updatedUser);
        _mapper.Setup(mapper => mapper.Map<UserDto>(It.IsAny<User>())).Returns(updatedUserDto);

        // Act
        var result = _userService.UpdateUser(userId, updatedUserDto);

        // Assert
        result.Should().NotBeNull(); // Ensures the result is not null
        result.Should().BeOfType<UserDto>(); // Checks that result is of type UserDto
        result.Should().BeEquivalentTo(updatedUserDto, options => options.ComparingByMembers<UserDto>()); // Deep compare the actual result to expected DTO

        _unitOfWork.Verify(repo => repo.UserRepository.UpdateUser(userId, It.IsAny<User>()), Times.Once); // Verify that the UpdateUser method was called exactly once
        _mapper.Verify(mapper => mapper.Map<User>(updatedUserDto), Times.Once); // Verify that the mapping to User was called exactly once with the specific input
        _mapper.Verify(mapper => mapper.Map<UserDto>(updatedUser), Times.Once); // Verify that the mapping to UserDto was called exactly once with the specific input
    }


    [Test]
    public void TestDeleteUser()
    {
        // Arrange
        var userId = "1";
        _unitOfWork.Setup(repo => repo.UserRepository.DeleteUser(userId));

        // Act
        _userService.DeleteUser(userId);

        // Assert

        _unitOfWork.Verify(repo => repo.UserRepository.DeleteUser(userId), Times.Once); // Verify that the DeleteUser method was called exactly once
    }
}

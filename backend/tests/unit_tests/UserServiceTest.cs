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
    private Mock<IUserRepository> _userRepository;
    private Mock<IMapper> _mapper;
    private User sampleUser;
    private UserDto sampleUserDto;
    [SetUp]
    public void Setup()
    {
        _userRepository = new Mock<IUserRepository>();
        _mapper = new Mock<IMapper>();
        _userService = new UserService(_userRepository.Object, _mapper.Object);
        // Initialize shared user data

        sampleUser = new User
        {
            Id = "1",
            Username = "john_doe",
            Email = "john.doe@example.com",
            Role = "Administrator",
            Status = "Active"
        };

        sampleUserDto = new UserDto
        {
            Id = "1",
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
        var users = new List<User> { sampleUser };
        var usersDto = new List<UserDto> { sampleUserDto };
        _userRepository.Setup(repo => repo.GetAllUsers(It.IsAny<string>(), It.IsAny<string>())).Returns(users);
        _mapper.Setup(mapper => mapper.Map<IEnumerable<UserDto>>(It.IsAny<IEnumerable<User>>())).Returns(usersDto);
        // Act
        var result = _userService.GetAllUsers("Administrator", "Active");
        // Assert
        result.Should().NotBeNull(); // Ensures the result is not null
        result.Should().BeOfType<List<UserDto>>(); // Checks that result is of type User<UserDto>
        result.Should().HaveCount(users.Count); // Checks the count of returned users
        result.Should().BeEquivalentTo(usersDto, options => options.ComparingByMembers<UserDto>()); // Deep compare the actual result to expected DTOs
        result.Should().ContainItemsAssignableTo<UserDto>(); // Ensures all items are of type UserDto
        result.Should().BeEquivalentTo(usersDto, options => options.ComparingByMembers<UserDto>().WithStrictOrdering()); // Ensures the items are in the same order as expected

        _userRepository.Verify(repo => repo.GetAllUsers("Administrator", "Active"), Times.Once); // Verify that the GetAllUsers method was called exactly once
        _mapper.Verify(mapper => mapper.Map<IEnumerable<UserDto>>(users), Times.Once); // Verify that the mapping was called exactly once with the specific input


    }

    [Test]
    public void TestGetUser()
    {
        // Arrange
        var userId = "1";
        _userRepository.Setup(repo => repo.GetUser(userId)).Returns(sampleUser);
        _mapper.Setup(mapper => mapper.Map<UserDto>(It.IsAny<User>())).Returns(sampleUserDto);
        // Act
        var result = _userService.GetUser(userId);
        // Assert
        result.Should().NotBeNull(); // Ensures the result is not null
        result.Should().BeOfType<UserDto>(); // Checks that result is of type UserDto
        result.Should().BeEquivalentTo(sampleUserDto, options => options.ComparingByMembers<UserDto>()); // Deep compare the actual result to expected DTO

        _userRepository.Verify(repo => repo.GetUser(userId), Times.Once); // Verify that the GetUser method was called exactly once
        _mapper.Verify(mapper => mapper.Map<UserDto>(sampleUser), Times.Once); // Verify that the mapping was called exactly once with the specific input
    }

    [Test]
    public void TestCreateUser()
    {
        // Arrange
        _userRepository.Setup(repo => repo.CreateUser(It.IsAny<User>())).Returns(sampleUser);
        _mapper.Setup(mapper => mapper.Map<User>(It.IsAny<UserDto>())).Returns(sampleUser);
        _mapper.Setup(mapper => mapper.Map<UserDto>(It.IsAny<User>())).Returns(sampleUserDto);
        // Act
        var result = _userService.CreateUser(sampleUserDto);
        // Assert
        result.Should().NotBeNull(); // Ensures the result is not null
        result.Should().BeOfType<User>(); // Checks that result is of type User
        result.Should().BeEquivalentTo(sampleUser, options => options.ComparingByMembers<User>()); // Deep compare the actual result to expected DTO

        _userRepository.Verify(repo => repo.CreateUser(It.IsAny<User>()), Times.Once); // Verify that the CreateUser method was called exactly once
        _mapper.Verify(mapper => mapper.Map<User>(sampleUserDto), Times.Once); // Verify that the mapping to User was called exactly once with the specific input
    }

    [Test]
    public void TestUpdateUser()
    {
        // Arrange
        var userId = "1";
        var updatedUser = new User
        {
            Id = userId,
            Username = "Updated User",
            Email = "update@example.com",
            Role = "User",
            Status = "Inactive"
        };

        var updatedUserDto = new UserDto
        {
            Id = updatedUser.Id,
            Username = updatedUser.Username,
            Email = updatedUser.Email,
            Role = updatedUser.Role,
            Status = updatedUser.Status
        };

        _userRepository.Setup(repo => repo.UpdateUser(userId, It.IsAny<User>())).Returns(updatedUser);
        _mapper.Setup(mapper => mapper.Map<User>(It.IsAny<UserDto>())).Returns(updatedUser);
        _mapper.Setup(mapper => mapper.Map<UserDto>(It.IsAny<User>())).Returns(updatedUserDto);

        // Act
        var result = _userService.UpdateUser(userId, updatedUserDto);

        // Assert
        result.Should().NotBeNull(); // Ensures the result is not null
        result.Should().BeOfType<UserDto>(); // Checks that result is of type UserDto
        result.Should().BeEquivalentTo(updatedUserDto, options => options.ComparingByMembers<UserDto>()); // Deep compare the actual result to expected DTO

        _userRepository.Verify(repo => repo.UpdateUser(userId, It.IsAny<User>()), Times.Once); // Verify that the UpdateUser method was called exactly once
        _mapper.Verify(mapper => mapper.Map<User>(updatedUserDto), Times.Once); // Verify that the mapping to User was called exactly once with the specific input
        _mapper.Verify(mapper => mapper.Map<UserDto>(updatedUser), Times.Once); // Verify that the mapping to UserDto was called exactly once with the specific input
    }


    [Test]
    public void TestDeleteUser()
    {
        // Arrange
        var userId = "1";
        _userRepository.Setup(repo => repo.DeleteUser(userId));

        // Act
        _userService.DeleteUser(userId);

        // Assert

        _userRepository.Verify(repo => repo.DeleteUser(userId), Times.Once); // Verify that the DeleteUser method was called exactly once
    }
}

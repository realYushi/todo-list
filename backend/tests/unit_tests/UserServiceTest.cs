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
public class UserServiceTest
{
    private UserService _userService;
    private Mock<IUserRepository> _userRepository;
    private Mock<IMapper> _mapper;
    private User _sampleUser;
    private UserDto _sampleUserDto;

    [SetUp]
    public void Setup()
    {
        _userRepository = new Mock<IUserRepository>();
        _mapper = new Mock<IMapper>();
        _userService = new UserService(_userRepository.Object, _mapper.Object);

        // Initialize shared user data
        _sampleUser = new User
        {
            UserId = Guid.NewGuid(),
            Username = "john_doe",
            Email = "john.doe@example.com",
            Role = UserRole.User,
            Status = UserStatus.Active,
            Password = "password",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null
        };

        _sampleUserDto = new UserDto
        {
            UserId = _sampleUser.UserId,
            Username = _sampleUser.Username,
            Email = _sampleUser.Email,
            Role = _sampleUser.Role.ToString(),
            Status = _sampleUser.Status.ToString(),
            Password = _sampleUser.Password,
            CreatedAt = _sampleUser.CreatedAt,
            UpdatedAt = _sampleUser.UpdatedAt
        };
    }

    [Test]
    public void TestGetAllUsers()
    {
        // Arrange
        var users = new List<User> { _sampleUser };
        var usersDto = new List<UserDto> { _sampleUserDto };
        _userRepository.Setup(repo => repo.GetAllUsersAsync()).ReturnsAsync(users);
        _mapper.Setup(mapper => mapper.Map<IEnumerable<UserDto>>(It.IsAny<IEnumerable<User>>())).Returns(usersDto);

        // Act
        var result = _userService.GetAllUsersAsync().Result;

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<List<UserDto>>();
        result.Should().HaveCount(users.Count);
        result.Should().BeEquivalentTo(usersDto, options => options.ComparingByMembers<UserDto>());
        result.Should().ContainItemsAssignableTo<UserDto>();

        _userRepository.Verify(repo => repo.GetAllUsersAsync(), Times.Once);
        _mapper.Verify(mapper => mapper.Map<IEnumerable<UserDto>>(users), Times.Once);
    }

    [Test]
    public void TestGetUser()
    {
        // Arrange
        var userName = "john_doe";
        var email = "john.doe@example.com";

        _userRepository.Setup(repo => repo.GetUserAsync(userName)).ReturnsAsync(_sampleUser);
        _mapper.Setup(mapper => mapper.Map<UserDto>(It.IsAny<User>())).Returns(_sampleUserDto);
        // Act
        var result = _userService.GetUserAsync(userName).Result;

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<UserDto>();
        result.Should().BeEquivalentTo(_sampleUserDto, options => options.ComparingByMembers<UserDto>());

        _userRepository.Verify(repo => repo.GetUserAsync(userName), Times.Once);
        _mapper.Verify(mapper => mapper.Map<UserDto>(_sampleUser), Times.Once);
    }

    [Test]
    public void TestCreateUser()
    {
        // Arrange
        _userRepository.Setup(repo => repo.CreateUserAsync(It.IsAny<User>())).ReturnsAsync(_sampleUser);
        _mapper.Setup(mapper => mapper.Map<User>(It.IsAny<UserDto>())).Returns(_sampleUser);
        _mapper.Setup(mapper => mapper.Map<UserDto>(It.IsAny<User>())).Returns(_sampleUserDto);

        // Act
        var result = _userService.CreateUserAsync(_sampleUserDto).Result;

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<UserDto>();
        result.Should().BeEquivalentTo(_sampleUserDto, options => options.ComparingByMembers<UserDto>());

        _userRepository.Verify(repo => repo.CreateUserAsync(It.IsAny<User>()), Times.Once);
        _mapper.Verify(mapper => mapper.Map<User>(_sampleUserDto), Times.Once);
        _mapper.Verify(mapper => mapper.Map<UserDto>(_sampleUser), Times.Once);
    }

    [Test]
    public void TestUpdateUser()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var updatedUser = new User
        {
            UserId = userId,
            Username = "Updated User",
            Email = "update@example.com",
            Role = UserRole.Admin,
            Status = UserStatus.Inactive,
            Password = "updatedpassword",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var updatedUserDto = new UserDto
        {
            UserId = updatedUser.UserId,
            Username = updatedUser.Username,
            Email = updatedUser.Email,
            Role = updatedUser.Role.ToString(),
            Status = updatedUser.Status.ToString(),
            Password = updatedUser.Password,
            CreatedAt = updatedUser.CreatedAt,
            UpdatedAt = updatedUser.UpdatedAt
        };

        _userRepository.Setup(repo => repo.UpdateUserAsync(userId, It.IsAny<User>())).ReturnsAsync(updatedUser);
        _mapper.Setup(mapper => mapper.Map<User>(It.IsAny<UserDto>())).Returns(updatedUser);
        _mapper.Setup(mapper => mapper.Map<UserDto>(It.IsAny<User>())).Returns(updatedUserDto);

        // Act
        var result = _userService.UpdateUserAsync(updatedUserDto, userId).Result;

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<UserDto>();
        result.Should().BeEquivalentTo(updatedUserDto, options => options.ComparingByMembers<UserDto>());

        _userRepository.Verify(repo => repo.UpdateUserAsync(userId, It.IsAny<User>()), Times.Once);
        _mapper.Verify(mapper => mapper.Map<User>(updatedUserDto), Times.Once);
        _mapper.Verify(mapper => mapper.Map<UserDto>(updatedUser), Times.Once);
    }

    [Test]
    public void TestDeleteUser()
    {
        // Arrange
        var userId = Guid.NewGuid();
        _userRepository.Setup(repo => repo.DeleteUserAsync(userId)).ReturnsAsync(true);
        // Act
        var result = _userService.DeleteUserAsync(userId).Result;

        // Assert
        result.Should().BeTrue();
        _userRepository.Verify(repo => repo.DeleteUserAsync(userId), Times.Once);
    }
}
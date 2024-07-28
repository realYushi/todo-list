using NUnit.Framework;
using ToDoListAPI.Models;
using ToDoListAPI.Data.Repositories;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

[TestFixture]
public class TestUserRepository : RepositoryTestBase
{
    private UserRepository _userRepository;
    private List<User> _seedUsers;

    [SetUp]
    public void SetUp()
    {
        base.SetUp();
        _userRepository = new UserRepository(context);
        SeedDatabase();
    }

    private void SeedDatabase()
    {
        _seedUsers = new List<User>
        {
            new User { UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Username = "johndoe", Email = "john.doe@example.com", Password = "password123", Role = UserRole.Admin, Status = UserStatus.Active },
            new User { UserId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Username = "janedoe", Email = "jane.doe@example.com", Password = "password456", Role = UserRole.User, Status = UserStatus.Active }
        };

        context.Users.AddRange(_seedUsers);
        context.SaveChanges();
    }

    [Test]
    public void TestGetAllUsers()
    {
        var result = _userRepository.GetAllUsersAsync().GetAwaiter().GetResult();
        result.Should().BeEquivalentTo(_seedUsers);
    }

    [Test]
    public void TestGetUser()
    {
        var userName = "johndoe";
        var email = "john.doe@example.com";
        var result = _userRepository.GetUserAsync(userName).GetAwaiter().GetResult();
        result.Should().BeEquivalentTo(_seedUsers[0]);
    }

    [Test]
    public void TestCreateUser()
    {
        var newUser = new User { Username = "sallydoe", Email = "sally.doe@example.com", Password = "password789", Role = UserRole.User, Status = UserStatus.Active };
        var result = _userRepository.CreateUserAsync(newUser).GetAwaiter().GetResult();
        result.UserId.Should().NotBeNull();
        result.Username.Should().Be("sallydoe");
        result.Email.Should().Be("sally.doe@example.com");
        result.Role.Should().Be(UserRole.User);
        result.Status.Should().Be(UserStatus.Active);

        var createdUser = _userRepository.GetUserAsync(result.Username).GetAwaiter().GetResult();
        createdUser.Should().NotBeNull();
    }

    [Test]
    public void TestUpdateUser()
    {
        var userToUpdate = _seedUsers[0];
        var updatedUser = new User
        {
            UserId = userToUpdate.UserId,
            Username = userToUpdate.Username,
            Email = "john.updated@example.com",
            Password = "updatedpassword",
            Role = userToUpdate.Role,
            Status = userToUpdate.Status
        };
        var result = _userRepository.UpdateUserAsync(userToUpdate.UserId.Value, updatedUser).GetAwaiter().GetResult();

        result.Should().NotBeNull();
        result.Email.Should().Be("john.updated@example.com");
        result.Password.Should().Be("updatedpassword");
    }
}

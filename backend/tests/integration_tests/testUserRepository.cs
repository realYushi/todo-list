using NUnit.Framework;
using ToDoListAPI.Models;
using ToDoListAPI.Data.Repositories;
using FluentAssertions;

[TestFixture]
public class testUserRepository : RepositoryTestBase
{
    private UserRepository userRepository;

    [SetUp]
    public void SetUp()
    {
        userRepository = new UserRepository(context);
    }

    [Test]
    public void TestGetAllUsers()
    {
        // Arrange
        var expected = new List<User>
        {
            new User { UserId = "user2", Username = "janedoe", Email = "jane.doe@example.com", Role = "User", Status = "Active" }
        };
        var userId = "user2"; // Corrected to use a single userId parameter

        // Act
        var result = userRepository.GetAllUsers(userId);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void TestGetUser()
    {
        // Arrange
        var expected = new User { UserId = "user1", Username = "johndoe", Email = "john.doe@example.com", Role = "Admin", Status = "Active" };
        var userId = "user1";

        // Act
        var result = userRepository.GetUser(userId);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void TestCreateUser()
    {
        // Arrange
        var newUser = new User { Username = "sallydoe", Password = "password", Email = "sally.doe@example.com", Role = "User", Status = "Active" };

        // Act
        var result = userRepository.CreateUser(newUser);
        context.SaveChanges();

        // Assert
        result.UserId.Should().NotBeNull("UserID should be assigned after creation."); // Changed from Id to UserId
        result.Username.Should().Be("sallydoe");
        result.Email.Should().Be("sally.doe@example.com");
        result.Role.Should().Be("User");
        result.Status.Should().Be("Active");
        var createdUser = userRepository.GetUser(result.UserId); // Changed from Id to UserId
        createdUser.Should().NotBeNull();
    }

    [Test]
    public void TestUpdateUser()
    {
        // Arrange
        var updatedUser = new User { UserId = "user1", Username = "johnnydoe", Password = "password", Email = "john.doe@example.com", Role = "Admin", Status = "Active" };

        // Act
        userRepository.UpdateUser(updatedUser.UserId, updatedUser); // Changed from Id to UserId
        context.SaveChanges();
        var result = userRepository.GetUser(updatedUser.UserId); // Changed from Id to UserId

        // Assert
        result.Should().BeEquivalentTo(updatedUser);
    }

    [Test]
    public void TestDeleteUser()
    {
        // Arrange
        var userId = "user1";

        // Act
        userRepository.DeleteUser(userId);
        context.SaveChanges();
        var result = userRepository.GetUser(userId);

        // Assert
        result.Should().BeNull();
    }
}
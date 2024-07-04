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
            new User { Id = "user2", Username = "janedoe", Email = "jane.doe@example.com", Role = "User", Status = "Active" }
        };

        // Act
        var result = userRepository.GetAllUsers("User", "Active");

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void TestGetUser()
    {
        // Arrange
        var expected = new User { Id = "user1", Username = "johndoe", Email = "john.doe@example.com", Role = "Admin", Status = "Active" };
        var id = "user1";

        // Act
        var result = userRepository.GetUser(id);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void TestCreateUser()
    {
        // Arrange
        var newUser = new User { Username = "sallydoe", Email = "sally.doe@example.com", Role = "User", Status = "Active" };

        // Act
        var result = userRepository.CreateUser(newUser);
        context.SaveChanges();

        // Assert
        result.Id.Should().NotBeNull("ID should be assigned after creation.");
        result.Username.Should().Be("sallydoe");
        result.Email.Should().Be("sally.doe@example.com");
        result.Role.Should().Be("User");
        result.Status.Should().Be("Active");
        var createdUser = userRepository.GetUser(result.Id);
        createdUser.Should().NotBeNull();
    }

    [Test]
    public void TestUpdateUser()
    {
        // Arrange
        var updatedUser = new User { Id = "user1", Username = "johnnydoe", Email = "john.doe@example.com", Role = "Admin", Status = "Active" };

        // Act
        userRepository.UpdateUser(updatedUser.Id, updatedUser);
        context.SaveChanges();
        var result = userRepository.GetUser(updatedUser.Id);

        // Assert
        result.Should().BeEquivalentTo(updatedUser);
    }

    [Test]
    public void TestDeleteUser()
    {
        // Arrange
        var id = "user1";

        // Act
        userRepository.DeleteUser(id);
        context.SaveChanges();
        var result = userRepository.GetUser(id);

        // Assert
        result.Should().BeNull();
    }
}
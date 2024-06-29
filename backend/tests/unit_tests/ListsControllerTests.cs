using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Controllers;
using ToDoListAPI.Models;
using System.Collections.Generic;

namespace backend.tests.unit_tests
{
    [TestFixture]
    public class ListsControllerTests
    {
        private ListController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new ListController();
        }

        [Test]
        public void ListsGet_ReturnsExpectedResult()
        {
            // Arrange
            string name = "test";

            // Act
            var result = _controller.ListsGet(name) as ObjectResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(200));

            var lists = result.Value as List<List>;
            Assert.That(lists, Is.Not.Null);
            Assert.That(lists.Count, Is.EqualTo(2));
            Assert.That(lists[0].UserId, Is.EqualTo("user_id"));
            Assert.That(lists[0].Name, Is.EqualTo("name"));
            Assert.That(lists[0].Description, Is.EqualTo("description"));
            Assert.That(lists[0].Id, Is.EqualTo("id"));
        }
    }
}

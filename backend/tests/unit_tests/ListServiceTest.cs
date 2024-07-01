using NUnit.Framework;
using Moq;
using ToDoListAPI.Services;
using ToDoListAPI.Interfaces;
using AutoMapper;
namespace unit_tests.ListServiceTest


{
    [TestFixture]
    public class ListServiceTest
    {
        private IListService _listService;
        private Mock<IListRepository> _listRepository;
        private Mock<IMapper> _mapper;
        [SetUp]
        public void Setup()
        {
            _listRepository = new Mock<IListRepository>();
            _mapper = new Mock<IMapper>();
            _listService = new ListService(_listRepository.Object, _mapper.Object);
        }
        [Test]
        public void TestCreateList()
        {
            // Arrange
            // Act
            // Assert
        }
        [Test]
        public void TestDeleteList()
        {
            // Arrange
            // Act
            // Assert
        }
        [Test]
        public void TestGetAllLists()
        {
            // Arrange
            // Act
            // Assert
        }
        [Test]
        public void TestGetList()
        {
            // Arrange
            // Act
            // Assert
        }
        [Test]
        public void TestUpdateList()
        {
            // Arrange
            // Act
            // Assert
        }
    }
}

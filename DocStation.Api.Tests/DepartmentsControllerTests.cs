using AutoMapper;
using DocStation.Api;
using DocStation.Api.Controllers;
using DocStation.Api.Mapping;
using DocStation.Api.Services;
using DocStation.Data.Models;
using Moq;

namespace DocStation.Api.Tests
{
    [TestFixture]
    public class DepartmentsControllerTests 
    {
        private DepartmentsController _departmentsController;
        private Mock<IDepartmentService> _departmentService;
        

        [SetUp]
        

        public void Setup()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DepartmensProfile()); //your automapperprofile 
            });
            var mapper = mockMapper.CreateMapper();

            _departmentService = new Mock<IDepartmentService>();
            _departmentsController = new DepartmentsController(_departmentService.Object, mapper);
        }

        [Test]
        public void GetDepartments_NoDepartments_ReturnsEmptyResult()
        {
            _departmentService.Setup(x => x.GetAll()).Returns(Array.Empty<HDepartments>);

            var actual = _departmentsController.GetDepartments();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.Empty);
        }

        [Test]
        public void GetDepartments_HasMultipleDepartments_ReturnsExpectedResult()
        {
            

            var coolection = new[] { new HDepartments() { Id = 1, Name = "Name1", Description = "Description1" }, new HDepartments() { Id = 2, Name = "Name2", Description = "Description2" } };

            _departmentService.Setup(x => x.GetAll()).Returns(coolection);



            var actual = _departmentsController.GetDepartments();

            Assert.That(actual, Is.Not.Null);
            
            Assert.That(actual.Count, Is.EqualTo(2));

            Assert.That(actual.ElementAt(0).Id, Is.EqualTo(1));
            Assert.That(actual.ElementAt(0).Name, Is.EqualTo("Name1"));
            Assert.That(actual.ElementAt(0).Description, Is.EqualTo("Description1"));
            Assert.That(actual.ElementAt(1).Id, Is.EqualTo(2));
            Assert.That(actual.ElementAt(1).Name, Is.EqualTo("Name2"));
            Assert.That(actual.ElementAt(1).Description, Is.EqualTo("Description2"));

        }
    }
}
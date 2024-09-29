using AutoMapper;
using DocStation.Api;
using DocStation.Api.Controllers;
using DocStation.Api.DTOs.HDepartments;
using DocStation.Api.DTOs.SubsidiariesDto;
using DocStation.Api.Mapping;
using DocStation.Api.Services;
using DocStation.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DocStation.Api.Tests
{
    [TestFixture]
    public class SubsidiariesControllerTests
    {
        private SubsidiariesController _subsidiariesController;
        private Mock<ISubsidiariesService> _subsidiariesService;
        private Mock<IDepartmentService> _departmentService;


        [SetUp]


        public void Setup()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new SubsidiarisProfile());
            });
            var mapper = mockMapper.CreateMapper();

            _departmentService = new Mock<IDepartmentService>();

            _subsidiariesService = new Mock<ISubsidiariesService>();
            _subsidiariesController = new SubsidiariesController(_subsidiariesService.Object, mapper, _departmentService.Object);
        }

        [Test]
        public async Task GetSubsidiaries_NoSubsidiaries_ReturnsEmptyResult()
        {
            _subsidiariesService.Setup(x => x.GetAllAsync()).ReturnsAsync(Array.Empty<HSubsidiaries>());

            var actual = await _subsidiariesController.GetSubsidiaries();

            Assert.That(actual, Is.Not.Null);
            var result = (actual.Result as OkObjectResult)?.Value as IReadOnlyCollection<SubsidiariesDto>;
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Empty);
        }

        [Test]
        public async Task GetSubsidiaries_HasMultipleSubsidiaries_ReturnsExpectedResult()
        {
            var collection = new[]
            {
                new HSubsidiaries() { Id = 1, Name = "Name1", Description = "Description1" },
                new HSubsidiaries() { Id = 2, Name = "Name2", Description = "Description2" }
            };

            _subsidiariesService.Setup(x => x.GetAllAsync()).ReturnsAsync(collection);

            var actual = await _subsidiariesController.GetSubsidiaries();

            Assert.That(actual, Is.Not.Null);
            var result = (actual.Result as OkObjectResult)?.Value as IReadOnlyCollection<SubsidiariesDto>;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.ElementAt(0).Id, Is.EqualTo(1));
            Assert.That(result.ElementAt(0).Name, Is.EqualTo("Name1"));
            Assert.That(result.ElementAt(0).Description, Is.EqualTo("Description1"));
            Assert.That(result.ElementAt(1).Id, Is.EqualTo(2));
            Assert.That(result.ElementAt(1).Name, Is.EqualTo("Name2"));
            Assert.That(result.ElementAt(1).Description, Is.EqualTo("Description2"));
        }

        [Test]
        public async Task AddSubsidiary_NoSpecifiedDepartmentExist_ReturnsBadStatusCode()
        {
            //No need to setup mock return value
            const int departmentId = 101;
            var dto = new NewSubsidiariesDto()
            {
                Name = "Name",
                Description = "Description",
                DepartmentId = departmentId
            };
            var actual = await _subsidiariesController.AddSubsidiary(dto);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.InstanceOf<BadRequestObjectResult>());

            //Почитать
            _subsidiariesService.Verify(s => s.AddAsync(It.IsAny<HSubsidiaries>()), Times.Never);
            _departmentService.Verify(s => s.GetByIdAsync(departmentId), Times.Exactly(1));
        }

        [Test]
        public async Task AddSubsidiary_SpecifiedDepartmentExist_ReturnsOkStatusCode()
        {
            // Arrange
            const int departmentId = 101;
            var newSubsidiaryDto = new NewSubsidiariesDto()
            {
                Name = "New Subsidiary",
                Description = "New Subsidiary Description",
                DepartmentId = departmentId
            };

            var department = new HDepartments
            {
                Id = departmentId,
                Name = "IT Department"
            };

            // Настройка мока для департамента
            _departmentService.Setup(x => x.GetByIdAsync(departmentId)).ReturnsAsync(department);

            // Act
            var result = await _subsidiariesController.AddSubsidiary(newSubsidiaryDto);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));

            // Проверка на вызов добавления дочерней компании с правильными данными
            _subsidiariesService.Verify(s => s.AddAsync(It.Is<HSubsidiaries>(subs =>
                subs.Name == newSubsidiaryDto.Name &&
                subs.Description == newSubsidiaryDto.Description &&
                subs.DepartmentId == newSubsidiaryDto.DepartmentId
            )), Times.Once);

            // Проверка, что GetByIdAsync вызван один раз
            _departmentService.Verify(s => s.GetByIdAsync(departmentId), Times.Once);
        }

    }
}
using AutoMapper;
using DocStation.Api;
using DocStation.Api.Controllers;
using DocStation.Api.Mapping;
using DocStation.Api.Services;
using DocStation.Data.Models;
using Moq;

//namespace DocStation.Api.Tests
//{
//    [TestFixture]
//    public class SubsidiariesControllerTests
//    {
//        private SubsidiariesController _subsidiariesController;
//        private Mock<ISubsidiariesService> _subsidiariesService;


//        [SetUp]


//        public void Setup()
//        {
//            var mockMapper = new MapperConfiguration(cfg =>
//            {
//                cfg.AddProfile(new SubsidiarisProfile()); 
//            });
//            var mapper = mockMapper.CreateMapper();

//            _subsidiariesService = new Mock<ISubsidiariesService>();
//            _subsidiariesController = new SubsidiariesController(_subsidiariesService.Object, mapper,de);
//        }

//        [Test]
//        public async Task GetSubsidiaries_NoSubsidiaries_ReturnsEmptyResult()
//        {
//            _subsidiariesService.Setup(x => x.GetAllAsync()).ReturnsAsync(Array.Empty<HSubsidiaries>());

//            var actual = await _subsidiariesController.GetSubsidiaries();

//            Assert.That(actual, Is.Not.Null);
//            Assert.That(actual, Is.Empty);
//        }

//        [Test]
//        public async Task GetSubsidiaries_HasMultipleSubsidiaries_ReturnsExpectedResult()
//        {
//            var collection = new[]
//            {
//                new HSubsidiaries() { Id = 1, Name = "Name1", Description = "Description1" },
//                new HSubsidiaries() { Id = 2, Name = "Name2", Description = "Description2" }
//            };

//            _subsidiariesService.Setup(x => x.GetAllAsync()).ReturnsAsync(collection);

//            var actual = await _subsidiariesController.GetSubsidiaries();

//            Assert.That(actual, Is.Not.Null);
//            Assert.That(actual.Count, Is.EqualTo(2));
//            Assert.That(actual.ElementAt(0).Id, Is.EqualTo(1));
//            Assert.That(actual.ElementAt(0).Name, Is.EqualTo("Name1"));
//            Assert.That(actual.ElementAt(0).Description, Is.EqualTo("Description1"));
//            Assert.That(actual.ElementAt(1).Id, Is.EqualTo(2));
//            Assert.That(actual.ElementAt(1).Name, Is.EqualTo("Name2"));
//            Assert.That(actual.ElementAt(1).Description, Is.EqualTo("Description2"));
//        }
//    }
//}
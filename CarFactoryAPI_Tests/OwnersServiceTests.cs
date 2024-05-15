using CarAPI.Entities;
using CarAPI.Models;
using CarAPI.Payment;
using CarAPI.Repositories_DAL;
using CarAPI.Services_BLL;
using CarFactoryAPI.Entities;
using CarFactoryAPI.Repositories_DAL;
using CarFactoryAPI_Tests.Stups;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace CarFactoryAPI_Tests
{
    public class OwnersServiceTests : IDisposable
    {
        private readonly ITestOutputHelper testOutputHelper;
        // Create Mock Of Dependencies
        Mock<ICarsRepository> carRepoMock;
        Mock<IOwnersRepository> OwnerRepoMock;
        Mock<ICashService> cashMock;

        // use fake object as a dependency
        OwnersService ownersService;

        public OwnersServiceTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
            // test setup
            testOutputHelper.WriteLine("Test setup");
            // Create Mock Of Dependencies
            carRepoMock = new();
            OwnerRepoMock = new();
            cashMock = new();

            // use fake object as a dependency
            ownersService = new OwnersService(
                carRepoMock.Object, OwnerRepoMock.Object, cashMock.Object);
        }
        public void Dispose()
        {
            // test clean up
            testOutputHelper.WriteLine("test clean up");
        }

        [Fact(Skip = "Fail due to fail in dependencies working on isolating Unit")]
        [Trait("Author", "Ali")]
        [Trait("Priorty", "2")]
        public void BuyCar_CarNotExist_NotExist()
        {

            // Arrange
            FactoryContext factoryContext = new FactoryContext();

            CarRepository carRepository = new CarRepository(factoryContext);
            OwnerRepository ownerRepository = new OwnerRepository(factoryContext);
            CashService cashService = new CashService();

            OwnersService ownersService = new OwnersService(carRepository, ownerRepository, cashService);

            BuyCarInput buyCarInput = new() { CarId = 100, OwnerId = 10, Amount = 5000 };

            // Act
            string result = ownersService.BuyCar(buyCarInput);

            // Assert
            Assert.Contains("n't exist", result);
        }

        [Fact]
        [Trait("Author", "Ahmed")]
        [Trait("Priorty", "5")]

        public void BuyCar_CarNotExist_NotExist2()
        {
            testOutputHelper.WriteLine("Test 1");
            // Arrange


            OwnersService ownersService = new OwnersService(new CarRepoStup(), new OwnerRepoStup(), new CashServiceStup());

            BuyCarInput buyCarInput = new() { CarId = 100, OwnerId = 10, Amount = 5000 };

            // Act
            string result = ownersService.BuyCar(buyCarInput);

            // Assert
            Assert.Contains("n't exist", result);
        }

        [Fact]
        [Trait("Author", "Ali")]
        [Trait("Priorty", "9")]
        public void BuyCar_CarwithOwner_Sold()
        {
            testOutputHelper.WriteLine("Test 2");

            // Arrange
            // Create Mock Of Dependencies
            //Mock<ICarsRepository> carRepoMock = new();
            //Mock<IOwnersRepository> OwnerRepoMock = new();
            //Mock<ICashService> cashMock = new();

            // Build the mock Data
            Car car = new Car() { Id = 10, Price = 1000, OwnerId = 5, Owner = new Owner() };

            // Setup the called methods
            carRepoMock.Setup(o => o.GetCarById(10)).Returns(car);

            //// use fake object as a dependency
            //OwnersService ownersService = new OwnersService(
            //    carRepoMock.Object, OwnerRepoMock.Object, cashMock.Object);

            BuyCarInput carInput = new() { CarId = 10, OwnerId = 10, Amount = 1000 };

            // Act
            string result = ownersService.BuyCar(carInput);

            // Assert
            Assert.Contains("sold", result);
        }


        [Fact]
        [Trait("Author", "Ahmed")]
        [Trait("Priorty", "9")]
        public void BuyCar_OwnerNotExist_NotExist()
        {
            testOutputHelper.WriteLine("Test 3");

            // Arrange

            // Build the mock Data
            Car car = new Car() { Id = 10, Price = 1000 };
            Owner owner = null;

            // Setup called methods
            carRepoMock.Setup(o => o.GetCarById(10)).Returns(car);
            OwnerRepoMock.Setup(o => o.GetOwnerById(100)).Returns(owner);

            BuyCarInput carInput = new() { CarId = 10, OwnerId = 100, Amount = 1000 };

            // Act
            string result = ownersService.BuyCar(carInput);

            // Assert
            Assert.Contains("n't exist", result);
        }

        [Fact]
        [Trait("Author", "shymaa")]
        [Trait("Priorty", "1")]
        public void BuyCar_HaveCar_Alreadyhavecar()
        {

            testOutputHelper.WriteLine("Test 4");

            // Arrange

            // Build the mock Data

            Car car = new Car() { Id = 10, Price = 1000 }; Owner owner = new Owner() { Id = 5, Car = new Car() };

            // Setup called methods

            carRepoMock.Setup(o => o.GetCarById(10)).Returns(car);
            OwnerRepoMock.Setup(o => o.GetOwnerById(5)).Returns(owner);

            BuyCarInput carInput = new()
            {
                CarId = 10,
                OwnerId = 5,
                Amount = 3
            };

            // Act

            string result = ownersService.BuyCar(carInput);

            // Assert

            Assert.Contains("Already have", result);
        }


        [Fact]
        [Trait("Author", "shymaa")]
        [Trait("Priorty", "5")]


        public void BuyCar_CheckPrice_Insufficient()
        {

            testOutputHelper.WriteLine("Test 5");

            // Arrange

            // Build the mock Data

            Car car = new Car() { Id = 10, Price = 10000 };
            Owner owner = new Owner() { Id = 8 };

            // Setup called methods

            carRepoMock.Setup(o => o.GetCarById(10)).Returns(car);
            OwnerRepoMock.Setup(o => o.GetOwnerById(8)).Returns(owner);

            BuyCarInput carInput = new()
            {
                CarId = 10,
                OwnerId = 8,
                Amount = 4
            };

            // Act

            string result = ownersService.BuyCar(carInput);

            // Assert

            Assert.Contains("Insufficient", result);
        }

        [Fact]
        [Trait("Author", "shymaa")]
        [Trait("Priorty", "15")]

        public void BuyCar_AssigntoOwner_SomethingWrong()
        {

            testOutputHelper.WriteLine("Test 6");

            // Arrange

            // Build the mock Data

            Car car = new Car() { Id = 10, Price = 10000 }; Owner owner = new Owner() { Id = 9 };

            // Setup called methods

            carRepoMock.Setup(o => o.GetCarById(10)).Returns(car); OwnerRepoMock.Setup(o => o.GetOwnerById(9)).Returns(owner);

            BuyCarInput carInput = new()
            {
                CarId = 10,
                OwnerId = 9,
                Amount = 4,
            };

            // Act

            string result = ownersService.BuyCar(carInput);

            // Assert

            Assert.Contains("Something went wrong", result);
        }
    }
}
using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibrary_shtest
{
    public class CarStoreTests
    {   // 6-Collection Asserts
        [Fact]
        public void AddCar_AddToyota_ListContainObject()
        {
            // Arrange
            CarStore carStore = new CarStore();
            Toyota toyota = new Toyota() { drivingMode = DrivingMode.Forward };
            BMW bMW = new BMW();

            // Act
            carStore.AddCar(toyota);

            //  Asserts
      
            Assert.NotEmpty(carStore.cars);

            Assert.Contains<Car>(toyota, carStore.cars);
          
        }
    }
}

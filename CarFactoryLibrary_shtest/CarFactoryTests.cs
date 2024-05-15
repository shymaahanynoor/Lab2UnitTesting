using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibrary_shtest
{
    public class CarFactoryTests
    {//4 Reference Asssert
        [Fact]
            public void NewCar_AskForAudi_null()
            {
                // Act
                Car? result = CarFactory.NewCar(CarTypes.Audi);

                // Assert
                Assert.Null(result);
               
            }

            [Fact]
            public void NewCar_AskForToyota_toyotaObject()
            {
                // Arrange
                Toyota toyota = new Toyota();

                // Act
                Car? result = CarFactory.NewCar(CarTypes.Toyota);

                //  Assert
                Assert.NotNull(result);
     
            
            }
        //5-Type Assert

            [Fact]
            public void NewCar_AskForBMW_BMWObject()
            {
                // Act
                Car? result = CarFactory.NewCar(CarTypes.BMW);

                // Type Assert
                Assert.IsType<BMW>(result);
                Assert.IsNotType<Toyota>(result);

            }

        // 7-Exception Assert
        [Fact]
            public void NewCar_AskForHonda_Exception()
            {

                // Assert
                Assert.Throws<NotImplementedException>(() =>
                {
                    // Act
                    Car? result = CarFactory.NewCar(CarTypes.Honda);
                });
              

            }
        }
    }

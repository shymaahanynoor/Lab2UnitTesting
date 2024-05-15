using CarFactoryLibrary;

namespace CarFactoryLibrary_shtest
{
    public class ToyotaTests
    {
        // 1- Boolean Assert
        [Fact]
        public void IsStopped_Velocity0_true()
        {
            // Arrange
            Toyota t = new Toyota();
            t.velocity = 0;

            // Act
            bool res = t.IsStopped();

            //Assert
            Assert.True(res);
        }

        [Fact]
        public void IsStopped_Velocity10_false()
        {
            // Arrange
            Toyota t = new Toyota();
            t.velocity = 10;

            // Act
            bool res = t.IsStopped();

            // Assert
            Assert.False(res);
        }


        //3-String Assert
        [Fact]
        public void GetDirection_DirectionBackward_Backward()
        {
            // Arrange
            Toyota t = new Toyota() { drivingMode = DrivingMode.Backward };

            // Act
            string res = t.GetDirection();

            // Assert
            Assert.Equal("Backward", res);

            Assert.StartsWith("B", res);
            Assert.EndsWith("rd", res);

            Assert.Contains("ck", res);
            Assert.DoesNotContain("x", res);


        }
    }
    }
    

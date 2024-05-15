using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibrary_shtest
{
    public class Cartests
    {  
        //2- Numeric Assert
        [Fact]
        public void Accelerate_velocity15_Range20to30()
        {
            // Arrange
            Toyota t = new Toyota() { velocity = 15 };
            BMW b = new BMW() { velocity = 15 };

            // Act
            t.Accelerate();
            b.Accelerate();

            //  Assert
            Assert.InRange(t.velocity, 20, 30);
            Assert.InRange(b.velocity, 20, 30);

            Assert.NotInRange(t.velocity, 80, 100);

        }
    
}
}

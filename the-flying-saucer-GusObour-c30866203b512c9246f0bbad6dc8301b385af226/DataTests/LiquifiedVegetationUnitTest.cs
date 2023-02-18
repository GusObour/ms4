using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for Liquified Vegetation
    /// </summary>
    public class LiquifiedVegetationUnitTest
    {
        #region Default Values
        /// <summary>
        /// Checks the default size of the drink
        /// </summary>
        [Fact]
        public void DefaultSizeOfDrink()
        {
            LiquifiedVegetation lv = new LiquifiedVegetation();
            Assert.Equal(ServingSize.Small, lv.Size);
        }
        /// <summary>
        /// Checks if the drinks ice default is set to true
        /// </summary>
        [Fact]
        public void CheckIfDrinkContainsIce()
        {
            LiquifiedVegetation lv = new LiquifiedVegetation();
            Assert.True(lv.Ice);
        }
        #endregion
        #region State Changes
        /// <summary>
        /// Tests the name of the drink
        /// </summary>
        /// <param name="ice">If the drink has ice</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void NameShouldAlwaysBeLiquifiedVegetation(bool ice)
        {
            LiquifiedVegetation lv = new LiquifiedVegetation();
            lv.Ice = ice;
            Assert.Equal("Liquified Vegetation", lv.Name);
        }
        /// <summary>
        /// Checks the price of the drink
        /// </summary>
        /// <param name="size">The size of the drink</param>
        /// <param name="price">The final price of the drink</param>
        [Theory]
        [InlineData(ServingSize.Small,1.00)]
        [InlineData(ServingSize.Medium, 1.50)]
        [InlineData(ServingSize.Large, 2.00)]
        public void LiquifiedVegetationPriceCHeck(ServingSize size, decimal price)
        {
            LiquifiedVegetation lv = new LiquifiedVegetation { Size = size };
            Assert.Equal(price, lv.Price);
        }
        /// <summary>
        /// Checks the amount of the calories in the drink
        /// </summary>
        /// <param name="size">The size of the drink</param>
        /// <param name="cals">The amount of calories in the drink</param>
        [Theory]
        [InlineData(ServingSize.Small, 72)]
        [InlineData(ServingSize.Medium, 144)]
        [InlineData(ServingSize.Large,216)]
        public void LiquifiedVegetationCalorieCheck(ServingSize size, uint cals)
        {
            LiquifiedVegetation lv = new LiquifiedVegetation { Size = size };
            Assert.Equal(cals, lv.Calories);
        }
        /// <summary>
        /// Checks the special instructions for the drink
        /// </summary>
        /// <param name="ice">If teh drink contains ice</param>
        /// <param name="instructions">The instructions for the drink</param>
        [Theory]
        [InlineData(true, new string[] { })]
        [InlineData(false, new string[] { "No Ice" })]
        public void LiquifiedVegetationSpecailInstructionsCheck(bool ice, string[] instructions)
        {
            LiquifiedVegetation lv = new LiquifiedVegetation { Ice = ice };
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, lv.SpecialInstructions);
            }
            Assert.Equal(instructions.Length, lv.SpecialInstructions.Count());
        }
        #endregion
    }
}

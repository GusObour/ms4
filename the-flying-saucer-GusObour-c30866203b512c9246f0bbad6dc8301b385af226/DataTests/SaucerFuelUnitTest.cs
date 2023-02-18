using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for Saucer Fuel
    /// </summary>
    public class SaucerFuelUnitTest
    {
        #region Default Values
        /// <summary>
        /// Checks the default size of the drink
        /// </summary>
        [Fact]
        public void DefaultSizeOfDrink()
        {
            SaucerFuel sf = new SaucerFuel();
            Assert.Equal(ServingSize.Small, sf.Size);
        }
        /// <summary>
        /// Checks if the drinks decaf default is set to false
        /// </summary>
        [Fact]
        public void CheckIfDrinkContainsDecaf()
        {
            SaucerFuel sf = new SaucerFuel();
            Assert.False(sf.Decaf);
        }
        /// <summary>
        /// Checks if the drinks cream default is set to false
        /// </summary>
        [Fact]
        public void CheckIfDrinkContainsCream()
        {
            SaucerFuel sf = new SaucerFuel();
            Assert.False(sf.Cream);
        }
        #endregion
        #region State Changes
        /// <summary>
        /// Checks the name of the drink
        /// </summary>
        /// <param name="decaf">If the drink is decaf</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void NameShouldAlwaysBeSaucerFuel(bool decaf)
        {
            SaucerFuel sf = new SaucerFuel() { Decaf= decaf };
            if (decaf) { Assert.Equal("Decaf Saucer Fuel", sf.Name); }
            else Assert.Equal("Saucer Fuel", sf.Name);
        }
        /// <summary>
        /// Checks the price of the drink
        /// </summary>
        /// <param name="size">The size of the drink</param>
        /// <param name="price">The final price of the drink</param>
        [Theory]
        [InlineData(ServingSize.Small, 1.00)]
        [InlineData(ServingSize.Medium, 1.50)]
        [InlineData(ServingSize.Large, 2.00)]
        public void SaucerFuelPriceCHeck(ServingSize size, decimal price)
        {
            SaucerFuel sf = new SaucerFuel { Size = size };
            Assert.Equal(price, sf.Price);
        }
        /// <summary>
        /// Checks the amount of the calories in the drink
        /// </summary>
        /// <param name="size">The size of the drink</param>
        /// <param name="cals">The amount of calories in the drink</param>
        /// <param name="cream">If the drinks contains cream</param>
        [Theory]
        [InlineData(ServingSize.Small,true, 1 + 29)]
        [InlineData(ServingSize.Medium,false, 2 + 0)]
        [InlineData(ServingSize.Large,true, 3 + 29)]
        public void SaucerFuelCalorieCheck(ServingSize size,bool cream, uint cals)
        {
            SaucerFuel sf = new SaucerFuel { Size = size, Cream = cream};
            Assert.Equal(cals, sf.Calories);
        }
        /// <summary>
        /// Checks the special instructions for the drink
        /// </summary>
        /// <param name="cream">If teh drink contains Decaf</param>
        /// <param name="instructions">The instructions for the drink</param>
        [Theory]
        [InlineData(true, new string[] {"With Cream" })]
        [InlineData(false, new string[] { })]
        public void SaucerFuelSpecailInstructionsCheck(bool cream, string[] instructions)
        {
            SaucerFuel sf = new SaucerFuel { Cream = cream };
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, sf.SpecialInstructions);
            }
            Assert.Equal(instructions.Length, sf.SpecialInstructions.Count());
        }
        #endregion
    }
}

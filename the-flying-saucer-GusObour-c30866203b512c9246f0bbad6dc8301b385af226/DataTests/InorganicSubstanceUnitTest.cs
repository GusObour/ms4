using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for Inorganic Substance
    /// </summary>
    public class InorganicSubstanceUnitTest
    {
        #region Default Values
        /// <summary>
        /// Checks the default size of the drink
        /// </summary>
        [Fact]
        public void DefaultSizeOfDrink()
        {
            InorganicSubstance isub = new InorganicSubstance();
            Assert.Equal(ServingSize.Small, isub.Size);
        }
        /// <summary>
        /// Checks if the drinks ice default is set to true
        /// </summary>
        [Fact]
        public void CheckIfDrinkContainsIce()
        {
            InorganicSubstance isub = new InorganicSubstance();
            Assert.True(isub.Ice);
        }
        #endregion
        #region State Changes
        /// <summary>
        /// Checks the name of the drink
        /// </summary>
        /// <param name="ice">If the drink contains ice</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void NameShouldAlwaysBeInorganicSubstance(bool ice)
        {
            InorganicSubstance isub = new InorganicSubstance() { Ice = ice };
            Assert.Equal("Inorganic Substance", isub.Name);
        }
        /// <summary>
        /// Checks the price of the drink
        /// </summary>
        /// <param name="size">The size of the drink</param>
        /// <param name="price">The final price of the drink</param>
        [Theory]
        [InlineData(ServingSize.Small, 0)]
        [InlineData(ServingSize.Medium, 0)]
        [InlineData(ServingSize.Large, 0)]
        public void InorganicSubstancePriceCHeck(ServingSize size, decimal price)
        {
            InorganicSubstance isub = new InorganicSubstance { Size = size };
            Assert.Equal(price, isub.Price);
        }
        /// <summary>
        /// Checks the amount of the calories in the drink
        /// </summary>
        /// <param name="size">The size of the drink</param>
        /// <param name="cals">The amount of calories in the drink</param>
        /// <param name="ice">If the drinks contains ice</param>
        [Theory]
        [InlineData(ServingSize.Small, true, 0)]
        [InlineData(ServingSize.Medium, false, 0)]
        [InlineData(ServingSize.Large, true, 0)]
        public void InorganicSubstanceCalorieCheck(ServingSize size, bool ice, uint cals)
        {
            InorganicSubstance isub = new InorganicSubstance { Size = size, Ice = ice };
            Assert.Equal(cals, isub.Calories);
        }
        /// <summary>
        /// Checks the special instructions for the drink
        /// </summary>
        /// <param name="ice">If teh drink contains Decaf</param>
        /// <param name="instructions">The instructions for the drink</param>
        [Theory]
        [InlineData(true, new string[] { })]
        [InlineData(false, new string[] { "No Ice" })]
        public void InorganicSubstanceSpecailInstructionsCheck(bool ice, string[] instructions)
        {
            InorganicSubstance isub = new InorganicSubstance { Ice = ice };
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, isub.SpecialInstructions);
            }
            Assert.Equal(instructions.Length, isub.SpecialInstructions.Count());
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the TakenBacon class
    /// </summary>
    public class TakenBaconUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that an unaltered Taken Bacon has 2 slices of bacon
        /// </summary>
        [Fact]
        public void DefaultCounteShouldBeTwoSlicesOfBacon()
        {
            TakenBacon tb = new();
            Assert.Equal(2u, tb.Count);
        }
        #endregion
        #region state changes
        /// <summary>
        /// This test verifies that the price of the Taken Bacon
        /// </summary>
        /// <param name="count">The slices of bacon</param>
        /// <param name="price">The price of the entree</param>
        [Theory]
        [InlineData(1, 1 * 1)]
        [InlineData(6, 1 * 6)]
        [InlineData(5, 1 * 5)]
        public void CheckPriceOfTakenBacon(uint count, decimal price)
        {
            TakenBacon tb = new();
            tb.Count = count;
            Assert.Equal(price, tb.Price);

        }
        /// <summary>
        /// This test checks that even as the Taken Bacon's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="count">The slices of bacon</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(6, 43 * 6)]
        [InlineData(5, 43 * 5)]
        [InlineData(2, 43 * 2)]
        [InlineData(4, 43 * 4)]
        [InlineData(3, 43 * 3)]
        [InlineData(7, 43 * 6)]
        public void CaloriesShouldBeCorrect(uint count,uint calories)
        {
            TakenBacon tb = new()
            {
                Count = count
            };
            Assert.Equal(calories, tb.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Taken Bacon
        /// </summary>
        /// <param name="count">The slices of bacon</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(6, new string[] { "This order contains 6 pieces of bacon" })]
        [InlineData(4, new string[] { "This order contains 4 pieces of bacon" })]
        [InlineData(2, new string[] {})]
        public void SpecialInstructionsRelfectsState(uint count, string[] instructions)
        {
            TakenBacon tb = new()
            {
                Count = count
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, tb.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, tb.SpecialInstructions.Count());
        }

        #endregion

    }
}

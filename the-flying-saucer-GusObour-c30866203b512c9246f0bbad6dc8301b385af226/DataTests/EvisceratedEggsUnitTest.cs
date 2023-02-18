using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFlyingSaucer.Data;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the EvisceratedEggs class
    /// </summary>
    public class Eviscerated_EggsUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that an unaltered Eviscerated Eggs style is over easy
        /// </summary>
        [Fact]
        public void DefaultEggStyleShouldBeOverEasy()
        {
            EvisceratedEggs ee = new();
            Assert.Equal(EggStyle.OverEasy, ee.Style);
        }
        /// <summary>
        /// Checks that an unaltered Eviscerated Eggs count is 2
        /// </summary>
        [Fact]
        public void DefaultCountOfEggsShouldBeTwo()
        {
            EvisceratedEggs ee = new();
            Assert.Equal(2u, ee.Count);
        }
        #endregion
        #region state changes
        /// <summary>
        /// This test verifies that the price of the eviscreated eggs
        /// </summary>
        /// <param name="count">The eggs</param>
        /// <param name="price">The price of the entree</param>
        [Theory]
        [InlineData(1, 1 * 1)]
        [InlineData(6, 1 * 6)]
        [InlineData(5, 1 * 5)]
        [InlineData(8, 1 * 6)]
        public void CheckPriceOfEvisceratedEggs(uint count, decimal price)
        {
            EvisceratedEggs ee = new();
            ee.Count = count;
            Assert.Equal(price, ee.Price);

        }
        /// <summary>
        /// This test checks that even as the Eviscerated Eggs state mutates, the calories reflect that state
        /// </summary>
        /// <param name="count">The eggs</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(6, 78 * 6)]
        [InlineData(5, 78 * 5)]
        [InlineData(2, 78 * 2)]
        [InlineData(4, 78 * 4)]
        [InlineData(3, 78 * 3)]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            EvisceratedEggs ee = new()
            {
                Count = count
            };
            Assert.Equal(calories, ee.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Eviscerated Eggs
        /// </summary>
        /// <param name="count">The number of eggs</param>
        /// <param name="egg">The style of egg</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(6, EggStyle.SoftBoiled, new string[] { "This order contains 6 eggs", "This order contains soft boiled eggs" })]
        [InlineData(4, EggStyle.HardBoiled, new string[] { "This order contains 4 eggs", "This order contains hard boiled eggs" })]
        [InlineData(2,EggStyle.Poached, new string[] { "This order contains poached eggs" })]
        [InlineData(5,EggStyle.Scrambled, new string[] { "This order contains 5 eggs", "This order contains scrambled eggs" })]
        [InlineData(2, EggStyle.OverEasy, new string[] { "This order contains over easy eggs" })]
        public void SpecialInstructionsRelfectsState(uint count, EggStyle egg, string[] instructions)
        {
            EvisceratedEggs ee = new()
            {
                Count = count,
                Style = egg
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, ee.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, ee.SpecialInstructions.Count());
        }

        #endregion

    }
}

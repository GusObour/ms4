using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the YoureToast class
    /// </summary>
    public class YoureToastUnitTest
    {
        #region default values
        /// <summary>
        /// Checks that an unaltered your're toast count is 2 by default
        /// </summary>
        [Fact]
        public void DefaultCountOfToastShouldBeTwo()
        {
            YouAreToast yt = new();
            Assert.Equal(2u, yt.Count);
        }
        #endregion
        #region state changes
        /// <summary>
        /// This test verifies that the price of the you're toast
        /// </summary>
        /// <param name="count">The toast</param>
        /// <param name="price">The price of the entree</param>
        [Theory]
        [InlineData(1, 1 * 1)]
        [InlineData(6, 1 * 6)]
        [InlineData(5, 1 * 5)]
        [InlineData(8, 1 * 8)]
        [InlineData(12, 1 * 12)]
        public void CheckPriceOfYouAreToast(uint count, decimal price)
        {
            YouAreToast yt = new();
            yt.Count = count;
            Assert.Equal(price, yt.Price);

        }
        /// <summary>
        /// This test checks that even as the you're toast state mutates, the calories reflect that state
        /// </summary>
        /// <param name="count">The toasts</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(6, 100 * 6)]
        [InlineData(5, 100 * 5)]
        [InlineData(2, 100 * 2)]
        [InlineData(4, 100 * 4)]
        [InlineData(3, 100 * 3)]
        [InlineData(12, 100 * 12)]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            YouAreToast yt = new()
            {
                Count = count
            };
            Assert.Equal(calories, yt.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the You're Toast
        /// </summary>
        /// <param name="count">The number of toast</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(6, new string[] { "This order contains 6 pieces of toast" })]
        [InlineData(4, new string[] { "This order contains 4 pieces of toast" })]
        [InlineData(2, new string[] { })]
        [InlineData(5, new string[] { "This order contains 5 pieces of toast" })]
        [InlineData(8, new string[] { "This order contains 8 pieces of toast" })]
        [InlineData(12, new string[] { "This order contains 12 pieces of toast" })]
        public void SpecialInstructionsRelfectsState(uint count, string[] instructions)
        {
            YouAreToast yt = new()
            {
                Count = count
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, yt.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, yt.SpecialInstructions.Count());
        }

        #endregion

    }
}

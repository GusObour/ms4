using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the MissingLinks class
    /// </summary>
    public class MissingLinkssUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that an unaltered missing links has 2 sausage links
        /// </summary>
        [Fact]
        public void DefaultCountShouldBeTwosSausageLinks()
        {
            MissingLinks ml = new();
            Assert.Equal(2u, ml.Count);
        }
        #endregion
        #region state changes
        /// <summary>
        /// This test verifies that the price of the missing links
        /// </summary>
        /// <param name="count">The links of sausage</param>
        /// <param name="price">The price of the entree</param>
        [Theory]
        [InlineData(1, 1 * 1)]
        [InlineData(6, 1 * 6)]
        [InlineData(5, 1 * 5)]
        [InlineData(8, 1 * 8)]
        public void CheckPriceOfMissingLinks(uint count, decimal price)
        {
            MissingLinks ml = new();
            ml.Count = count;
            Assert.Equal(price, ml.Price);

        }
        /// <summary>
        /// This test checks that even as the missing links state mutates, the calories reflect that state
        /// </summary>
        /// <param name="count">The links sausage</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(6, 391 * 6)]
        [InlineData(5, 391 * 5)]
        [InlineData(2, 391 * 2)]
        [InlineData(4, 391 * 4)]
        [InlineData(3, 391 * 3)]
        [InlineData(8, 391 * 8)]
        [InlineData(10, 391 * 8)]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            MissingLinks ml = new()
            {
                Count = count
            };
            Assert.Equal(calories, ml.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the missing links
        /// </summary>
        /// <param name="count">The number of sausage links</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(6, new string[] { "This order contains 6 links of sausage" })]
        [InlineData(4, new string[] { "This order contains 4 links of sausage" })]
        [InlineData(2, new string[] { })]
        [InlineData(8, new string[] { "This order contains 8 links of sausage" })]
        public void SpecialInstructionsRelfectsState(uint count, string[] instructions)
        {
            MissingLinks ml = new()
            {
                Count = count
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, ml.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, ml.SpecialInstructions.Count());
        }

        #endregion

    }
}

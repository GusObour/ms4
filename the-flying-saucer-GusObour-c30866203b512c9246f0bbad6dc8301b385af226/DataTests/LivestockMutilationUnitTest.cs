using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the LivestockMutilation class
    /// </summary>
    public class LivestockMutilationUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that an unaltered Livestock Mutilation has 3 biscuits
        /// </summary>
        [Fact]
        public void DefaultShouldBeTwoBiscuits()
        {
            LivestockMutilation lm = new();
            Assert.Equal(3u, lm.Biscuits);
        }

        /// <summary>
        /// Checks that a unaltered Livestock Mutilation is served with Gravy 
        /// </summary>
        [Fact]
        public void DefaultServedWithGravy()
        {
            LivestockMutilation lm = new();
            Assert.True(lm.Gravy);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the Livestock Mutilation's state mutates, the name does not change
        /// </summary>
        /// <param name="biscuits">The number of biscuits included</param>
        /// <param name="gravy">If the Livestock Mutilation will be served with Gravy</param>
        [Theory]
        [InlineData(6, true)]
        [InlineData(0, true)]
        [InlineData(12, true)]
        [InlineData(6, false)]
        [InlineData(3, true)]
        [InlineData(8, false)]
        [InlineData(11, true)]
        public void NameShouldAlwaysBeLivestockMutilation(uint biscuits, bool gravy)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = biscuits,
                Gravy = gravy
            };
            Assert.Equal("Livestock Mutilation", lm.Name);
        }

        /// <summary>
        /// This test verifies that a Livestock Mutilation's biscuits cannot exceed 8, and 
        /// if it is attempted, the biscuits will be set to 8.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetBiscuitsAboveEight()
        {
            LivestockMutilation lm = new();
            lm.Biscuits = 9;
            Assert.Equal(8u, lm.Biscuits);
        }
        /// <summary>
        /// This test verifies that the price of the Livestock Mutilation
        /// </summary>
        /// <param name="biscuits">The number of biscuits</param>
        /// <param name="price">The price of the entree</param>
        [Theory]
        [InlineData(3, 7.25)]
        [InlineData(6, 7.25 + (1.00 * (6 - 3)))]
        [InlineData(8, 7.25 + (1.00 * (8 - 3)))]
        public void CheckPriceOfLivestockMutilation(uint biscuits, decimal price)
        {
            LivestockMutilation lm = new();
            lm.Biscuits = biscuits;
            Assert.Equal(price, lm.Price);

        }
        /// <summary>
        /// This test checks that even as the Livestock Mutilation's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="biscuits">The number of biscuits included</param>
        /// <param name="gravy">If the Livestock Mutilation will be served with Gravy</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(6, true, 49 * 6 + 140)]
        [InlineData(0, true, 49 * 0 + 140)]
        [InlineData(5, true, 49 * 5 + 140)]
        [InlineData(8, true, 49 * 8 + 140)]
        [InlineData(4, false, 49 * 4 + 0)]
        [InlineData(3, true, 49 * 3 + 140)]
        [InlineData(7, false, 49 * 7 + 0)]
        public void CaloriesShouldBeCorrect(uint biscuits, bool gravy, uint calories)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = biscuits,
                Gravy = gravy
            };
            Assert.Equal(calories, lm.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Livestock Mutilation
        /// </summary>
        /// <param name="biscuits">The number of biscuits</param>
        /// <param name="gravy">If served with Gravy</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(3, true, new string[] { })]
        [InlineData(5, true, new string[] { "This order contains 5 biscuits" })]
        [InlineData(8, true, new string[] { "This order contains 8 biscuits" })]
        public void SpecialInstructionsRelfectsState(uint biscuits, bool gravy, string[] instructions)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = biscuits,
                Gravy = gravy
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, lm.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, lm.SpecialInstructions.Count());
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the CropCircle class
    /// </summary>
    public class CropCircleUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that a unaltered crashed saucer is served with Berries 
        /// </summary>
        [Fact]
        public void DefaultServedWithBerries()
        {
            CropCircle cc = new();
            Assert.True(cc.Berries);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the Crop Circle's state mutates, the name does not change
        /// </summary>
        /// <param name="Berries">If the Crop Circle will be served with Berries</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void NameShouldAlwaysBeCropCircle(bool Berries)
        {
            CropCircle cc = new()
            {
                Berries = Berries,
            };
            Assert.Equal("Crop Circle", cc.Name);
        }

        /// <summary>
        /// This test verifies that the price of the crop circle
        /// </summary>
        /// <param name="price">The price of the entree</param>
        [Theory]
        [InlineData(true, 2.00)]
        [InlineData(false, 2.00)]
        public void CheckPriceOfCropCircle(bool Berries, decimal price)
        {
            CropCircle cc = new()
            {
                Berries = Berries,
            };
            Assert.Equal(price, cc.Price);

        }
        /// <summary>
        /// This test checks that even as the Crop Circle's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="Berries">If the crop circle will be served with Berries</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(true, 158 + 89)]
        [InlineData(false, 158 + 0)]
        public void CaloriesShouldBeCorrect(bool Berries, uint calories)
        {
            CropCircle cc = new()
            {
                Berries = Berries
            };
            Assert.Equal(calories, cc.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Crop Circle
        /// </summary>
        /// <param name="Berries">If served with Berries</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, new string[] { })]
        [InlineData(false, new string[] {"Hold Berries"})]
        public void SpecialInstructionsRelfectsState(bool Berries, string[] instructions)
        {
            CropCircle cc = new()
            {
                Berries = Berries
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, cc.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, cc.SpecialInstructions.Count());
        }

        #endregion

    }
}

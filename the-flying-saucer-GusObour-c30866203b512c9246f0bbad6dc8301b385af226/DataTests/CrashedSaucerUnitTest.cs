using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCrashedSaucer.DataTests
{
    public class CrashedSaucerUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that an unaltered crashed saucer has 2 french toasts
        /// </summary>
        [Fact]
        public void DefaultStackSizeShouldBeTwoFrechToasts()
        {
            CrashedSaucer cs = new();
            Assert.Equal(2u, cs.StackSize);
        }

        /// <summary>
        /// Checks that a unaltered crashed saucer is served with syrup 
        /// </summary>
        [Fact]
        public void DefaultServedWithSyrup()
        {
            CrashedSaucer cs = new();
            Assert.True(cs.Syrup);
        }
        /// <summary>
        /// Checks that a unaltered crashed saucer is served with butter 
        /// </summary>
        [Fact]
        public void DefaultServedWithButter()
        {
            CrashedSaucer cs = new();
            Assert.True(cs.Butter);
        }


        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the Crashed Saucer's state mutates, the name does not change
        /// </summary>
        /// <param name="stackSize">The number of french toasts included</param>
        /// <param name="syrup">If the crashed saucer will be served with syrup</param>
        /// <param name="butter">If the crashed saucer rwill be served with butter</param>
        [Theory]
        [InlineData(6, true, true)]
        [InlineData(0, true, true)]
        [InlineData(12, true, true)]
        [InlineData(6, true, false)]
        [InlineData(6, false, false)]
        [InlineData(3, true, false)]
        [InlineData(8, false, false)]
        [InlineData(11, true, true)]
        public void NameShouldAlwaysBeCrashedSaucer(uint stackSize, bool syrup, bool butter)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                Butter = butter,
            };
            Assert.Equal("Crashed Saucer", cs.Name);
        }

        /// <summary>
        /// This test verifies that a Crashed Saucer's StackSize cannot exceed 6, and 
        /// if it is attempted, the StackSize will be set to 6.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetStackSizeAboveSix()
        {
            CrashedSaucer cs = new();
            cs.StackSize = 7;
            Assert.Equal(6u, cs.StackSize);
        }
        /// <summary>
        /// This test verifies that the price of the crashed saucer
        /// </summary>
        /// <param name="stackSize">The number of french toasts</param>
        /// <param name="price">The price of the entree</param>
        [Theory]
        [InlineData(2,6.45)]
        [InlineData(4, 6.45 + (1.50 * (4-2)))]
        [InlineData(6, 6.45 + (1.50 * (6 - 2)))]
        public void CheckPriceOfCrashedSaucer(uint stackSize, decimal price)
        {
            CrashedSaucer cs = new();
            cs.StackSize = stackSize;
            Assert.Equal(price, cs.Price);

        }
        /// <summary>
        /// This test checks that even as the Crashed Saucer's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="stackSize">The number of panacakes included</param>
        /// <param name="syrup">If the crashed saucer will be served with syrup</param>
        /// <param name="butter">If the crashed saucer will be served with butter</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(6, true, true, 149 * 6 + 52 + 35)]
        [InlineData(0, true, true, 149 * 0 + 52 + 35)]
        [InlineData(5, true, true, 149 * 5 + 52 + 35)]
        [InlineData(2, true, false, 149 * 2 + 52 + 0)]
        [InlineData(4, false, false, 149 * 4 + 0 + 0)]
        [InlineData(3, true, false, 149 * 3 + 52 + 0)]
        [InlineData(7, false, false, 149 * 6 + 0 + 0)]
        public void CaloriesShouldBeCorrect(uint stackSize, bool syrup, bool butter, uint calories)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                Butter = butter
            };
            Assert.Equal(calories, cs.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Crsahed Saucer
        /// </summary>
        /// <param name="stackSize">The number of panacakes</param>
        /// <param name="syrup">If served with syrup</param>
        /// <param name="butter">If served with butter</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(6, true, true, new string[] {"This order contains 6 french toasts"})]
        [InlineData(4, true, true, new string[] {"This order contains 4 french toasts"})]
        public void SpecialInstructionsRelfectsState(uint stackSize, bool syrup, bool butter, string[] instructions)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                Butter = butter
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, cs.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, cs.SpecialInstructions.Count());
        }

        #endregion

    }
}

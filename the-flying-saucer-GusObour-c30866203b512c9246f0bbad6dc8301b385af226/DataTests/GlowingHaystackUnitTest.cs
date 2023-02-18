using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the GlowingHaystack class
    /// </summary>
    public class GlowingHaystackUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that a unaltered Glowing Haystack is served with Green Chile Sauce 
        /// </summary>
        [Fact]
        public void DefaultServedWithGreenChileSauce()
        {
            GlowingHaystack gh = new();
            Assert.True(gh.GreenChileSauce);
        }
        /// <summary>
        /// Checks that a unaltered Glowing Haystack is served with Sour Cream 
        /// </summary>
        [Fact]
        public void DefaultServedWithSourCream()
        {
            GlowingHaystack gh = new();
            Assert.True(gh.SourCream);
        }

        /// <summary>
        /// Checks that a unaltered Glowing Haystack is served with Tomatoes 
        /// </summary>
        [Fact]
        public void DefaultServedWithTomatoes()
        {
            GlowingHaystack gh = new();
            Assert.True(gh.Tomatoes);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the Glowing Haystack's state mutates, the name does not change
        /// </summary>
        /// <param name="GreenChileSauce">If the Glowing Haystack will be served with GreenChileSauce</param>
        /// <param name="SourCream">If the Glowing Haystack will be served with Sour Cream</param>
        /// <param name="Tomatoes">If the Glowing Haystack will be served with Tomatoes</param>
        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, false, true)]
        [InlineData(true, true, false)]
        [InlineData(false, true, false)]
        [InlineData(true, false, false)]
        [InlineData(false, false, true)]
        [InlineData(false, false, false)]
        public void NameShouldAlwaysBeGlowingHaystack(bool GreenChileSauce, bool SourCream, bool Tomatoes)
        {
            GlowingHaystack gh = new()
            {
                GreenChileSauce = GreenChileSauce,
                SourCream = SourCream,
                Tomatoes = Tomatoes
            };
            Assert.Equal("Glowing Haystack", gh.Name);
        }

        /// <summary>
        /// This test verifies that the price of the Glowing Haystack
        /// </summary>
        /// <param name="GreenChileSauce">If the Glowing Haystack will be served with GreenChileSauce</param>
        /// <param name="SourCream">If the Glowing Haystack will be served with Sour Cream</param>
        /// <param name="Tomatoes">If the Glowing Haystack will be served with Tomatoes</param>
        [Theory]
        [InlineData(true, true, true, 2.00)]
        [InlineData(true, false, true, 2.00)]
        [InlineData(true, true, false, 2.00)]
        [InlineData(false, true, false, 2.00)]
        [InlineData(true, false, false, 2.00)]
        [InlineData(false, false, true, 2.00)]
        [InlineData(false, false, false, 2.00)]
        public void CheckPriceOfGlowingHaystack(bool GreenChileSauce, bool SourCream, bool Tomatoes, decimal price)
        {
            GlowingHaystack gh = new()
            {
                GreenChileSauce = GreenChileSauce,
                SourCream = SourCream,
                Tomatoes = Tomatoes
            };
            Assert.Equal(price, gh.Price);

        }
        /// <summary>
        /// This test checks that even as the Glowing Haystack's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="GreenChileSauce">If the Glowing Haystack will be served with GreenChileSauce</param>
        /// <param name="SourCream">If the Glowing Haystack will be served with Sour Cream</param>
        /// <param name="Tomatoes">If the Glowing Haystack will be served with Tomatoes</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(true, true, true, 470 + 15 + 23 + 22)]
        [InlineData(true, false, true, 470 + 15 + 0+ 22)]
        [InlineData(true, true, false, 470 + 15 + 23 + 0)]
        [InlineData(false, true, false, 470 + 0 + 23 + 0)]
        [InlineData(true, false, false, 470 + 15 + 0 + 0)]
        [InlineData(false, false, true, 470 + 0 + 0 + 22)]
        [InlineData(false, false, false, 470 + 0 + 0 + 0)]
        public void CaloriesShouldBeCorrect(bool GreenChileSauce, bool SourCream, bool Tomatoes, uint calories)
        {
            GlowingHaystack gh = new()
            {
                GreenChileSauce = GreenChileSauce,
                SourCream = SourCream,
                Tomatoes = Tomatoes
            };
            Assert.Equal(calories, gh.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Glowing Haystack
        /// </summary>
        /// <param name="GreenChileSauce">If the Glowing Haystack will be served with GreenChileSauce</param>
        /// <param name="SourCream">If the Glowing Haystack will be served with Sour Cream</param>
        /// <param name="Tomatoes">If the Glowing Haystack will be served with Tomatoes</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true,true, true, new string[] {})]
        [InlineData(false,true, true, new string[] { "Hold green chile sauce" })]
        [InlineData(true, false, true, new string[] { "Hold sour cream" })]
        [InlineData(true, true, false, new string[] { "Hold tomatoes" })]
        [InlineData(true, false, false, new string[] { "Hold sour cream", "Hold tomatoes" })]
        public void SpecialInstructionsRelfectsState(bool GreenChileSauce, bool SourCream, bool Tomatoes, string[] instructions)
        {
            GlowingHaystack gh = new()
            {
                GreenChileSauce = GreenChileSauce,
                SourCream = SourCream,
                Tomatoes = Tomatoes
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, gh.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, gh.SpecialInstructions.Count());
        }

        #endregion

    }
}

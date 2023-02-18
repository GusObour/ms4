namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the FlyingSaucer class
    /// </summary>
    public class FlyingSaucerUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that an unaltered Flying Saucer has 6 panacakes
        /// </summary>
        [Fact]
        public void DefaultStackSizeShouldBeSixPancakes()
        {
            FlyingSaucer fs = new();
            Assert.Equal(6u, fs.StackSize);
        }

        /// <summary>
        /// Checks that a unaltered Flying Saucer is served with syrup 
        /// </summary>
        [Fact]
        public void DefaultServedWithSyrup()
        {
            FlyingSaucer fs = new();
            Assert.True(fs.Syrup);
        }

        /// <summary>
        /// Checks that an unaltered Flying Saucer is served with berries
        /// </summary>
        [Fact]
        public void DefaultServedWithBerries()
        {
            FlyingSaucer fs = new();
            Assert.True(fs.Berries);
        }

        /// <summary>
        /// Checks that an unmodified Flying Saucer is served with whipped cream
        /// </summary>
        [Fact]
        public void DefaultServedWithWhippedCream()
        {
            FlyingSaucer fs = new();
            Assert.True(fs.WhippedCream);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the Flying Saucer's state mutates, the name does not change
        /// </summary>
        /// <param name="stackSize">The number of panacakes included</param>
        /// <param name="syrup">If the Flying Saucer will be served with syrup</param>
        /// <param name="whippedCream">If the Flying Saucer will be served with whipped cream</param>
        /// <param name="berries">If the Flying Saucer will be served with berries</param>
        [Theory]
        [InlineData(6, true, true, true)]
        [InlineData(0, true, true, true)]
        [InlineData(12, true, true, true)]
        [InlineData(6, true, false, true)]
        [InlineData(6, false, false, true)]
        [InlineData(3, true, false, false)]
        [InlineData(8, false, false, false)]
        [InlineData(11, true, true, false)]
        public void NameShouldAlwaysBeFlyingSaucer(uint stackSize, bool syrup, bool whippedCream, bool berries)
        {
            FlyingSaucer fs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                WhippedCream = whippedCream,
                Berries = berries
            };
            Assert.Equal("Flying Saucer", fs.Name);
        }

        /// <summary>
        /// This test verifies that a Flying Saucer's StackSize cannot exceed 12, and 
        /// if it is attempted, the StackSize will be set to 12.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetStackSizeAboveTwelve()
        {
            FlyingSaucer fs = new();
            fs.StackSize = 13;
            Assert.Equal(12u, fs.StackSize);
        }

        /// <summary>
        /// This test verifies that the price of the Flying Saucer
        /// </summary>
        /// <param name="stackSize">The number of pancakes</param>
        /// <param name="price">The price of the entree</param>
        [Theory]
        [InlineData(6, 8.50)]
        [InlineData(8, 8.50 + (0.75 * (8 - 6)))]
        [InlineData(10, 8.50 + (0.75 * (10 - 6)))]
        [InlineData(12, 8.50 + (0.75 * (12 - 6)))]
        public void CheckPriceOfFlyingSaucer(uint stackSize, decimal price)
        {
            FlyingSaucer fs = new();
            fs.StackSize = stackSize;
            Assert.Equal(price, fs.Price);

        }

        /// <summary>
        /// This test checks that even as the Flying Saucer's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="stackSize">The number of panacakes included</param>
        /// <param name="syrup">If the Flying Saucer will be served with syrup</param>
        /// <param name="whippedCream">If the Flying Saucer will be served with whipped cream</param>
        /// <param name="berries">If the Flying Saucer will be served with berries</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        [Theory]
        [InlineData(6, true, true, true, 64 * 6 + 32 + 414 + 89)]
        [InlineData(0, true, true, true, 64 * 0 + 32 + 414 + 89)]
        [InlineData(12, true, true, true, 64 * 12 + 32 + 414 + 89)]
        [InlineData(6, true, false, true, 64 * 6 + 32 + 0 + 89)]
        [InlineData(6, false, false, true, 64 * 6 + 0 + 0 + 89)]
        [InlineData(3, true, false, false, 64 * 3 + 32 + 0 + 0)]
        [InlineData(8, false, false, false, 64 * 8 + 0 + 0 + 0)]
        [InlineData(11, true, true, false, 64 * 11 + 32 + 414 + 0)]
        public void CaloriesShouldBeCorrect(uint stackSize, bool syrup, bool whippedCream, bool berries, uint calories)
        {
            FlyingSaucer fs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                WhippedCream = whippedCream,
                Berries = berries
            };
            Assert.Equal(calories, fs.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Flying Saucer
        /// </summary>
        /// <param name="stackSize">The number of panacakes</param>
        /// <param name="syrup">If served with syrup</param>
        /// <param name="whippedCream">If served with whipped cream</param>
        /// <param name="berries">If served with berries</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(6, true, true, true, new string[] {})]
        [InlineData(4, true, true, true, new string[] {"4 Pancakes"})]
        public void SpecialInstructionsRelfectsState(uint stackSize, bool syrup, bool whippedCream, bool berries, string[] instructions)
        {
            FlyingSaucer fs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                WhippedCream = whippedCream,
                Berries = berries
            };
            // Check that all expected special instructions exist
            foreach(string instruction in instructions)
            {
                Assert.Contains(instruction, fs.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, fs.SpecialInstructions.Count());
        }

        #endregion

    }
}
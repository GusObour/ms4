using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the OuterOmelette class
    /// </summary>
    public class OuterOmeletteUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that a unaltered Outer Omelette is served with CheddarCheese 
        /// </summary>
        [Fact]
        public void DefaultServedWithCheddarCheese()
        {
            OuterOmelette oo = new();
            Assert.True(oo.CheddarCheese);
        }
        /// <summary>
        /// Checks that a unaltered Outer Omelette is served with Peppers 
        /// </summary>
        [Fact]
        public void DefaultServedWithPeppers()
        {
            OuterOmelette oo = new();
            Assert.True(oo.Peppers);
        }
        /// <summary>
        /// Checks that a unaltered Outer Omelette is served with Mushrooms 
        /// </summary>
        [Fact]
        public void DefaultServedWithMushrooms()
        {
            OuterOmelette oo = new();
            Assert.True(oo.Mushrooms);
        }
        /// <summary>
        /// Checks that a unaltered Outer Omelette is served with Tomatoes 
        /// </summary>
        [Fact]
        public void DefaultServedWithTomatoes()
        {
            OuterOmelette oo = new();
            Assert.True(oo.Tomatoes);
        }
        /// <summary>
        /// Checks that a unaltered Outer Omelette is served with Onions 
        /// </summary>
        [Fact]
        public void DefaultServedWithOnions()
        {
            OuterOmelette oo = new();
            Assert.True(oo.Onions);
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the Outer Omelette's state mutates, the name does not change
        /// </summary>
        /// <param name="CheddarCheese">If the Outer Omelette will be served with CheddarCheese</param>
        /// <param name="Peppers">If the Outer Omelette will be served with Peppers</param>
        /// <param name="Mushrooms">If the Outer Omelette will be served with Mushrooms</param>
        /// <param name="Tomatoes">If the Outer Omelette will be served with Tomatoes</param>
        /// <param name="Onions">If the Outer Omelette will be served with Onions</param>
        [Theory]
        [InlineData(true,true, true, true, true)]
        [InlineData(false,true, true,true, true )]
        [InlineData(false, false, true, true,true)]
        [InlineData(false, false, false, true, true)]
        [InlineData(false, false, false, false, true)]
        [InlineData(false, false, false, false, false)]
        [InlineData(false, true, false, true, false)]
        [InlineData(true, false, true, true, true)]
        public void NameShouldAlwaysBeLivestockMutilation(bool CheddarCheese, bool Peppers, bool Mushrooms, bool Tomatoes, bool Onions)
        {
            OuterOmelette oo = new()
            {
                CheddarCheese = CheddarCheese,
                Peppers = Peppers,
                Mushrooms = Mushrooms,
                Tomatoes = Tomatoes,
                Onions = Onions

                
            };
            Assert.Equal("Outer Omelette", oo.Name);
        }

        /// <summary>
        /// This test verifies that the price of the Outer Omelette
        /// </summary>
        /// <param name="price">The price of the entree</param>
        [Theory]
        [InlineData(7.45)]
        public void CheckPriceOfOuterOmelette(decimal price)
        {
            OuterOmelette oo = new();
            Assert.Equal(price, oo.Price);

        }
        /// <summary>
        /// This test checks that even as the Outer Omelette's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="CheddarCheese">If the Outer Omelette will be served with CheddarCheese</param>
        /// <param name="Peppers">If the Outer Omelette will be served with Peppers</param>
        /// <param name="Mushrooms">If the Outer Omelette will be served with Mushrooms</param>
        /// <param name="Tomatoes">If the Outer Omelette will be served with Tomatoes</param>
        /// <param name="Onions">If the Outer Omelette will be served with Onions</param>
        /// <param name="calories">The expected calories of the Outer Omelette</param>
        [Theory]
        [InlineData(true, true, true, true, true, 94 + 113 +24 + 4 + 22 + 22)]
        [InlineData(false, true, true, true, true, 94 + 0 + 24 + 4 + 22 + 22)]
        [InlineData(false, false, true, true, true, 94 + 0 + 0 + 4 + 22 + 22)]
        [InlineData(false, false, false, true, true, 94 + 0 + 0 + 0 + 22 + 22)]
        [InlineData(false, false, false, false, true, 94 + 0 + 0 + 0 + 0 + 22)]
        [InlineData(false, false, false, false, false, 94 + 0 + 0 + 0 + 0 + 0)]
        [InlineData(true, false, true, true, true, 94 + 113 + 0 + 4 + 22 + 22)]
        [InlineData(true, true, false, false, true, 94 + 113 + 24 + 0 + 0 + 22)]
        public void CaloriesShouldBeCorrect(bool CheddarCheese, bool Peppers, bool Mushrooms, bool Tomatoes, bool Onions, uint calories)
        {
            OuterOmelette oo = new()
            {
                CheddarCheese = CheddarCheese,
                Peppers = Peppers,
                Mushrooms = Mushrooms,
                Tomatoes = Tomatoes,
                Onions = Onions
            };
            Assert.Equal(calories, oo.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Outer Omelette
        /// </summary>
        /// <param name="CheddarCheese">If the Outer Omelette will be served with CheddarCheese</param>
        /// <param name="Peppers">If the Outer Omelette will be served with Peppers</param>
        /// <param name="Mushrooms">If the Outer Omelette will be served with Mushrooms</param>
        /// <param name="Tomatoes">If the Outer Omelette will be served with Tomatoes</param>
        /// <param name="Onions">If the Outer Omelette will be served with Onions</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, true, true, true, true, new string[] { })]
        [InlineData(false, true, true, true, true, new string[] {"Hold Cheddar Cheese"})]
        [InlineData(false, false, false, false, true, new string[] {"Hold Cheddar Cheese", "Hold Peppers", "Hold Mushrooms", "Hold Tomatoes" })]
        public void SpecialInstructionsRelfectsState(bool CheddarCheese, bool Peppers, bool Mushrooms, bool Tomatoes, bool Onions, string[] instructions)
        {
            OuterOmelette oo = new()
            {
                CheddarCheese = CheddarCheese,
                Peppers = Peppers,
                Mushrooms = Mushrooms,
                Tomatoes = Tomatoes,
                Onions = Onions
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, oo.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, oo.SpecialInstructions.Count());
        }

        #endregion

    }
}

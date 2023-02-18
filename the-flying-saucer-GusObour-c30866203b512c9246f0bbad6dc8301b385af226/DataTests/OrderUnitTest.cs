using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// A mock menu item for testing
    /// </summary>
    internal class MockMenuItem : IMenuItem
    {
        /// <summary>
        /// Gets the name of the menu item
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets teh description of the menu item 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets the price of the menu item
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Gets the calories of the menu item
        /// </summary>
        public uint Calories { get; set; }
        /// <summary>
        /// Gets teh special instruction for the menu item
        /// </summary>
        public IEnumerable<string> SpecialInstructions { get; set; }
    }
    /// <summary>
    /// Unit tests for the order class
    /// </summary>
    public class OrderUnitTest
    {
        /// <summary>
        /// Tests the subtotal on an order
        /// </summary>
        [Fact]
        public void SubtotalShouldReflectItemPrices()
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price = 1.00m});
            order.Add(new MockMenuItem() { Price = 2.50m});
            order.Add(new MockMenuItem() { Price = 3.00m});
            Assert.Equal(6.50m, order.Subtotal);
            
        }
        /// <summary>
        /// Checks the amount of items in the order
        /// </summary>
        [Fact]
        public void CheckCountOfOrder()
        {
            Order order = new Order();
            order.Add(new MockMenuItem() {});
            order.Add(new MockMenuItem() {});
            order.Add(new MockMenuItem() {});
            Assert.Equal(3, order.Count);

        }
        /// <summary>
        /// Checks the tax of the order
        /// </summary>
        [Fact]
        public void CheckTax()
        {
            Order order = new Order { TaxRate = 9.9m };
            order.Add(new MockMenuItem() { Price = 1.00m });
            Order.Equals(order.Subtotal * order.TaxRate, order.Tax);
        }
        /// <summary>
        /// Checks if the order contains an item
        /// </summary>
        [Fact]
        public void ContainsItem()
        {
            Order order = new Order();
            MockMenuItem item = new MockMenuItem();
            order.Add(item);
            Assert.Contains(item, order);
        }
        /// <summary>
        /// Checks if an item was removed
        /// </summary>
        [Fact]
        public void RemoveItem()
        {
            Order order = new Order();
            MockMenuItem item = new MockMenuItem();
            order.Add(item);
            Assert.True(order.Remove(item));
        }
    }
}

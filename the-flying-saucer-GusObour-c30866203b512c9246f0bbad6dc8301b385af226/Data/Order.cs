using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// implementation of the icollection interface using the IMenuItem interface 
    /// </summary>
    public class Order : ICollection<IMenuItem>
    {
        /// <summary>
        /// A private collection to hold the menu items
        /// </summary>
        private List<IMenuItem> _items = new List<IMenuItem>();
        /// <summary>
        /// Adds a new menu item to the collection
        /// </summary>
        /// <param name="item">The menu item</param>
        public void Add(IMenuItem item) { _items.Add(item); }
        /// <summary>
        /// Removes all menu items from the collection
        /// </summary>
        public void Clear() { _items.Clear(); }
        /// <summary>
        /// Checks if a menu item in within the collection
        /// </summary>
        /// <param name="item">The menu item</param>
        /// <returns>True if the collection contains the menu item, else false if it doesn't</returns>
        public bool Contains(IMenuItem item) { return _items.Contains(item); }
        /// <summary>
        /// Copies the menu items int the collection starting a specfic index into an array
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="arrayIndex">The starting point</param>
        public void CopyTo(IMenuItem[] array, int arrayIndex) { _items.CopyTo(array, arrayIndex); }
        /// <summary>
        /// Returns the nunber of menu items in the collection
        /// </summary>
        public int Count { get { return _items.Count; } }
        /// <summary>
        /// Check is the collection is read-only, in this case always false
        /// </summary>
        public bool IsReadOnly { get { return false; } }
        /// <summary>
        /// Removes a menu item from te collection. returns true if item was removed else false
        /// </summary>
        /// <param name="item">The menu item</param>
        /// <returns>true if the item was removed else false</returns>
        public bool Remove(IMenuItem item) { return _items.Remove(item); }
        /// <summary>
        /// Returns an enumerator thats used to irterate over the collection
        /// </summary>
        /// <returns>a enumerator</returns>
        public IEnumerator<IMenuItem> GetEnumerator() { return _items.GetEnumerator(); }
        /// <summary>
        /// Method that gets the enumerator
        /// </summary>
        /// <returns>a enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        /// <summary>
        /// Gets the total price of all the menu items in the order before tax
        /// </summary>
        public decimal Subtotal
        {
            get
            {
                decimal total = 0;
                foreach(IMenuItem item in _items)
                {
                    total += item.Price;
                }
                return total;
            }
        }
        /// <summary>
        /// gets and sets the sales tax rate
        /// </summary>
        public decimal TaxRate { get; set; }
        /// <summary>
        /// Gets the tax of the order
        /// </summary>
        public decimal Tax { get { return Subtotal * TaxRate; } }
        /// <summary>
        /// The total cost of the order after tax
        /// </summary>
        public decimal Total { get { return Subtotal + Tax; } }
    }
}

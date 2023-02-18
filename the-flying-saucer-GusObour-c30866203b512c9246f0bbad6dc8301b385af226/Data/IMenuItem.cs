using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Interface for the menu items
    /// </summary>
    public interface IMenuItem
    {
        /// <summary>
        /// Gets the name of the menu item
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Gets the description of the menu item
        /// </summary>
        string Description { get; }
        /// <summary>
        /// Gets the price of the menu item 
        /// </summary>
        decimal Price { get; }
        /// <summary>
        /// Gets teh calories of the menu item
        /// </summary>
        uint Calories { get; }
        /// <summary>
        /// Gets the special instructions of the menu item
        /// </summary>
        IEnumerable<string> SpecialInstructions { get; }

    }
}

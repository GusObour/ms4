using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// An abstract class representing a drink menu item
    /// </summary>
    public abstract class Drink : IMenuItem
    {
        /// <summary>
        /// Gets the name of the entree
        /// </summary>
        public abstract string Name { get; }
        /// <summary>
        /// Gets the description of the entree
        /// </summary>
        public abstract string Description { get; }
        /// <summary>
        /// Gets the size of the drink
        /// </summary>
        public abstract ServingSize Size { get; set; }
        /// <summary>
        /// Gets the price of the entree
        /// </summary>
        public abstract decimal Price { get; }
        /// <summary>
        /// Gets the calories for the entree
        /// </summary>
        public abstract uint Calories { get; }
        /// <summary>
        /// Gets the special instructions for the entree
        /// </summary>
        public abstract IEnumerable<string> SpecialInstructions { get; }
    }
}

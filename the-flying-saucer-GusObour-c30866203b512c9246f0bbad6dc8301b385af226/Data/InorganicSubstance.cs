using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Hold the properties of the drink
    /// </summary>
    public class InorganicSubstance : Drink, IMenuItem
    {
        /// <summary>
        /// Gets the name of the drink
        /// </summary>
        public override string Name { get; } = "Inorganic Substance";
        /// <summary>
        /// Gets the description of the drink
        /// </summary>
        public override string Description { get; } = "A cold glass of ice water";
        /// <summary>
        /// The default size of the drink
        /// </summary>
        private ServingSize _size = ServingSize.Small;
        /// <summary>
        /// Gets and sets the serving size of the drink
        /// </summary>
        public override ServingSize Size
        {
            get { return _size; }
            set { _size = value; }
        }
        /// <summary>
        /// If the drink contains ice, default to true
        /// </summary>
        public bool Ice { get; set; } = true;
        /// <summary>
        /// Gets the price of the drink
        /// </summary>
        public override decimal Price { get { return 0m; }}
        /// <summary>
        /// Gets the calories of the drink
        /// </summary>
        public override uint Calories { get { return 0u; }}
        /// <summary>
        /// Gets the special instructions for the drink
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!Ice) instructions.Add($"No Ice");
                return instructions;
            }
        }
    }
}

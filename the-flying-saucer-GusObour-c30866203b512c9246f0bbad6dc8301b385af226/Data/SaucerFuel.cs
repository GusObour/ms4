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
    public class SaucerFuel : Drink, IMenuItem
    {
        /// <summary>
        /// Gets the name of the drink
        /// </summary>
        public override string Name
        {
            get
            {
                if (Decaf) return "Decaf Saucer Fuel";
                else return "Saucer Fuel";
            }
        }
        /// <summary>
        /// Gets the description of the drink
        /// </summary>
        public override string Description { get; } = "A steaming cup of coffee";
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
        /// If the drink is decaf, default to false
        /// </summary>
        public bool Decaf { get; set; } = false;
        /// <summary>
        /// If the drink contains cream, default to false
        /// </summary>
        public bool Cream { get; set; } = false;
        /// <summary>
        /// Gets the price of the drink depending on the size of the drink
        /// </summary>
        public override decimal Price 
        {
            get
            {
                if (_size == ServingSize.Small) return 1.00m;
                else if (_size == ServingSize.Medium) return 1.50m;
                else return 2.00m;
            }
        }
        /// <summary>
        /// Gets the calories of the drink depending on the size of the drink
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cals = 0;
                if (_size == ServingSize.Small) cals += 1u;
                else if (_size == ServingSize.Medium) cals += 2u;
                else  cals += 3u;
                if (Cream) cals += 29;
                return cals;

            }
        }
        /// <summary>
        /// Gets the special instructions for the drink
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (Cream) instructions.Add($"With Cream");
                return instructions;
            }
        }
    }
}

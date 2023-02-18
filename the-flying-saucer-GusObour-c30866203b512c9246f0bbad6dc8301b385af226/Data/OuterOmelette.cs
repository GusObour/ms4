using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Contains the properties that make up the entree
    /// </summary>
    public class OuterOmelette : Entree,IMenuItem
    {
        /// <summary>
        /// The name of the entree
        /// </summary>
        public override string Name { get; } = "Outer Omelette";
        /// <summary>
        /// The description of the entree
        /// </summary>
        public override string Description { get; } = "A fully loaded Omelette";
        /// <summary>
        /// Indicates if the customer wants cheddar cheese
        /// </summary>
        public bool CheddarCheese { get; set; } = true;
        /// <summary>
        /// Indicates if the customer wants peppers
        /// </summary>
        public bool Peppers { get; set; } = true;
        /// <summary>
        /// Indicates if the customer wants mushrooms
        /// </summary>
        public bool Mushrooms { get; set; } = true;
        /// <summary>
        /// Indicates if the customer wants tomatoes
        /// </summary>
        public bool Tomatoes { get; set; } = true;
        /// <summary>
        /// Indicates if the customer wants onions 
        /// </summary>
        public bool Onions { get; set; } = true;
        /// <summary>
        /// The price of the Outer Omelette
        /// </summary>
        public override decimal Price { get; } = 7.45m;
        /// <summary>
        /// The amout of calories in a Outer Omelette
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cals = 94u;
                if (CheddarCheese) cals += 113u;
                if (Peppers) cals += 24u;
                if (Mushrooms) cals += 4u;
                if (Tomatoes) cals += 22u;
                if (Onions) cals += 22u;
                return cals;
            }
        }
        /// <summary>
        /// Special instructions for the preparation of the Outer Omelette
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (!CheddarCheese) instructions.Add("Hold Cheddar Cheese");
                if (!Peppers) instructions.Add("Hold Peppers");
                if (!Mushrooms) instructions.Add("Hold Mushrooms");
                if (!Tomatoes) instructions.Add("Hold Tomatoes");
                if (!Onions) instructions.Add("Hold Onions");
                return instructions;
            }
        }
    }
}

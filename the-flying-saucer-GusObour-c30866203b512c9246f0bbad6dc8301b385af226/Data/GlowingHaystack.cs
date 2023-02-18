using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Hold the properites of the side
    /// </summary>
    public class GlowingHaystack : Side,IMenuItem
    {
        /// <summary>
        /// The name of the side
        /// </summary>
        public override string Name { get; } = "Glowing Haystack";
        /// <summary>
        /// The description of the side
        /// </summary>
        public override string Description { get; } = "Hash browns smothered in green chile sauce, sour cream, and topped with tomatoes";
        /// <summary>
        /// Indicates if the customer wants green chile sauce
        /// </summary>
        public bool GreenChileSauce { get; set; } = true;
        /// <summary>
        /// Indicates if the customer wants sour cream
        /// </summary>
        public bool SourCream { get; set; } = true;
        /// <summary>
        /// Indicates if the customer wants sour cream
        /// </summary>
        public bool Tomatoes { get; set; } = true;
        /// <summary>
        /// The price of the glowing haystack
        /// </summary>
        public override decimal Price { get; } = 2.00m;
        /// <summary>
        /// The amount of calories in the glowing Haystack
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cals = 470u;
                if (GreenChileSauce) cals += 15;
                if (SourCream) cals += 23u;
                if (Tomatoes) cals += 22u;
                return cals;
            }
        }
        /// <summary>
        ///Special instructions for the preparation of the glowing Haystack
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!GreenChileSauce) instructions.Add("Hold green chile sauce");
                if (!SourCream) instructions.Add("Hold sour cream");
                if (!Tomatoes) instructions.Add("Hold tomatoes");
                return instructions;
            }
        }
    }
}

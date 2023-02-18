using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Holds the properties of the side
    /// </summary>
    public class CropCircle : Side,IMenuItem
    {
        /// <summary>
        /// The name of the side
        /// </summary>
        public override string Name { get; } = "Crop Circle";
        /// <summary>
        /// The description of the side
        /// </summary>
        public override string Description { get; } = "Oatmeal topped with mixed berries";
        /// <summary>
        /// Indicates if the customer wants berries 
        /// </summary>
        public bool Berries { get; set; } = true;
        /// <summary>
        /// The price of the crop circle
        /// </summary>
        public override decimal Price { get; } = 2.00m;
        /// <summary>
        /// The amount of calories in the crop circle
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cals = 158u;
                if (Berries) cals += 89u;
                return cals;
            }
        }
        /// <summary>
        /// Special instructions for the preparation of the crop circle
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!Berries) instructions.Add("Hold Berries");
                return instructions;
            }
        }

    }
}

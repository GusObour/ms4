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
    public class TakenBacon : Side,IMenuItem
    {
        /// <summary>
        /// The name of the side
        /// </summary>
        public override string Name { get; } = "Taken Bacon";
        /// <summary>
        /// The description of the side
        /// </summary>
        public override string Description { get; } = "Crispy strips of bacon";
        /// <summary>
        /// The default number of bacon
        /// </summary>
        private uint _count = 2;
        /// <summary>
        /// Indicates the number of bacon
        /// </summary>
        public uint Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value <= 6 & value >= 1)
                {
                    _count = value;
                }
                else
                {
                    _count = 6;
                }
            }
        }
        /// <summary>
        /// Indicaties the price of the taken bacon
        /// </summary>
        public override decimal Price { get { return _count * 1m; } }
        /// <summary>
        /// The amount of calories in the taken bacon
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cals = 43u * _count;
                return cals;
            }
        }
        /// <summary>
        /// Special instructions for the preparation of the taken bacon
        /// </summary>
        public  override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (_count != 2) instructions.Add($"This order contains {_count} pieces of bacon");
                return instructions;
            }
        }
    }
}

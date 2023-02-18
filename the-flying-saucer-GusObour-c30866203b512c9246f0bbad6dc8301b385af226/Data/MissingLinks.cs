using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Holds the properties of the side
    /// </summary>
    public class MissingLinks : Side,IMenuItem
    {
        /// <summary>
        /// The name of the side
        /// </summary>
        public override string Name { get; } = "Missing Links";
        /// <summary>
        /// The description of the side
        /// </summary>
        public override string Description { get; } = "Sizzling pork sausage links";
        /// <summary>
        /// The default number of links
        /// </summary>
        private uint _count = 2;
        /// <summary>
        /// Indicates the number of links
        /// </summary>
        public uint Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value <= 8 & value >= 1)
                {
                    _count = value;
                }
                else
                {
                    _count = 8;
                }
            }
        }
        /// <summary>
        /// Indicaties the price of the missing links
        /// </summary>
        public override decimal Price { get { return _count * 1m; } }
        /// <summary>
        /// The amount of calories in the missing links
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cals = 391u * _count;
                return cals;
            }
        }
        /// <summary>
        /// Special instructions for the preparation of the missing links
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (_count != 2) instructions.Add($"This order contains {_count} links of sausage");
                return instructions;
            }
        }
    }
}

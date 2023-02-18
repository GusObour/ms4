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
    public class YouAreToast : Side,IMenuItem
    {
        /// <summary>
        /// The name of the side
        /// </summary>
        public override string Name { get; } = "You're Toast";
        /// <summary>
        /// The description of the side
        /// </summary>
        public override string Description { get; } = "Texas toast";
        /// <summary>
        /// The default number of toast
        /// </summary>
        private uint _count = 2;
        /// <summary>
        /// Indicates the number of toast
        /// </summary>
        public uint Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value <= 12 & value >= 1)
                {
                    _count = value;
                }
                else
                {
                    _count = 12;
                }
            }
        }
        /// <summary>
        /// Indicaties the price of the missing toast
        /// </summary>
        public override decimal Price { get { return _count * 1m; } }
        /// <summary>
        /// The amount of calories in the missing toast
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cals = 100u * _count;
                return cals;
            }
        }
        /// <summary>
        /// Special instructions for the preparation of the missing toast
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (_count != 2) instructions.Add($"This order contains {_count} pieces of toast");
                return instructions;
            }
        }
    }
}

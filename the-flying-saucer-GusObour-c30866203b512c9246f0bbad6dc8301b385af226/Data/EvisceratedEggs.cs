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
    public class EvisceratedEggs : Side,IMenuItem
    {
        /// <summary>
        /// The name of the side
        /// </summary>
        public override string Name { get; } = "Eviscerated Eggs";
        /// <summary>
        /// The description of the side
        /// </summary>
        public override string Description { get; } = "Eggs prepared the way you like";
        /// <summary>
        /// Contains the style of the eggs
        /// </summary>
        public EggStyle Style { get; set; } = EggStyle.OverEasy;
        /// <summary>
        /// The default number of eggs
        /// </summary>
        private uint _count = 2;
        /// <summary>
        /// Indicates the number of eggs
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
        /// Indicaties the price of the eviscerated eggs
        /// </summary>
        public override decimal Price { get { return _count * 1m; } }
        /// <summary>
        /// The amount of calories in the eviscerated eggs
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cals = 78u * _count;
                return cals;
            }
        }
        /// <summary>
        /// Special instructions for the preparation of the eviscerated eggs
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (_count != 2) instructions.Add($"This order contains {_count} eggs");
                if (Style == EggStyle.HardBoiled) instructions.Add("This order contains hard boiled eggs");
                if (Style == EggStyle.SunnySideUp) instructions.Add("This order contains sunny side up eggs");
                if (Style == EggStyle.SoftBoiled) instructions.Add("This order contains soft boiled eggs");
                if (Style == EggStyle.OverEasy) instructions.Add("This order contains over easy eggs");
                if (Style == EggStyle.Scrambled) instructions.Add("This order contains scrambled eggs");
                if (Style == EggStyle.Poached) instructions.Add("This order contains poached eggs");
                return instructions;
            }
        }
    }
}

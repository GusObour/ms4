using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Contains the properties that make up the entree
    /// </summary>
    public class CrashedSaucer : Entree,IMenuItem
    {
        /// <summary>
        /// The name of the entree
        /// </summary>
        public override string Name { get; } = "Crashed Saucer";
        /// <summary>
        /// The description of the entree
        /// </summary>
        public override string Description { get; } = "A stack of crispy french toast smothered in srup and topped with a pat of butter";
        /// <summary>
        /// Defulat number of stack of french toasts
        /// </summary>
        private uint _stackSize = 2;
        /// <summary>
        /// The number of french toasts
        /// </summary>
        public uint StackSize
        {
            get
            {
                return _stackSize;
            }
            set
            {
                if (value <= 6) _stackSize = value;
                else _stackSize = 6;
            }
        }
        /// <summary>
        /// Indicates if the customer wants syrup
        /// </summary>
        public bool Syrup { get; set; } = true;
        /// <summary>
        /// Indicates if the customer wants butter
        /// </summary>
        public bool Butter { get; set; } = true;
        /// <summary>
        /// The price of the Crashed Saucer
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal cost = 6.45m;
                if (_stackSize > 2) cost += 1.5m * (_stackSize - 2);
                return cost;
            }
        }
        /// <summary>
        /// The amout of calories in a Crashed Saucer 
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cals = 149u * StackSize;
                if (Syrup) cals += 52u;
                if (Butter) cals += 35u;
                return cals;
            }
        }
        /// <summary>
        /// Special instructions for the preparation of this FlyingSaucer
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (_stackSize != 2) instructions.Add($"This order contains {_stackSize} french toasts");
                if (!Butter) instructions.Add("Hold Butter");
                if (!Syrup) instructions.Add("HOld Syrup");
                return instructions;
            }
        }
    }
}

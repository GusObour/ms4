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
    public class LivestockMutilation : Entree,IMenuItem
    {
        /// <summary>
        /// The  name on the entree
        /// </summary>
        public override string Name { get; } = "Livestock Mutilation";
        /// <summary>
        /// The discription of the entree
        /// </summary>
        public override string Description { get; } = "A hearty serving of biscuits, smothered in sausage-laden gravy.";
        /// <summary>
        /// normal order of biscuits
        /// </summary>
        private uint _numBiscuits = 3;
        /// <summary>
        /// Gets the number of biscuits 
        /// </summary>
        public uint Biscuits
        {
            get
            {
                return _numBiscuits;
            }
            set
            {
                if(value <= 8)
                {
                    _numBiscuits = value;
                }
                else
                {
                    _numBiscuits = 8;
                }
            }
        }
        /// <summary>
        /// If the customer wants gravy
        /// </summary>
        public bool Gravy { get; set; } = true;
        /// <summary>
        /// Gets the price of the entree
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal price = 7.25m;
                if (_numBiscuits > 3) price += 1m * (_numBiscuits - 3);
                return price;
            }

        }
        /// <summary>
        /// Gets the calories of the Livestock Mutilation
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cals = 49u * _numBiscuits;
                if (Gravy) cals += 140u;
                return cals;
            }
        }
        /// <summary>
        /// The details of the Livestock Mutilation
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();
                if (_numBiscuits != 3) instructions.Add($"This order contains {_numBiscuits} biscuits");
                if (!Gravy) instructions.Add("Hold Gravy");
                return instructions;
            }
        }
    }
}

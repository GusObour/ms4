namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Contains the properties that make up the entree
    /// </summary>
    public class FlyingSaucer : Entree,IMenuItem
    {
        /// <summary>
        /// The name of the FlyingSaucer instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Flying Saucer";

        /// <summary>
        /// The description of the FlyingSaucer instance
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description => "A stack of six pancakes, smothered in rich maple syrup, and topped with mixed berries and whipped cream.";

        /// <summary>
        /// The private backing field for the StackSize property
        /// </summary>
        private uint _stackSize = 6;

        /// <summary>
        /// The number of panacakes in this instance of a Flying Saucer
        /// </summary>
        /// <remarks>
        /// Note the set limits the stack size to a maximum of 12 pancakes
        /// </remarks>
        public uint StackSize { 
            get 
            { 
                return _stackSize; 
            }
            set
            {
                if (value <= 12)
                {
                    _stackSize = value;
                }
                else
                {
                    _stackSize = 12;
                }
            }
        }

        /// <summary>
        /// If the FyingSaucer instance is served with maple syrup
        /// </summary>
        /// <remarks>
        /// Here we have an autoproperty with both getter and setter, 
        /// and a default value
        /// </remarks>
        public bool Syrup { get; set; } = true;

        /// <summary>
        /// If the FlyingSaucer instance is served with whipped cream
        /// </summary>
        public bool WhippedCream { get; set; } = true;

        /// <summary>
        /// If the FlyingSaucer instance is served with berries
        /// </summary>
        public bool Berries { get; set; } = true;

        /// <summary>
        /// The price of the FlyingSaucer instance
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal price = 8.50m;
                if(_stackSize > 6) price += .75m * (_stackSize - 6);
                return price;
            }
        }

        /// <summary>
        /// The calories of the FlyingSaucer instance
        /// </summary>
        /// <remarks>
        /// This is a get-only property whose value is derived from the other properties of the class.
        /// </remarks>
        public override uint Calories
        {
            get
            {
                uint calories = 64u * StackSize;
                if (Syrup) calories += 32u;
                if (WhippedCream) calories += 414u;
                if (Berries) calories += 89u;
                return calories;
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
                if (StackSize != 6) instructions.Add($"{StackSize} Pancakes");
                if (!Syrup) instructions.Add("Hold Syrup");
                if (!WhippedCream) instructions.Add("Hold Whipped Cream");
                if (!Berries) instructions.Add("Hold Berries");
                return instructions;
            }
        }

    }
}
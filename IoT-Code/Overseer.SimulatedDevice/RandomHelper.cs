using System;

namespace Overseer.SimulatedDevice
{
    /// <summary>
    /// Helper class for random boolean value.
    /// </summary>
    /// <seealso cref="System.Random" />
    public class RandomHelper : Random
    {
        private uint _boolBits;

        public RandomHelper() : base() { }
        public RandomHelper(int seed) : base(seed) { }

        public bool NextBoolean()
        {
            _boolBits >>= 1;
            if (_boolBits <= 1) _boolBits = (uint)~this.Next();
            return (_boolBits & 1) == 0;
        }
    }
}
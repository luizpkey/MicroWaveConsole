using System;

namespace MicroWave.Exceptions
{
    internal class PowerException : InvalidCastException
    {
        public PowerException() { }
        public override string ToString()
        {
            return "Range for power should be 1 to 10";
        }
    }
}

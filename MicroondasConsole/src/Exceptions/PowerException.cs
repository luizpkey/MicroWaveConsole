using System;

namespace MicroWave.Exceptions
{
    internal class PowerException : InvalidCastException
    {
        public PowerException() { }
        public override string ToString()
        {
            return "Potência deve ser definida entre 1 e 10";
        }
    }
}

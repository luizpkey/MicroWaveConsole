using System;

namespace MicroWave.Exceptions
{
    internal class TimerException: InvalidCastException
    {
        string MessageError;
        public TimerException( string message ) { 
           MessageError = message;
        }
        public override string ToString()
        {
            return MessageError;
        }
    }
}

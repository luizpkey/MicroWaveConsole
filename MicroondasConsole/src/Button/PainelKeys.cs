using MicroWaveConsole.Keys;
using System;

namespace MicroWaveConsole.Action
{
    class PainelKeys:IAction
    {
        protected string Title;
        public PainelKeys( string title )
        {
            this.Title = title;
        }

        public MicroWaveKeys Call()
        {
            throw new NotImplementedException();
        }

        public string GetTitle()
        {
            return this.Title;
        }

        public override string ToString()
        {
            return " " + this.Title + " ";
        }
    }
}

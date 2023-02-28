using MicroWaveConsole.Keys;
using System;

namespace MicroWaveConsole.Action
{
    class PainelKeys:IAction
    {
        protected string _title;
        public PainelKeys( string title )
        {
            this._title = title;
        }

        public MicroWaveKeys Call()
        {
            throw new NotImplementedException();
        }

        public string GetTitle()
        {
            return this._title;
        }

        public override string ToString()
        {
            return " " + this._title + " ";
        }
    }
}

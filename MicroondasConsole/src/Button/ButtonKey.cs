using MicroWaveConsole.Keys;

namespace MicroWaveConsole.Action
{
    class ButtonKey : IAction
    {
        protected string _title;
        protected MicroWaveKeys _keyBinding; 
        public ButtonKey( string title, MicroWaveKeys key )
        {
            this._title = title;
            this._keyBinding = key;
        }
        public MicroWaveKeys Call()
        {
            return this._keyBinding;
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

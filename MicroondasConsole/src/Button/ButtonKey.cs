using System;
using MicroWaveConsole.Action;
using MicroWaveConsole.Keys;

namespace MicroWaveConsole.Action
{
    class ButtonKey : IAction
    {
        protected string Title;
        protected MicroWaveKeys KeyBinding; 
        public ButtonKey( string title, MicroWaveKeys key )
        {
            this.Title = title;
            this.KeyBinding = key;
        }
        public MicroWaveKeys Call()
        {
            return this.KeyBinding;
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

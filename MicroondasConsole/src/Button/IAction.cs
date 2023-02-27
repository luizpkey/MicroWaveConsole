using MicroWaveConsole.Keys;
using System;

namespace MicroWaveConsole.Action;

interface IAction
{
    abstract MicroWaveKeys Call();
}

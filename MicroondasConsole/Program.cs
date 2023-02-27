// See https://aka.ms/new-console-template for more information
using MicroWaveConsole;
using MicroWaveConsole.Keys;
using MicroWave.Operations;

Routines runner = new Routines();

ConsoleKeyInfo keypress;

do
{

    runner.PainelRefresh();
    keypress = Console.ReadKey();

    switch (keypress.Key)
    {
        case ConsoleKey.Enter:
            {
                runner.OkPress();
                break;
            }
        case ConsoleKey.Escape:
            {
                runner.CancelPress();
                break;
            }
        case ConsoleKey.NumPad0:
        case ConsoleKey.D0:
            {
                runner.NumpadKeyPress(MicroWaveKeys.Numpad0);
                break;
            }
        case ConsoleKey.NumPad1:
        case ConsoleKey.D1:
            {
                runner.NumpadKeyPress(MicroWaveKeys.Numpad1);
                break;
            }
        case ConsoleKey.NumPad2:
        case ConsoleKey.D2:
            {
                runner.NumpadKeyPress(MicroWaveKeys.Numpad2);
                break;
            }
        case ConsoleKey.NumPad3:
        case ConsoleKey.D3:
            {
                runner.NumpadKeyPress(MicroWaveKeys.Numpad3);
                break;
            }
        case ConsoleKey.NumPad4:
        case ConsoleKey.D4:
            {
                runner.NumpadKeyPress(MicroWaveKeys.Numpad4);
                break;
            }
        case ConsoleKey.NumPad5:
        case ConsoleKey.D5:
            {
                runner.NumpadKeyPress(MicroWaveKeys.Numpad5);
                break;
            }
        case ConsoleKey.NumPad6:
        case ConsoleKey.D6:
            {
                runner.NumpadKeyPress(MicroWaveKeys.Numpad6);
                break;
            }
        case ConsoleKey.NumPad7:
        case ConsoleKey.D7:
            {
                runner.NumpadKeyPress(MicroWaveKeys.Numpad7);
                break;
            }
        case ConsoleKey.NumPad8:
        case ConsoleKey.D8:
            {
                runner.NumpadKeyPress(MicroWaveKeys.Numpad8);
                break;
            }
        case ConsoleKey.NumPad9:
        case ConsoleKey.D9:
            {
                runner.NumpadKeyPress(MicroWaveKeys.Numpad9);
                break;
            }
        case ConsoleKey.OemPlus:
            {
                runner.PowerPress();
                break;
            }
    }
}
while (keypress.Key != ConsoleKey.X);
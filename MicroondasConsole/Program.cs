// See https://aka.ms/new-console-template for more information
using MicroWaveConsole;
using MicroWaveConsole.Keys;
using MicroWave.Operations;

Routines runner = new Routines();
MicroWaveOperation microOperation = null;

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
        case ConsoleKey.F2:
            {

                microOperation = new MicroWaveOperation(180,
                                                      7,
                                                      "Observar o barulho de estouros do milho,\r\n"+
                                                      "caso houver um intervalo de mais de 10 segundos entre\r\n"+
                                                      "um estouro e outro, interrompa o aquecimento\r\n");
                runner.setMicroOperation(microOperation);
                break;
            }
        case ConsoleKey.F3:
            {
                microOperation = new MicroWaveOperation(300,
                                                        5,
                                                       "Cuidado com aquecimento de líquidos, o choque\r\n"+
                                                       "térmico aliado ao movimento do recipiente\r\n"+
                                                       "pode causar fervura imediata causando risco de queimaduras.");
                runner.setMicroOperation(microOperation);
                break;
            }
        case ConsoleKey.F4:
            {
                microOperation = new MicroWaveOperation(840,
                                                        4,
                                                        "Interrompa o processo na metade e vire o conteúdo com\r\n"+
                                                        "a parte de baixo para cima para o descongelamento uniforme.");
                runner.setMicroOperation(microOperation);
                break;
            }
        case ConsoleKey.F5:
            {
                microOperation = new MicroWaveOperation(480,
                                                        7,
                                                        "Interrompa o processo na metade e vire o conteúdo com a parte\r\n"+
                                                        "de baixo para cima para o descongelamento uniforme.");
                runner.setMicroOperation(microOperation);
                break;
            }
        case ConsoleKey.F6:
            {
                microOperation = new MicroWaveOperation(480,
                                                        9,
                                                        "Deixe o recipiente destampado e em casos de plástico, cuidado\r\n"+
                                                        "ao retirar o recipiente pois o mesmo pode perder resistência\r\n"+
                                                        "em altas temperaturas.");
                runner.setMicroOperation(microOperation);
                break;
            }
    }
}
while (keypress.Key != ConsoleKey.X);
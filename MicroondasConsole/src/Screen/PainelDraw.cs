using MicroWave;
using MicroWaveConsole.Action;
using MicroWaveConsole.Keys;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace MicroWaveConsole.Device
{
    public static class PainelDraw
    {

        public static void Draw(List<string> lightPainel, string messageProcess, string power)
        {
            Console.WriteLine(" ");
            Console.Clear();

            StringBuilder sb = new StringBuilder();
            sb.Append(lightPainel[0]);
            sb.Append(lightPainel[1]);
            sb.Append(':');
            sb.Append(lightPainel[2]);
            sb.Append(lightPainel[3]);
            sb.Append(power.PadLeft(15));

            List<string> lines = new List<string>();
            lines.Add("    [F2] Pipoca        > Alimento: Pipoca(de micro - ondas) ");
            lines.Add("    [F3] Leite         > Alimento: Leite                    ");
            lines.Add("    [F4] Carnes de boi > Alimento: Carne em pedaço ou fatias");
            lines.Add("    [F5] Frango        > Alimento: Frango(qualquer corte)   ");
            lines.Add("    [F6] Feijão        > Alimento: Feijão congelado         ");
            lines.Add("    [F7] Programavel   > ...");
            lines.Add("    [+]  Potencia      > Ajuste a potência");
            lines.Add("    [x]  Encerra o programa");

            Console.WriteLine(sb.ToString().PadLeft(5));
            List<IAction> listButton = CreateListKeys();

            for (int i = 0; i < listButton.Count; i++)
            {
                Console.Write(listButton[i].ToString());
                if (((i + 1) % 3).Equals(0))
                {
                    Console.WriteLine(lines[0] );
                    lines.RemoveAt(0);
                }
            }

            StringBuilder sbMessage = new StringBuilder();
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(messageProcess);
            Console.WriteLine(" ");
        }
        private static List<IAction> CreateListKeys()
        {
            List<IAction> listButton = new List<IAction> { };
            listButton.Add(new ButtonKey("F2".PadLeft(6), MicroWaveKeys.F2));// as keys não estão sendo utilizadas neste escopo
            listButton.Add(new ButtonKey("F3".PadLeft(6), MicroWaveKeys.F3));
            listButton.Add(new ButtonKey("F4".PadLeft(6), MicroWaveKeys.F4));
            listButton.Add(new ButtonKey("F5".PadLeft(6), MicroWaveKeys.F5));
            listButton.Add(new ButtonKey("F6".PadLeft(6), MicroWaveKeys.F6));
            listButton.Add(new ButtonKey("F7".PadLeft(6), MicroWaveKeys.F7));
            listButton.Add(new ButtonKey("1".PadLeft(6), MicroWaveKeys.Numpad1));
            listButton.Add(new ButtonKey("2".PadLeft(6), MicroWaveKeys.Numpad2));
            listButton.Add(new ButtonKey("3".PadLeft(6), MicroWaveKeys.Numpad3));
            listButton.Add(new ButtonKey("4".PadLeft(6), MicroWaveKeys.Numpad4));
            listButton.Add(new ButtonKey("5".PadLeft(6), MicroWaveKeys.Numpad5));
            listButton.Add(new ButtonKey("6".PadLeft(6), MicroWaveKeys.Numpad6));
            listButton.Add(new ButtonKey("7".PadLeft(6), MicroWaveKeys.Numpad7));
            listButton.Add(new ButtonKey("8".PadLeft(6), MicroWaveKeys.Numpad8));
            listButton.Add(new ButtonKey("9".PadLeft(6), MicroWaveKeys.Numpad9));
            listButton.Add(new ButtonKey("Enter".PadLeft(6), MicroWaveKeys.Numpad0));
            listButton.Add(new ButtonKey("0".PadLeft(6), MicroWaveKeys.Numpad0));
            listButton.Add(new ButtonKey("ESC".PadLeft(6), MicroWaveKeys.Cancel));
            listButton.Add(new ButtonKey("+".PadLeft(6), MicroWaveKeys.Power));
            listButton.Add(new ButtonKey(" ".PadLeft(6), MicroWaveKeys.Cancel));
            listButton.Add(new ButtonKey("x".PadLeft(6), MicroWaveKeys.Cancel));
            listButton.Add(new ButtonKey(" ".PadLeft(6), MicroWaveKeys.Cancel));
            listButton.Add(new ButtonKey(" ".PadLeft(6), MicroWaveKeys.Cancel));
            listButton.Add(new ButtonKey(" ".PadLeft(6), MicroWaveKeys.Cancel));
            return listButton;
        }
    }
}

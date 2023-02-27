using MicroWave;
using MicroWaveConsole.Action;
using MicroWaveConsole.Keys;
using System;
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

            Console.WriteLine(sb.ToString().PadLeft(5));
            List<IAction> listButton = CreateListKeys();

            for (int i = 0; i < listButton.Count; i++)
            {
                Console.Write(listButton[i].ToString());
                if (((i + 1) % 3).Equals(0))
                {
                    Console.WriteLine();
                }
            }

            StringBuilder sbMessage = new StringBuilder();
            Console.WriteLine(messageProcess);
            Console.WriteLine(" ");
        }
        private static List<IAction> CreateListKeys()
        {
            List<IAction> listButton = new List<IAction> { };
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
            listButton.Add(new ButtonKey("+".PadLeft(6), MicroWaveKeys.Pow));
            listButton.Add(new ButtonKey("x".PadLeft(6), MicroWaveKeys.Cancel));
            return listButton;
        }
    }
}

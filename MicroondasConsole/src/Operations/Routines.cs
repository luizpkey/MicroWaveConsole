using MicroWave.Exceptions;
using MicroWaveConsole.Keys;
using System.Text.RegularExpressions;
using MicroWaveConsole.Device;
using System.Text;

namespace MicroWave.Operations
{
    internal class Routines
    {
        private List<string> _lightPainel = new List<string>{ "0", "0", "0", "0" };

        private Status _statusDevice = Status.wait;

        private MicroWaveOperation _microOperation = new MicroWaveOperation();

        private bool _programDefined = false;

        private int Power = 10;
        public Routines() {
            ResetLightPainel();
        }
        public void NumpadKeyPress(MicroWaveKeys digits)
        {
            if (_statusDevice.Equals(Status.wait))
            {
                // Aqui tem que mover o painel ex: 0000 se precionar o 7 ficará 0007
                switch (digits)
                {
                    case MicroWaveKeys.Numpad0:
                    case MicroWaveKeys.Numpad1:
                    case MicroWaveKeys.Numpad2:
                    case MicroWaveKeys.Numpad3:
                    case MicroWaveKeys.Numpad4:
                    case MicroWaveKeys.Numpad5:
                    case MicroWaveKeys.Numpad6:
                    case MicroWaveKeys.Numpad7:
                    case MicroWaveKeys.Numpad8:
                    case MicroWaveKeys.Numpad9:
                        _lightPainel.RemoveAt(0);
                        _lightPainel.Add(((int)digits).ToString());
                        break;
                }
            }
        }

        public void OkPress()
        {
            StringBuilder sbTime = new StringBuilder();
            for (int i = 0; i < _lightPainel.Count; i++)
            {
                sbTime.Append(_lightPainel[i].ToString());
            }
            OkPress(sbTime.ToString(), Power, false);
        }
        public void OkPress(MicroWaveOperation microOperation)
        {

            OkPress(microOperation.GetTimer(), microOperation.GetPower(), true);
        }

        public void OkPress(string time, int power, bool programDefined)
        {
            if (_statusDevice.Equals(Status.wait))
            {
                try
                {
                    // validar tempo

                    int timer = 0;
                    if (int.Parse(time) == 0)
                    {
                        if (!_programDefined)
                           timer += 30;
                    }else
                    {
                        timer = TimerConverter(time);

                    }
                    timer *= 1_000;

                    _microOperation = new MicroWaveOperation(timer, power, "Running");
                    _statusDevice = Status.running;
                    _microOperation.Run();
                }
                catch (TimerException e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            else
            {
                _microOperation.AddTimer(30 * 1_000);
                _microOperation.Run();
            }
            RefreshLightPainel();
        }

        public void CancelPress()
        {
            if (_statusDevice.Equals(Status.running))
            {
                _microOperation.Cancel();
                RefreshLightPainel();
                _statusDevice = Status.wait;
            }
            else
            {
                Power = 10;
                ResetLightPainel();
                _microOperation = new MicroWaveOperation(0, Power, "Waiting");
            }
        }

        public void PowerPress()
        {
            if (_statusDevice.Equals(Status.wait))
            {
                // validar tempo e potencia
                int power = Power;
                try
                {
                    StringBuilder sbPower = new StringBuilder(); ;
                    for (int i = 0; i < 4; i++)
                    {
                        sbPower.Append(_lightPainel[i]);
                    }
                    Power=PowerConverter(sbPower.ToString());
                    ResetLightPainel();
                }
                catch (PowerException e)
                {
                    Power = power;
                    Console.WriteLine(e.ToString());
                    Console.ReadKey();
                }

                if (Power.Equals(0))
                {
                    Power = 10;
                }

            }
        }

        public void ProgramKeyPress(MicroWaveOperation microPeration)
        {
            if (_statusDevice.Equals(Status.wait))
            {
                OkPress(microPeration);
            }
        }

        private int TimerConverter(string time)
        {
            int timer = int.Parse(time);
            if (timer >= 100)
            {
                if (timer % 100 >= 60 )
                {
                    throw new TimerException("Wrong timer, seconds exceeds 59!");
                }
                timer = timer / 100 * 60 + timer % 100;

            }
            
            if (timer < 1 || timer > 120)
            {
                throw new TimerException("Wrong timer, enter with range between 1 second to 2 minutes!");
            }
            return timer;
        }
        private int PowerConverter(string sendPow)
        {
            int power = int.Parse(sendPow);
            Console.WriteLine(power);
            if (power > 10 || power <= 0)
            {
                throw new PowerException();
            }
            return power;
        }
        
        private void RefreshLightPainel()
        {
            int i =0;
            foreach (char c in _microOperation.GetTimer())
            {
                string expression = "^[0-9]";
                if (Regex.IsMatch(c.ToString(), expression))
                {
                    if (i < _lightPainel.Count)
                    {
                        _lightPainel[i++] = c.ToString();
                    }
                }
            }

        }
        private void ResetLightPainel()
        {
            for (int i = 0; i < 4; i++)
            {
                _lightPainel[i] = "0";
            }

        }
        public void PainelRefresh()
        {
            PainelDraw.Draw(
                 _lightPainel, 
                 _statusDevice.Equals(Status.wait)?"":_microOperation.GetMessageProcess(),
                 'P' + Power.ToString());
        }
    }
}

using MicroWave.Exceptions;
using MicroWaveConsole.Keys;
using System.Text.RegularExpressions;
using MicroWaveConsole.Device;
using System.Text;

namespace MicroWave.Operations
{
    internal class Routines
    {
        private readonly List<string> _lightPainel = new() { "0", "0", "0", "0" };

        private Status _statusDevice = Status.Wait;

        private MicroWaveOperation _microOperation = new();

        private bool _programDefined = false;

        private int _power = 10;

        private string _message = "Esquentando";
        public Routines() {
            ResetLightPainel();
        }
        public void NumpadKeyPress(MicroWaveKeys digits)
        {
            if (_statusDevice.Equals(Status.Wait))
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

        public void SetMicroOperation( MicroWaveOperation microOperation)
        {
            RefreshLightPainel(microOperation);
            _power = microOperation.GetPower();
            _microOperation = microOperation;
            _programDefined = true;
        }
        public void OkPress()
        {
            if (_programDefined)
            {
                OkPress(_microOperation);
            }else
            {
                StringBuilder sbTime = new();
                for (int i = 0; i < _lightPainel.Count; i++)
                {
                    sbTime.Append(_lightPainel[i]);
                }
                OkPress(sbTime.ToString(), _power);
            }
        }

        public void OkPress(string time, int power)
        {
            if (_statusDevice.Equals(Status.Wait))
            {
                try
                {
                    // validar tempo

                    int timer = 0;
                    if (int.Parse(time) == 0)
                    {
                        timer += 30;
                    }else
                    {
                        timer = TimerConverter(time);

                    }

                    _microOperation = new MicroWaveOperation(timer, power, _message, '.');
                    _statusDevice = Status.Running;
                    _microOperation.Run();
                }
                catch (TimerException e)
                {
                    PainelDraw.Alert(e.ToString());
                }
            }
            else
            {
                _microOperation.AddTimer(30);
                _microOperation.Run();
            }
            RefreshLightPainel(_microOperation);
        }

        public void OkPress(MicroWaveOperation microOperation)
        {
            if (_statusDevice.Equals(Status.Wait))
            {
                _statusDevice = Status.Running;
                microOperation.Run();
                RefreshLightPainel(microOperation);
            }
        }


        public void CancelPress()
        {
            if (_statusDevice.Equals(Status.Running))
            {
                _microOperation.Cancel();
                RefreshLightPainel(_microOperation);
                _statusDevice = Status.Wait;
            }
            else
            {
                _power = 10;
                ResetLightPainel();
                _microOperation = new MicroWaveOperation(0, _power, "Aguardando", null);
                _message = "Esquentando";
                _programDefined = false;
                _microOperation = new MicroWaveOperation();
            }
        }

        public void PowerPress()
        {
            if (_statusDevice.Equals(Status.Wait))
            {
                // validar tempo e potencia
                int power = _power;
                try
                {
                    StringBuilder sbPower = new(); ;
                    for (int i = 0; i < 4; i++)
                    {
                        sbPower.Append(_lightPainel[i]);
                    }
                    _power =PowerConverter(sbPower.ToString());
                    ResetLightPainel();
                }
                catch (PowerException e)
                {
                    _power = power;
                    PainelDraw.Alert(e.ToString());
                }

                if (_power.Equals(0))
                {
                    _power = 10;
                }

            }
        }

        private int TimerConverter(string time)
        {
            int timer = int.Parse(time);
            if (timer >= 100)
            {
                if (timer % 100 >= 60 )
                {
                    throw new TimerException("Tempo informado invalido, verifique os segundos");
                }
                timer = timer / 100 * 60 + timer % 100;

            }
            
            if (!_programDefined && ( timer < 1 || timer > 120))
            {
                throw new TimerException("Tempo informado invalido, entre com valores entre 1 segundo e 2 minutos!");
            }
            return timer;
        }
        static private int PowerConverter(string sendPow)
        {
            int power = int.Parse(sendPow);

            if (power > 10 || power <= 0)
            {
                throw new PowerException();
            }
            return power;
        }
        
        private void RefreshLightPainel(MicroWaveOperation microOperation )
        {
            int i =0;
            foreach (char c in microOperation.GetTimer())
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
                 _statusDevice.Equals(Status.Wait)?"":_microOperation.GetMessageProcess(),
                 'P' + _power.ToString());
        }
    }
}

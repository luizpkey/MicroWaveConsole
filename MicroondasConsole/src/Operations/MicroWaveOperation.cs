using System.Text;
using MicroWaveConsole.Device;

namespace MicroWave.Operations
{
    internal class MicroWaveOperation
    {
        private Timer? _timer = null;
        private int _secTimer = 0; // Em segundos
        private int _power = 0;
        private readonly char _processFeedback;
        private string _messageProcess="";
        private StringBuilder _messageBuffer = new StringBuilder();
        public MicroWaveOperation() { }
        public MicroWaveOperation(int secTimer, int power, string messageProcess, char? processFeedback) 
        {
            _secTimer = secTimer*1_000;
            _power = power;
            _messageProcess = messageProcess;
            _processFeedback = (char)((processFeedback!=null)?processFeedback:'.');
        }
        public void SetTimer(int secTimer) 
        {
            _secTimer = secTimer; 
        }
        public int GetSecondTimer()
        {
            return _secTimer;
        }

        public string GetTimer() {
            TimeSpan ts = TimeSpan.FromTicks(_secTimer * 10_000);
            return string.Format("{0}:{1}",
                                  ts.Minutes.ToString("00"),
                                  ts.Seconds.ToString("00"));
            }

        public string GetMessageProcess()
        {
            return _messageProcess;
        }
        public void SetPower(int power) 
        { 
            _power = power;
        }

        public int GetPower()
        {
            return _power;
        }

        public void Run()
        {
// multithread: desculpe ainda não estou acostumado com a rotina
// essa versão bloqueava o programa no autoevent.WaitOne()
// creio que exista uma forma de adicionar uma injeção de dependencia
// porém resolvi não perder tempo no momento.
//            // Create an AutoResetEvent to signal the timeout threshold in the
//            // timer callback has been reached.
            var autoEvent = new AutoResetEvent(false);

           if (_timer != null) 
            {
                _timer.Dispose();
            }
            _timer = new Timer(CheckStatus,
                                   autoEvent, 1000, 1000);
//
//            // When autoEvent signals the second time, dispose of the timer.
//            autoEvent.WaitOne();
//            _timer.Dispose();
        }

        public void Cancel()
        {
            if (_timer != null)
            {
                _timer.Dispose();
            }
        }
        public void AddTimer(int timer) 
        {
            if (_timer != null)
            {
                _timer.Dispose();
            }
            _secTimer += timer * 1_000;
            Run();
        }

        // This method is called by the timer delegate.
        public void CheckStatus(Object stateInfo)
        {
            StringBuilder sbMessage = new StringBuilder();
            AutoResetEvent autoEvent= (AutoResetEvent)stateInfo;

            _secTimer -= 1_000;
            sbMessage.Append("Tempo restante :");
            sbMessage.Append(GetTimer());
            PainelDraw.Messager(sbMessage.ToString());
            
            for (int i = 0; i < _power; i++)
            {
                _messageBuffer.Append(_processFeedback);
            }

            PainelDraw.Messager(_messageBuffer.ToString());

            if (_secTimer <= 0)
            {
                // Reset the counter and signal the waiting thread.
                //                invokeCount = 0;
                PainelDraw.Messager("Aquecimento concluído");
                if (_timer != null)
                {
                    _timer.Dispose();
                }
                autoEvent.Set();
            }

        }

    }

}


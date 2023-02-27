using System;
using System.Globalization;
using System.Text;

namespace MicroWave.Operations
{
    internal class MicroWaveOperation
    {
        private Timer _timer = null;
        private int _secTimer = 0; // Em segundos
        private int _power = 0;
        private string _messageProcess="";
        private StringBuilder _messageBuffer = new StringBuilder();
        public MicroWaveOperation() { }
        public MicroWaveOperation(int secTimer, int power, string messageProcess) 
        {
            _secTimer = secTimer*1_000;
            Console.WriteLine(_secTimer);
            Console.WriteLine(secTimer);
            Console.WriteLine(GetTimer());
            _power = power;
            _messageProcess = messageProcess;
            

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
            _timer.Dispose();
        }
        public void AddTimer(int timer) 
        {
            _timer.Dispose();
            _secTimer += timer * 1_000;
            Run();
        }

        // This method is called by the timer delegate.
        public void CheckStatus(Object stateInfo)
        {
            StringBuilder sbMessage = new StringBuilder();
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
            //            Console.WriteLine("{0} Checking status {1,2}.",
            //                DateTime.Now.ToString("h:mm:ss.fff"),
            //                (++invokeCount).ToString());

            _secTimer -= 1_000;
            sbMessage.Append("Time left: ");
            sbMessage.Append(GetTimer());
            Console.WriteLine( sbMessage.ToString());
            
            for (int i = 0; i < _power; i++)
            {
                _messageBuffer.Append('.');
            }

            Console.WriteLine(_messageBuffer.ToString());

            if (_secTimer <= 0)
            {
                // Reset the counter and signal the waiting thread.
                //                invokeCount = 0;
                Console.WriteLine("warm up completed");
                _timer.Dispose();
                autoEvent.Set();
            }

        }

    }

}


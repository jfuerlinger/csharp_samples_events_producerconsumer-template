using System;
using System.Windows.Threading;

namespace ProducerConsumer.Core
{
    public class FastClock
    {
        private static FastClock _instance;

        public static FastClock Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FastClock();
                }
                return _instance;
            }
        }
        private FastClock()
        {
            Time = DateTime.Now;
            Factor = 60;
            _timer = new DispatcherTimer();
            _timer.Tick += Timer_Tick;
        }

        public event EventHandler<DateTime> OneMinuteIsOver;

        public DateTime StartTime { get; private set; }

        public DateTime Time
        {
            get { return _time; }
            set
            {
                _time = value;
                StartTime = value;
            }
        }

        public int Factor { get; set; }

        public bool IsRunning
        {
            get { return _isRunning; }
            set
            {
                if (!_isRunning && value)
                {
                    _timer.Interval = TimeSpan.FromMilliseconds(Math.Max(1, 60000 / Factor));  // 1 Minute vergeht um den Faktor schneller
                    _timer.Start();
                }
                else if (_isRunning && !value)
                {
                    _timer.Stop();
                }
                _isRunning = value;
            }
        }

        private readonly DispatcherTimer _timer;
        private bool _isRunning;
        private DateTime _time;

        private void Timer_Tick(object sender, EventArgs e)
        {
            Time = Time.AddMinutes(1);
            OnOneMinuteIsOver(Time);
        }

        protected virtual void OnOneMinuteIsOver(DateTime fastClockTime)
        {
            OneMinuteIsOver?.Invoke(this, fastClockTime);
        }
    }
}

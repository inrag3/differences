using System;

namespace Code.Game.Timer
{
    public interface ITimer
    {
        public void Start();
        public void Stop();
        public void Increase(int time);
        public int Time { get; }
    }

    public interface IReadOnlyTimer
    {
        public event Action Ended;
        public event Action<int> Changed;
        public int Time { get; }
    }
}
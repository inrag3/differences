using System;
using System.Collections;
using Code.Game.Services;
using Game.Services;
using UnityEngine;
using Zenject;

namespace Code.Game.Timer
{
    public class Timer : ITimer, IReadOnlyTimer, IInitializable
    {
        private readonly ICoroutinePerformer _performer;
        private readonly WaitForSeconds _waiter;
        private Coroutine _update;
        public event Action Ended;
        public event Action<int> Changed;

        public Timer(TimerConfig config, ICoroutinePerformer performer)
        {
            _performer = performer;
            Time = config.Time;
            _waiter = new WaitForSeconds(1);
        }
        public int Time { get; private set; }

        public void Initialize() => Start();

        public void Start()
        {
            _update = _performer.StartPerform(Update());
        }

        public void Stop()
        {
            if (_update != null)
                _performer.StopPerform(_update);
        }

        public void Increase(int time)
        {
            if (time <= 0)
                throw new ArgumentException(nameof(time));
            Time += time;
            Changed?.Invoke(Time);
        }

        private IEnumerator Update()
        {
            while (true)
            {
                Tick();
                yield return _waiter;
            }
        }
        private void Tick()
        {
            Time--;
            if (Time == 0)
            {
                Stop();
                Ended?.Invoke();
            }
            Changed?.Invoke(Time);
        }
    }
}
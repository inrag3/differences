using System;
using Code.Game.Timer;
using Game.Differences;
using Game.Services.UI;
using UnityEngine;
using Zenject;

namespace Game
{
    public class Referee : IDisposable  
    {
        private IUIService _iuiService;
        private IReadOnlyTimer _timer;
        private IArea _area;

        [Inject]
        private void Construct(IReadOnlyTimer timer, IUIService iuiService, IArea area)
        {
            _area = area;
            _timer = timer;
            _iuiService = iuiService;
            _timer.Ended += OnTimerEnded;
            _area.Cleared += OnAreaCleared;
        }

        private void OnTimerEnded()
        {
            Debug.Log("Timer ended");
            var windows = _iuiService.Get(WindowID.Loss);
            windows.Show();
        }

        private void OnAreaCleared()
        {
            var windows = _iuiService.Get(WindowID.Win);
            windows.Show();
        }
        
        public void Dispose()
        {
            _timer.Ended -= OnTimerEnded;
            _area.Cleared -= OnAreaCleared;
        }
    }
}
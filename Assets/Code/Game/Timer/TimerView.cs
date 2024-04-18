using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Game.Timer
{
    [RequireComponent(typeof(TMP_Text))]
    public class TimerView : MonoBehaviour
    {
        private TMP_Text _text;
        private IReadOnlyTimer _timer;
        
        [Inject]
        private void Construct(IReadOnlyTimer timer)
        {
            _timer = timer;
        }

        private void OnEnable() => _timer.Changed += OnTimerChanged;

        private void OnDisable() => _timer.Changed -= OnTimerChanged;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void OnTimerChanged(int value)
        {
            var timeSpan = TimeSpan.FromSeconds(value);
            _text.text = $"{timeSpan:mm\\:ss}";
        }
    }
}
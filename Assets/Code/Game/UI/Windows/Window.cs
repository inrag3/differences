using System;
using Game.UI.Fader;
using Game.UI.Scaler;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI.Windows
{
    public abstract class Window : MonoBehaviour
    {
        [SerializeField] private Image _background;
        [SerializeField] private Panel _panel;
        private IFader _fader;
        private IScaler _scaler;
        public Panel Panel => _panel;

        [Inject]
        private void Construct(IFader fader, IScaler scaler)
        {
            _scaler = scaler;
            _fader = fader;
        }
        private void OnValidate()
        {
            _background ??= GetComponentInChildren<Image>();
            _panel ??= GetComponentInChildren<Panel>();
        }

        public void Show()
        {
            _background.gameObject.SetActive(true);
            _fader.Fade(_background, 0.85f, 0.2f);
            _scaler.Scale(_panel, 1, 0.2f);
        }
        
        public void Hide()
        {
            _fader.Fade(_background, 0f, 0.2f, 
                () => _background.gameObject.SetActive(false));
            _scaler.Scale(_panel, 0, 0.2f);
        }
    }
}
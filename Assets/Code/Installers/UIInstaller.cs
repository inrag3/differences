using System.Collections.Generic;
using Game;
using Game.Services.UI;
using Game.UI.Fader;
using Game.UI.Scaler;
using Game.UI.Windows;
using UnityEngine;
using Zenject;
namespace Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private LossWindow _lossWindow;
        [SerializeField] private WinWindow _winWindow;
        public override void InstallBindings()
        {
            BindUtilities();
            BindUIService();
        }

        private void BindUtilities()
        {
            Container.BindInterfacesAndSelfTo<Fader>().AsSingle();
            Container.BindInterfacesAndSelfTo<Scaler>().AsSingle();
        }

        private void BindUIService()
        {
            var windows = new Dictionary<WindowID, Window>()
            {
                { WindowID.Loss, _lossWindow },
                { WindowID.Win, _winWindow },
            };
            Container.BindInterfacesAndSelfTo<UIService>().AsSingle().WithArguments(windows);
        }
    }
}

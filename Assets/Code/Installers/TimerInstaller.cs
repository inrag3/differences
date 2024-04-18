using Code.Game.Common;
using Code.Game.Timer;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class TimerInstaller : MonoInstaller
    {
        [SerializeField] private TimerConfig _timerConfig;
    
        public override void InstallBindings()
        {
            BindTimer();
        }

        private void BindTimer()
        {
            Container.BindInstance(_timerConfig).AsSingle();
            Container.BindInterfacesAndSelfTo<Timer>().AsSingle();
        }
    }
}
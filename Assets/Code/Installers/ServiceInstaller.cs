using Game.Differences;
using Game.Factories.Difference;
using Game.Services;
using Game.Services.IAP;
using Game.UI;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        [SerializeField] private CoroutinePerformer _coroutinePerformer;
        [SerializeField] private IAPConfig _iapConfig;

        public override void InstallBindings()
        {
            BindFactory();
            BindCoroutinePerformer();
            BindIAP();
        }

        private void BindFactory()
        {
            Container.BindFactory<IPiece, IPiece, IDifference, DifferenceFactory>().To<Difference>().AsSingle();
        }

        private void BindCoroutinePerformer()
        {
            Container.BindInterfacesAndSelfTo<ICoroutinePerformer>().FromInstance(_coroutinePerformer).AsSingle();
        }

        private void BindIAP()
        {
            Container.BindInterfacesAndSelfTo<IAPProvider>().AsSingle().WithArguments(_iapConfig).NonLazy();
        }
    }
}



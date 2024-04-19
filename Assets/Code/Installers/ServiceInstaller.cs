using System.Threading.Tasks;
using Code.Game.Differences;
using Code.Game.Factories.Difference;
using Code.Game.Services;
using Code.Game.Services.IAP;
using Unity.Services.Core;
using Unity.Services.Core.Environments;
using UnityEngine;
using Zenject;

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
        Container.BindFactory<IPiece, IPiece,IDifference, DifferenceFactory>().To<Difference>().AsSingle();
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


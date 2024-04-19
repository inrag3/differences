using Code.Game.Common;
using Code.Game.Services.IAP;
using UnityEngine;
using Zenject;

public class ServiceInstaller : MonoInstaller
{
    [SerializeField] private CoroutinePerformer _coroutinePerformer;
    [SerializeField] private IAPConfig _iapConfig;
    public override void InstallBindings()
    {
        BindCoroutinePerformer();
        BindIAP();
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
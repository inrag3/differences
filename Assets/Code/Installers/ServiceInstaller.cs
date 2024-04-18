using Code.Game.Common;
using UnityEngine;
using Zenject;

public class ServiceInstaller : MonoInstaller
{
    [SerializeField] private CoroutinePerformer _coroutinePerformer;
    public override void InstallBindings()
    {
        BindCoroutinePerformer();
    }

    private void BindCoroutinePerformer()
    {
        Container.BindInterfacesAndSelfTo<ICoroutinePerformer>().FromInstance(_coroutinePerformer).AsSingle();
    }
}
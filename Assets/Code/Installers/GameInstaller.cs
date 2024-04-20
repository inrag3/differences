using Game;
using Game.Differences;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Area _area;
        
        public override void InstallBindings()
        {
            BindArea();
            BindReferee();
        }

        private void BindArea()
        {
            Container.BindInterfacesAndSelfTo<Area>().FromInstance(_area).AsSingle();
        }

        private void BindReferee()
        {
            Container.Bind<Referee>().AsSingle().NonLazy();
        }
    }
}
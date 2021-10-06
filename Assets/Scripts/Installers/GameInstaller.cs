using Archetype.Core;
using Archetype.Core.Enemy;
using Archetype.Game;
using GameObjects;
using GameObjects.Enemy;
using Services;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameObject CardPrefab;
        [SerializeField] private GameObject EnemyPrefab;

        
        public override void InstallBindings()
        {
            Container.Bind<IGameState>().To<GameState>().AsSingle();
            Container.Bind<IArchetypeGame>().To<ArchetypeGame>().AsSingle();

            Container.BindFactory<CardData, CardFacade, CardFacade.Factory>()
                .FromPoolableMemoryPool<CardData, CardFacade, CardFacade.Pool>(
                    poolBinder => poolBinder
                        .WithInitialSize(10)
                        .FromSubContainerResolve()
                        .ByNewPrefabInstaller<CardInstaller>(CardPrefab)
                        .UnderTransformGroup("Cards")
                    );
            
            
            Container.BindFactory<EnemyData, EnemyFacade, EnemyFacade.Factory>()
                .FromPoolableMemoryPool<EnemyData, EnemyFacade, EnemyFacade.Pool>(
                    poolBinder => poolBinder
                        .WithInitialSize(10)
                        .FromSubContainerResolve()
                        .ByNewPrefabInstaller<EnemyInstaller>(EnemyPrefab)
                        .UnderTransformGroup("Enemies")
                );
            
            
            Container.Bind<IImageStore>().To<ImageStore>().AsSingle();
            
        }
    }
}

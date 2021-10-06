using System.Threading.Tasks;
using Archetype.Core.Enemy;
using Services;
using UnityEngine;
using Zenject;

namespace GameObjects.Enemy
{
    public class EnemyFacade : MonoBehaviour, IPoolable<EnemyData, IMemoryPool>
    {
        private IMemoryPool _memoryPool;
        private IEnemyView _enemyView;
        private IImageStore _imageStore;

        [Inject]
        public void Construct(IEnemyView enemyView, IImageStore imageStore)
        {
            _enemyView = enemyView;
            _imageStore = imageStore;
        }
        
        public void OnDespawned()
        {
            _memoryPool = null;
        }

        public async void OnSpawned(EnemyData enemyData, IMemoryPool memoryPool)
        {
            _memoryPool = memoryPool;
            
            _enemyView.Health = enemyData.Health;
            _enemyView.SetName(enemyData.Name);
            _enemyView.SetImage(await _imageStore.LoadImage(enemyData.ImageUri));
        }

        
        public class Factory : PlaceholderFactory<EnemyData, EnemyFacade> { }
        public class Pool : MonoPoolableMemoryPool<EnemyData, IMemoryPool, EnemyFacade> { }
    }
}
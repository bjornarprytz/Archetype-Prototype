using Archetype.Core;
using Extensions;
using Services;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace GameObjects
{
    public class CardFacade : MonoBehaviour, IPoolable<CardData, IMemoryPool>
    {
        private ICardView _cardView;
        private IMemoryPool _memoryPool;
        private IImageStore _imageStore;

        private CompositeDisposable _disposable = new CompositeDisposable();

        [Inject]
        public void Construct(
            ICardView cardView,
            IImageStore imageStore)
        {
            _cardView = cardView;
            _imageStore = imageStore;

        }
        

        public void OnDespawned()
        {
            _memoryPool = null;
        }

        public async void OnSpawned(CardData cardData, IMemoryPool memoryPool)
        {
            _memoryPool = memoryPool;
            
            _cardView.SetColor(cardData.Color.ToUnityColor());
            _cardView.SetTitle(cardData.Name);
            _cardView.SetCost(cardData.Cost);
            
            _cardView.SetImage(await _imageStore.LoadImage(cardData.ImageUri));
            
            _cardView.SetRulesText(cardData.RulesText);
        }
        
        
        public class Factory : PlaceholderFactory<CardData, CardFacade> {}
        public class Pool : MonoPoolableMemoryPool<CardData, IMemoryPool, CardFacade> { }
    }
}
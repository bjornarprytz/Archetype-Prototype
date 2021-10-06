using Archetype.Core;
using Archetype.Game;
using GameObjects;
using UniRx;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    private IArchetypeGame _game;
    private CardFacade.Factory _cardFactory;
    private CompositeDisposable _disposable = new CompositeDisposable();
    
    [Inject]
    public void Construct(IArchetypeGame game, CardFacade.Factory cardFactory)
    {
        _cardFactory = cardFactory;
        _game = game;

        Observable
            .EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.Space))
            .Subscribe(_ => SpawnCard())
            .AddTo(_disposable);
    }

    private void OnDisable()
    {
        _disposable.Dispose();
    }

    private void SpawnCard()
    {
        _cardFactory.Create(new CardData
        {
            Name = "Test Card",
            Color = CardColor.Green,
            Cost = 4,
            ImageUri = "alifjlaisdghkayshfk,gajslidfhalufh,ashdfuasjldfhlasdjflisadhlf jsaifjlisadjflajsdlihidsf",
            RulesText = "Defend 100",
        });
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;
    private bool _initialized = false;

    [Header("Decks")]
    [SerializeField] private Deck _drawPile;
    [SerializeField] private Deck _discardPile;
    [SerializeField] private Deck _destroyPile;
    public Deck DrawPile { get { return _drawPile; } }
    public Deck DiscardPile { get { return _discardPile; } }
    public Deck DestroyPile { get { return _destroyPile; } }

    [Header("Hands")]
    [SerializeField] private Hand _playerHand;
    public Hand PlayerHand { get { return _playerHand; } }

    [Header("Action rows")]
    [SerializeField] private ActionRow _castRow;
    [SerializeField] private ActionRow _searchRow;
    [SerializeField] private ActionRow _attackRow;
    [SerializeField] private ActionRow _channelRow;

    public delegate void CardEvent(Card card);
    public event CardEvent CardDrawn;
    public event CardEvent CardDiscarded;
    public event CardEvent CardDestroyed;
    public event CardEvent CardPlayed;
    public event CardEvent CardEffectActivated;
    public event CardEvent CardConditionsCompleted;

    public delegate void CardRowEvent(Card card, ActionRow row);
    public event CardRowEvent CardPlayedOnRow;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void InitializeManager()
    {
        if (!_initialized)
        {
            _initialized = true;
            //Initialize all Cards in play
        }
    }

    public void DrawCard(int number = 1)
    {
        for (int i = 0; i < number; i++)
        {
            Card card = _drawPile.GetTopCard();

            if (card == null)
            {
                Debug.LogWarning("No more cards in draw pile!");
                break;
            }

            _drawPile.MoveCardToCollection(card, _playerHand);
            CardDrawn?.Invoke(card);
        }
    }

    public void DrawCardFromDiscard(int number = 1)
    {
        for (int i = 0; i < number; i++)
        {
            Card card = _discardPile.GetTopCard();

            if (card == null)
            {
                Debug.LogWarning("No more cards in discard pile!");
                break;
            }

            _discardPile.MoveCardToCollection(card, _playerHand);
            CardDrawn?.Invoke(card);
        }  
    }

    public void DiscardCard(CardCollection fromCollection, Card card)
    {
        fromCollection.MoveCardToCollection(card, _discardPile);
        CardDiscarded?.Invoke(card);
    }

    public void PlayCardFromHandToRow(Card card, ActionRow row)
    {
        _playerHand.MoveCardToCollection(card, row);
        CardPlayed?.Invoke(card);
        CardPlayedOnRow?.Invoke(card, row);
    }
}

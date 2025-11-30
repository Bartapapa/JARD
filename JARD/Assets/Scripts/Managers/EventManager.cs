using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    private bool _initialized = false;

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

            CardManager.instance.CardDrawn -= OnCardDrawn;
            CardManager.instance.CardDrawn += OnCardDrawn;

            CardManager.instance.CardDiscarded -= OnCardDiscarded;
            CardManager.instance.CardDiscarded += OnCardDiscarded;

            CardManager.instance.CardDestroyed -= OnCardDestroyed;
            CardManager.instance.CardDestroyed += OnCardDestroyed;

            CardManager.instance.CardPlayed -= OnCardPlayed;
            CardManager.instance.CardPlayed += OnCardPlayed;

            CardManager.instance.CardEffectActivated -= OnCardEffectActivated;
            CardManager.instance.CardEffectActivated += OnCardEffectActivated;

            CardManager.instance.CardConditionsCompleted -= OnCardConditionsCompleted;
            CardManager.instance.CardConditionsCompleted += OnCardConditionsCompleted;



            CardManager.instance.CardPlayedOnRow -= OnCardPlayedOnRow;
            CardManager.instance.CardPlayedOnRow += OnCardPlayedOnRow;
        }
    }

    public void OnCardDrawn(Card card)
    {
        CardDrawn?.Invoke(card);
    }
    public void OnCardDiscarded(Card card)
    {
        CardDiscarded?.Invoke(card);
    }
    public void OnCardDestroyed(Card card)
    {
        CardDestroyed?.Invoke(card);
    }
    public void OnCardPlayed(Card card)
    {
        CardPlayed?.Invoke(card);
    }
    public void OnCardEffectActivated(Card card)
    {
        CardEffectActivated?.Invoke(card);
    }
    public void OnCardConditionsCompleted(Card card)
    {
        CardConditionsCompleted?.Invoke(card);
    }
    public void OnCardPlayedOnRow(Card card, ActionRow row)
    {
        CardPlayedOnRow?.Invoke(card, row);
    }
}

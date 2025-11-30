using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCollection : MonoBehaviour
{
    //This should be able to be used for any grouping of cards, such as draw deck, discard pile, destroy pile, etc.
    //This should probably be managed in a CardManager object so as to have a reference to all cards in play or smth.

    [Header("Contents")]
    [SerializeField] protected List<Card> _cards = new List<Card>();
    public List<Card> Cards { get { return _cards; } }
    public bool IsEmpty { get { return _cards.Count == 0; } }

    public bool HasCard(Card card)
    {
        //Verify if selected card is present in deck.
        return _cards.Contains(card);
    }

    public Card GetCard(Card card)
    {
        if (GetCard(card))
        {
            return card;
        }

        return null;
    }

    public void AddCard(Card card)
    {
        _cards.Add(card);
    }

    public void RemoveCard(Card card)
    {
        if (HasCard(card))
        {
            _cards.Remove(card);
        }
    }
    public void MoveCardToCollection(Card card, CardCollection toCollection)
    {
        if (HasCard(card))
        {
            RemoveCard(card);
            toCollection.AddCard(card);
        }
    }
}

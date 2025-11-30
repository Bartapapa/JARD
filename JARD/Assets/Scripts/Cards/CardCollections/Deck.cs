using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : CardCollection
{
    public Card GetTopCard()
    {
        //Draw card at the last array of list.
        if (_cards.Count <= 0)
        {
            return null;
        }

        int lastIndex = _cards.Count - 1;
        return GetCard(_cards[lastIndex]);
    }

    public void Shuffle()
    {
        //Randomize list order.
        //Based on seed?
        if (_cards.Count <= 0) return;
        int count = _cards.Count;
        int last = count - 1;
        for (int i = 0; i < last; i++)
        {
            int r = UnityEngine.Random.Range(i, count); //Input seed here
            var tmp = _cards[i];
            _cards[i] = _cards[r];
            _cards[r] = tmp;
        }
    }
    public void AddCard(Card card, int index = -1)
    {
        //Place card at index, by default last (top of deck).
        if (index <= -1)
        {
            _cards.Add(card);
        }
        else
        {
            _cards.Insert(index, card);
        }
    }
}

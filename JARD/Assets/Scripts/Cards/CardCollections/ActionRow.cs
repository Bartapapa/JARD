using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRow : CardCollection
{
    public void ActivateAllCardEffects()
    {
        //Activate all card effects in action row in reverse order (LIFO)

        int length = _cards.Count - 1;
        for (int i = length; i >= 0; i--)
        {
            ActivateCardEffect(_cards[i]);
        }
    }

    public void ActivateCardEffect(Card card)
    {
        if (HasCard(card))
        {
            //Activate card effect
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Card : MonoBehaviour
{
    [Header("DATA")]
    public CardData data;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void InitializeCard()
    {
        switch (data.EffectActivationType)
        {
            case EffectActivationType.OnSet:
                CardManager.instance.CardPlayed -= ActivateFromPlayFlag;
                break;
            case EffectActivationType.OnActivation:
                break;
            default:
                break;
        }
    }

    private void ActivateFromPlayFlag(Card card)
    {
        Activate();
    }

    public void Activate()
    {
        //Activate the card's effects.
    }
}

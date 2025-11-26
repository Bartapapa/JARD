using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardEffectInternal : ScriptableObject
{
    public virtual void UseEffect()
    {
        //Override this method to do the appropriate effects, such as draw cards, deal damage, gain magic, etc.
    }
}

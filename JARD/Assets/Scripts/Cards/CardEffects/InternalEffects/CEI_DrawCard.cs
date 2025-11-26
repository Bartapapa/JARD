using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JARD/Card/CardEffectInternalData/DrawCard", fileName = "DrawX")]
public class CEI_DrawCard : CardEffectInternal
{
    public int CardsToDraw = 1;
    public override void UseEffect()
    {
        base.UseEffect();
        //Draw X cards here.
    }
}

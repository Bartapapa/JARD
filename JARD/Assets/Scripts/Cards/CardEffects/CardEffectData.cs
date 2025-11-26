using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JARD/Card/CardEffectData", fileName = "Cardname_Effect#_Desc")]
public class CardEffectData : ScriptableObject
{
    //There can be multiple effects for 1 cost.
    //There can be multiple costs for 1 effect.

    //Some effects will have FULL COSTS (Discard X cards, Discard X magic) in order to do effect.
    //Some effects will have PARTIAL COSTS (Discard up to X cards) which affects the intensity of the effect. Essentially, repeat the EFFECT for every cost unit used.
        //Effects with multiple partial costs can either be GROUPED (all different cost types must be deposited before one instance of effect is played) or NOT (either one of different cost types for effect to be played)
    //Some effects will have NO COST. Just apply the effect in full.

    //Some effects will be REACTIVE. Essentially, they check something in order to do their effect. This is often used for spells.
        //Those that do have a reactive effect should have a visual marker to have a way for the player to be able to tell at a glance the 'progress' of the conditions to be met (4/6 Magic discarded).

    //EFFECTS should be put in WRAPPERS, that will contain the potential costs of the effect, and the potential effects.
    //COSTS should be able to be parametered to determine whether they're to be paid in full or partially.

    [System.Serializable]
    public class CardEffectRequirement
    {
        public enum CardEffectCostType
        {
            Full,
            Partial
        }

        [Header("Cost type")]
        public CardEffectCostType CostType = CardEffectCostType.Full;
        public bool IsPartialCostGrouped = false;

        [Header("Requirements")]
        public List<RequirementWrapper> Requirement = new List<RequirementWrapper>();
        //Not necessarily cost, but requirement
    }

    public List<CardEffectRequirement> Requirements = new List<CardEffectRequirement>();
    public List<CardEffectInternal> Effects = new List<CardEffectInternal>();
}

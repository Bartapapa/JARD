using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RequirementWrapper
{
    [Header("Required resource")]
    public int Quantity = 1;
    public ResourceType Resource = ResourceType.None;

    [Header("Resource - Card")]
    public CardActionType CardRequiredAction = CardActionType.None;
    public CardType CardElement = CardType.None;
    public ActionType CardAssociatedAction = ActionType.None;

    [Header("Resource - Magic")]
    public CardType MagicElement = CardType.None;

    [Header("Resource - Status")]
    public StatusActionType StatusRequiredAction = StatusActionType.None;
    public StatusType Status = StatusType.None;
    public TargetType StatusTarget = TargetType.None;

}

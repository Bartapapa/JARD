using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    None,
    Any,
    Fire,
    Length
}

public enum ActionType
{
    None,
    Cast,
    Search,
    Attack,
    Channel
}

public enum CardActionType
{
    None,
    Draw,
    Discard,
    Destroy,
    Set,
    Activate,
}

public enum StatusActionType
{
    None,
    Apply,
    Remove,
    Clear,
}

public enum EffectActivationType
{
    OnSet,
    OnActivation,
}

public enum ResourceType
{
    None,
    Health,
    Magic,
    Card,
    Status,
}

public enum StatusType
{
    None,
    Block,
    Burn,
}

public enum TargetType
{
    None,
    Self,
    Enemy,
}

[CreateAssetMenu(menuName = "JARD/Card/CardData", fileName = "000_Type_Cardname")]
public class CardData : ScriptableObject
{
    [Header("ID")]
    public string Name = "";
    [SerializeField] private string _internalName = "";
    public string ID = "000";
    public string InternalName { get { return _internalName; } }

    [Header("Image")]
    [SerializeField] private Sprite _img;
    public Sprite Image { get { return _img; } }

    [Header("Caracteristics")]
    [SerializeField] private CardType _type = CardType.None;
    public CardType Type { get { return _type; } }

    [SerializeField] private List<CardType> _cost = new List<CardType>();
    public List<CardType> Cost { get { return _cost; } }

    [SerializeField] private List<ActionType> _associatedActions = new List<ActionType>();
    public List<ActionType> AssociatedActions { get { return _associatedActions; } }

    [Header("Effects")]
    [SerializeField] private EffectActivationType _effectActivationType = EffectActivationType.OnSet;
    public EffectActivationType EffectActivationType { get { return _effectActivationType; } }
    [SerializeField] private List<CardEffectData> _effects = new List<CardEffectData>();
    public List<CardEffectData> Effects { get { return _effects; } }
}

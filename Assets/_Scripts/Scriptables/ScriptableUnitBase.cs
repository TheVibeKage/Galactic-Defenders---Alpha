using System;
using UnityEngine;

public abstract class ScriptableUnitBase : ScriptableObject
{
    
    public Faction _Faction;

    [SerializeField] private Stats _stats;
    public Stats BaseStats => _stats;

    //public PlayerUnitBase Prefab;

    public string Description;

    public Sprite MenuSprite;

}
[Serializable]
public struct Stats {
    public int Health;
    public int Shield;
    public float Speed;
    public int AttackPower;
    public float AttackSpeed;
}

[Serializable]
public enum Faction {
    Allied = 0,
    Enemies = 1,
    Neutral = 2

}

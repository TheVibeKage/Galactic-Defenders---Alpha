using System;
using UnityEngine;


[CreateAssetMenu(fileName = "New Player Scriptable")]
public class ScriptablePlayer : ScriptableUnitBase
{
    public PlayerShipType ShipType;

    public PlayerUnitBase Prefab;
}

[Serializable]
public enum PlayerShipType {
    Red = 0,
    Cyan = 1,
    Yelllow = 2,
    Green = 3
}
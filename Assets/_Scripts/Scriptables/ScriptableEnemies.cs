using System;
using UnityEngine;


[CreateAssetMenu(fileName = "New Enemy Scriptable")]
public class ScriptableEnemies : ScriptableUnitBase
{
    public EnemyType EnemyType;

    public EnemyUnitBase Prefab;
}


[Serializable]
public enum EnemyType {
    Turret = 0,
    IonCannon = 1,
    Boss = 2,
    StarBase = 3,
    Other = 4
}
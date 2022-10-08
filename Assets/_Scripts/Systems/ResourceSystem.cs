using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// One repository for all scriptable objects. Create your query methods here to keep your business logic clean.
/// I make this a MonoBehaviour as sometimes I add some debug/development references in the editor.
/// If you don't feel free to make this a standard class
/// </summary>
public class ResourceSystem : StaticInstance<ResourceSystem> {
    public List<ScriptablePlayer> Players { get; private set; }
    private Dictionary<PlayerShipType, ScriptablePlayer> _Players;

    public List<ScriptableEnemies> Enemies { get; private set; }
    private Dictionary<EnemyType, ScriptableEnemies> _Enemies;

    protected override void Awake() {
        base.Awake();
        AssembleResources();
    }

    private void AssembleResources() {
        Players = Resources.LoadAll<ScriptablePlayer>("Units/PlayerShips").ToList();
        _Players = Players.ToDictionary(r => r.ShipType, r => r);
        
        Enemies = Resources.LoadAll<ScriptableEnemies>("Units/Enemies").ToList();
        _Enemies = Enemies.ToDictionary(r => r.EnemyType, r => r);
    }

    public ScriptablePlayer GetPlayer(PlayerShipType t) => _Players[t];
    public ScriptablePlayer GetRandomHero() => Players[Random.Range(0, Players.Count)];

    public ScriptableEnemies GetEnemy(EnemyType t) => _Enemies[t];
    public ScriptableEnemies GetRandomEnemy() => Enemies[Random.Range(0, Enemies.Count)];
}   
using UnityEngine;




public class UnitManager : StaticInstance<UnitManager> {

    public void SpawnPlayer() {
        SpawnShip(PlayerShipType.Red, new Vector3(0, -100, 0));
        
        
    }

    public void SpawnEnemies(){
        
        //SpawnBoss(EnemyType.Boss, new Vector3(0, 120, 0));
        //SpawnBoss(EnemyType.StarBase, new Vector3(0, 0, 0));
        //SpawnBoss(EnemyType.IonCannon, new Vector3(-44.7f, 104, 0));
        //SpawnBoss(EnemyType.IonCannon, new Vector3(-34.8f, 101.6f, 0));
        //SpawnBoss(EnemyType.IonCannon, new Vector3(44.7f, 104, 0));
        //SpawnBoss(EnemyType.IonCannon, new Vector3(34.8f, 101.6f, 0));
        //SpawnBoss(EnemyType.IonCannon, new Vector3(-20f, 94.26f, 0));
        //SpawnBoss(EnemyType.IonCannon, new Vector3(20f, 94.26f, 0));
        //SpawnBoss(EnemyType.Turret, new Vector3(0f, -250, 0));

    }

    void SpawnUnit(PlayerShipType a, Vector3 pos) {

        var unitsScriptable = ResourceSystem.instance.GetPlayer(a);

        var spawned = Instantiate(unitsScriptable.Prefab, pos, Quaternion.identity,transform);

        // Apply possible modifications here such as potion boosts, team synergies, etc
        var stats = unitsScriptable.BaseStats;
        stats.Health += 20;

        spawned.SetStats(stats);

    }

    void SpawnShip(PlayerShipType a, Vector3 pos) {

        var unitsScriptable = ResourceSystem.instance.GetPlayer(a);

        var spawned = Instantiate(unitsScriptable.Prefab, pos, Quaternion.identity,transform);

        // Apply possible modifications here such as potion boosts, team synergies, etc
        var stats = unitsScriptable.BaseStats;
        
        

        spawned.SetStats(stats);

    }

    void SpawnBoss(EnemyType a, Vector3 pos) {

        var unitsScriptable = ResourceSystem.instance.GetEnemy(a);

        var spawned = Instantiate(unitsScriptable.Prefab, pos, Quaternion.identity,transform);

        // Apply possible modifications here such as potion boosts, team synergies, etc
        var stats = unitsScriptable.BaseStats;
        
        

        spawned.SetStats(stats);

    }



}
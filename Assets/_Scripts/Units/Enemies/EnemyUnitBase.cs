using UnityEngine;
public class EnemyUnitBase : UnitBase
{
    [Header("Enemy UnitBase Variables")]
    [SerializeField] protected int _attackSpeed;
    [SerializeField] protected int _attackPower;

    public static EnemyUnitBase instance;
    private void Awake() {

        GameManager.OnBeforeStateChanged += OnStateChanged;
    }


}
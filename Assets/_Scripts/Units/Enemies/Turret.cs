using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : EnemyUnitBase
{

    [Header("Turret Variables")]
    private Rigidbody2D rb;
    [SerializeField] private float distance;
    [SerializeField] private float timeBetweenShots;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject fireType;


    void Start(){
        StartCoroutine(PlayerUnitBase.instance._getPosition);
        rb = this.GetComponent<Rigidbody2D>();
        timeBetweenShots = _unitStats.AttackSpeed;
    }
    void Update()
    {
        if (_canMove == true){

            Vector3 direction = PlayerUnitBase.instance._position.position - transform.position;
            //distance = Mathf.Sqrt(Mathf.Pow((PlayerUnitBase.instance.pos.position.x - transform.position.x), 2) + Mathf.Pow((PlayerUnitBase.instance.pos.position.y - transform.position.y), 2));
            distance = Vector3.Distance(PlayerUnitBase.instance._position.position, transform.position);
            //Debug.Log("Unit is " + distance + " away");
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;

            if(distance <= 60){
                
                if(timeBetweenShots <= 0){
                    _fireShot();
                    timeBetweenShots = _unitStats.AttackSpeed;
                }
                else{
                    timeBetweenShots -= Time.deltaTime;
                }            
            }
        }
    }
    private void _fireShot(){
        Instantiate(fireType, firePoint.position, transform.rotation);
        
    }
    IEnumerator EngageTarget(){
        while(true){                
            yield return new WaitForSeconds(_unitStats.AttackSpeed);
            _fireShot();
        }
    }
}

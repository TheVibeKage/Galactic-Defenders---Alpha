using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCannon : MonoBehaviour
{
    public Transform _firePoint;
    public GameObject _fireType1;
    public GameObject _fireType2;
    public GameObject _fireType3;
    public float _timeBetweenShots;
    public int _stage;
    void Start()
    {
        _stage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(_stage == 1){

            if(_timeBetweenShots <= 0){
                Instantiate(_fireType1, _firePoint.position, transform.rotation);
                _timeBetweenShots = 0.1f;
            }
            else{
                _timeBetweenShots -= Time.deltaTime;
            }   
        }
        if(_stage == 2){
            
            if(_timeBetweenShots <= 0){
                Instantiate(_fireType2, _firePoint.position, transform.rotation);
                _timeBetweenShots = 0.1f;
            }
            else{
                _timeBetweenShots -= Time.deltaTime;
            }   
        }
        if(_stage == 3){
            
            if(_timeBetweenShots <= 0){
                Instantiate(_fireType3, _firePoint.position, transform.rotation);
                _timeBetweenShots = 0.1f;
            }
            else{
                _timeBetweenShots -= Time.deltaTime;
            }   
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform firePoint;

    [SerializeField] private Transform firePoint2;

    [SerializeField] private GameObject fireType;

    [SerializeField] private float respawnTime = 0.1f;
    void Start()
    {
        StartCoroutine(engageTarget());
    }

    private void fireShot(){

        Instantiate(fireType, firePoint.position, transform.rotation);
        Instantiate(fireType, firePoint2.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator engageTarget(){
        while(true){
            yield return new WaitForSeconds(respawnTime);
            fireShot();
        }
    }
}

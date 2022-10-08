using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpansiveLasers : MonoBehaviour
{
    public Transform firePoint;

    public GameObject fireType;



    void Start()
    {
        StartCoroutine(fireLasers());
    }

    // Update is called once per frame
    void Update()
    {

        
        
    }

    private IEnumerator fireLasers(){
        Instantiate(fireType, firePoint.position, transform.rotation);
        yield return new WaitForSeconds(2f);
        StopCoroutine(fireLasers());
        StartCoroutine(fireLasers());

    }


}

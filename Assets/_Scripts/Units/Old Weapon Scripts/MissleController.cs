using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private Rigidbody2D rigidBody;

    [SerializeField] private GameObject Missile;

    [SerializeField] private GameObject AreaOfEffect;

    //[SerializeField] private GameObject Entire;

    void Start()
    {
        Missile.SetActive(true);
        AreaOfEffect.SetActive(false);
        StartCoroutine(timeToDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = transform.right * _speed;
    }

    private void OnTriggerEnter2D(Collider2D other){
         //Destroy(gameObject);
         //Debug.Log("Hit registered");
        //Destroy(MissileCone);
        Missile.SetActive(false);
        AreaOfEffect.SetActive(true);
        StopCoroutine(timeToDestroy());
        StartCoroutine(areaOfEffectStatus());


        
    }

    private IEnumerator timeToDestroy(){
        yield return new WaitForSeconds(10f);
        //Debug.Log("time ended");
        Missile.SetActive(false);
        AreaOfEffect.SetActive(true);
        StartCoroutine(areaOfEffectStatus());
        StopCoroutine(timeToDestroy());
    }

    private IEnumerator areaOfEffectStatus(){
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        StopCoroutine(areaOfEffectStatus());

    }
}

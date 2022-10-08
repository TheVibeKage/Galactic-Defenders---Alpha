using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : ProjectileBase
{
    [Header("Rocket Variables")]
    [SerializeField] private GameObject _missile;
    [SerializeField] private GameObject _areaOfEffect;
    [SerializeField] private float _areaOfEffectTime = 1f;

    protected IEnumerator _areaOfEffectStatus;

    void Start()
    {
        _missile.SetActive(true);
        _areaOfEffect.SetActive(false);
        _areaOfEffectStatus = AreaOfEffectStatus();

        _projRigidBody = GetComponent<Rigidbody2D>();
        _timeToDestroy = TimeToDestroy();
        StartCoroutine(_timeToDestroy);
    }

    void Update()
    {
        _projRigidBody.velocity = transform.right * _speed;
    }

    protected override void OnTriggerEnter2D(Collider2D other){
        _missile.SetActive(false);
        _areaOfEffect.SetActive(true);
        StopCoroutine(_timeToDestroy);
        StartCoroutine(_areaOfEffectStatus);
    }

    protected override IEnumerator TimeToDestroy(){
        yield return new WaitForSeconds(_timeToDestroyVar);
        //Debug.Log("time ended");
        _missile.SetActive(false);
        _areaOfEffect.SetActive(true);
        StartCoroutine(_areaOfEffectStatus);
        StopCoroutine(TimeToDestroy());
    }

    protected IEnumerator AreaOfEffectStatus(){
        yield return new WaitForSeconds(_areaOfEffectTime);
        Destroy(gameObject);
        StopCoroutine(AreaOfEffectStatus());
    }
}

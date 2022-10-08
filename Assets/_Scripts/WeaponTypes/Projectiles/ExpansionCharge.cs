using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpansionCharge : ProjectileBase
{
    protected Vector3 _scaleChange;

    //Variable to change how big the charge gets. It is divided by 1000 for ease of use in editor
    [Header("Expasnion Charge Scale")]
    [SerializeField] protected float _scaleVariable = 9f;
    void Start()
    {
        _scaleVariable /= 1000;
        _scaleChange = new Vector3(_scaleVariable, _scaleVariable, 0);

        _projRigidBody = GetComponent<Rigidbody2D>();
        _timeToDestroy = TimeToDestroy();
        StartCoroutine(_timeToDestroy);
    }

    
    void Update()
    {
        _projRigidBody.velocity = transform.right * _speed;

        transform.localScale += _scaleChange;
    }

    protected override void OnTriggerEnter2D(Collider2D other){
        if(other.tag != "ExpansiveRound"){
            Destroy(gameObject);
        }
    }
}

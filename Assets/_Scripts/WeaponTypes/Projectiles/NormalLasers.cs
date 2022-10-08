using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalLasers : ProjectileBase
{
    // Start is called before the first frame update
    void Start()
    {
        _projRigidBody = GetComponent<Rigidbody2D>();
        _timeToDestroy = TimeToDestroy();
        StartCoroutine(_timeToDestroy);
    }

    
    void Update()
    {
        _projRigidBody.velocity = transform.right * _speed;
    }
}

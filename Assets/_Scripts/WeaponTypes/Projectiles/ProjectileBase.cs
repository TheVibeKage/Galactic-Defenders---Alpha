using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    //Base for all projectiles
    [Header("Projectile Base Variables")]
    [SerializeField] protected float _speed = 20f;
    [SerializeField] protected float _timeToDestroyVar = 7f;
    protected Rigidbody2D _projRigidBody;
    protected IEnumerator _timeToDestroy;
 
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

    protected virtual void OnTriggerEnter2D(Collider2D other){
        Destroy(gameObject);
    }

    protected virtual IEnumerator TimeToDestroy(){
        yield return new WaitForSeconds(_timeToDestroyVar);
        Object.Destroy(this.gameObject);
        StopCoroutine(TimeToDestroy());
    }
}

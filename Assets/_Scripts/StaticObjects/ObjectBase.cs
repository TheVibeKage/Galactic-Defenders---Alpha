using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    [Header("ObjectBase Variables")]
    public int _health;
    public int _shield;
    protected Rigidbody2D _rigidBody;
    //public GameObject _undamagedObject;
    public GameObject _damagedObject;


    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Laser"){
            TakeDamage(1);
         }
    }

    protected virtual void TakeDamage(int dmg) {
        _health -= dmg;
        if(_health <= 0){
            Destroy(gameObject);
 
        }
        Debug.Log(_health + " Health left");
    }
}

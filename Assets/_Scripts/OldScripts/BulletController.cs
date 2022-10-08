using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private Rigidbody2D rigidBody;

    void Start()
    {
        //StartCoroutine(timeToDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = transform.right * _speed;
        
    }

    private void OnTriggerEnter2D(Collider2D other){


        Destroy(gameObject);
        
    }

    private IEnumerator timeToDestroy(){
        yield return new WaitForSeconds(10f * Time.deltaTime);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpansionRound : MonoBehaviour
{
    private Vector3 scaleChange;
    [SerializeField] private float _speed = 20f;
    [SerializeField] private Rigidbody2D rigidBody;



    void Start()
    {
        scaleChange = new Vector3(0.007f, 0.007f, 0);

        StartCoroutine(timeToDestroy());

        

    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = transform.right * _speed;

        transform.localScale += scaleChange;
        
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag != "ExpansiveRound"){
            Destroy(gameObject);
        }
        else{
            
        }
        //Destroy(gameObject);
        
    }

    private IEnumerator timeToDestroy(){
        yield return new WaitForSeconds(7f);
        Object.Destroy(this.gameObject);
        StopCoroutine(timeToDestroy());
    }

    //private void OnDestroy(){
    //    StopCoroutine(timeToDestroy());
    //}


}

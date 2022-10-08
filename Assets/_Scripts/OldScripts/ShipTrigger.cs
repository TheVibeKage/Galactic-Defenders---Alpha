using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "Destructable"){

            Destroy(other.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public GameObject portal;
    private GameObject player;
    public GameObject fireType;

    private float exitAngle;
    private float entranceAngle;
    private float entranceAngleDegrees;
    private float exitAngleDegrees;
    private float realAngle;
    private float adjustor = Mathf.PI/2;
    private bool canTeleport = true;
    void Start()
    {
        


        player = GameObject.FindWithTag("Player");
        entranceAngleDegrees = (transform.rotation.eulerAngles.z);
        exitAngleDegrees = (portal.transform.rotation.eulerAngles.z);
        entranceAngle = entranceAngleDegrees * Mathf.PI / 180;
        exitAngle = exitAngleDegrees * Mathf.PI / 180;
    }


    //Last thing to implement: Freezing player in place for a moment (this will play warp animation at the exit portal, and the delay will give ppl a chance to readjust their controls)
    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (canTeleport)
        {
        
            if (collision.tag == "Laser")
                //Only concern: How to manage this for different objects? May need if statement copies of this for every different projectile, where each different one handles its appropriate one
            {

                float angleDifference = exitAngleDegrees - entranceAngleDegrees;
                realAngle = collision.transform.localEulerAngles.z + angleDifference + 180;



                Instantiate(fireType, new Vector2(portal.transform.position.x + (Mathf.Cos(exitAngle + adjustor) * .9f), portal.transform.position.y + (Mathf.Sin(exitAngle + adjustor) * 0.9f)), Quaternion.Euler(0f, 0f, realAngle));
            }
        
            else if (collision.tag == "Player")
            {
                player.transform.position = new Vector2(portal.transform.position.x + (Mathf.Cos(exitAngle + adjustor) * 6), portal.transform.position.y + (Mathf.Sin(exitAngle + adjustor) * 6));
            }
        }
    }

    
}

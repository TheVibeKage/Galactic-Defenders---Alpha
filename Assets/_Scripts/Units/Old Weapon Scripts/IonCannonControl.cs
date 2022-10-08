using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonCannonControl : MonoBehaviour
{


   public GameObject _ActiveLaser;
   public GameObject _InactiveLaser;

   public Transform _LaserPlacment;

   

   void Start(){
        //_ActiveLaser.SetActive(false);
        _InactiveLaser.SetActive(false);

        StartCoroutine(rotationLaser());

   }

   private IEnumerator rotationLaser(){
        //_ActiveLaser.SetActive(false);
        //Instantiate(_ActiveLaser, _LaserPlacment.position, transform.rotation);
        //Destroy((_ActiveLaser));
        _InactiveLaser.SetActive(true);
        yield return new WaitForSeconds(5f);
        _InactiveLaser.SetActive(false);
        Instantiate(_ActiveLaser, _LaserPlacment.position, transform.rotation);
        //_ActiveLaser.
        Debug.Log("Working");
        //_ActiveLaser.SetActive(true);
        yield return new WaitForSeconds(5f);
        //Destroy((_ActiveLaser));
        StopCoroutine(rotationLaser());
        StartCoroutine(rotationLaser());

   }

// Instantiate cannpn then destroy
}

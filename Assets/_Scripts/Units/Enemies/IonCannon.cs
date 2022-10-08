using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonCannon : EnemyUnitBase
{
   public GameObject _activeLaser;
   public GameObject _inactiveLaser;

   private IEnumerator _ionCannonAttack;

   Collider2D other;

   void Start(){
     _ionCannonAttack = IonCannonAttack();
     StartCoroutine(_ionCannonAttack);

   }

   void Update(){

   }

   public IEnumerator IonCannonAttack(){
        _activeLaser.SetActive(false);
        _inactiveLaser.SetActive(true);
        yield return new WaitForSeconds(3f);
        _activeLaser.SetActive(true);
        _inactiveLaser.SetActive(false);
        yield return new WaitForSeconds(6f);
        StopCoroutine(IonCannonAttack());
        StartCoroutine(IonCannonAttack());

   }

}


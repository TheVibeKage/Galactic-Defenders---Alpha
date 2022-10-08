using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateScreen : MonoBehaviour
{
   
   public static ActivateScreen instance;

   public GameObject _VistoryScreen;
   public GameObject _LoseScreen;


   void Awake(){

      instance = this;
      _VistoryScreen.SetActive(false);
      _LoseScreen.SetActive(false);



   }
}

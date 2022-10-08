using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBase : EnemyUnitBase
{
  
      //public static StarBase instance;


      private void Start(){

        //instance = this;

        //Instantiate(shield, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
      }
      
      private void OnDestroy(){

        //GameManager.instance.UpdateGameState(GameState.Victory);

    }


}

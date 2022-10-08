using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResetLevel : MonoBehaviour
{
    
    public void levelReset(){

        Debug.Log("clicked");

        GameManager.instance.UpdateGameState(GameState.Reset);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBase : MonoBehaviour
{
    protected void UpdateBossStage(BossStage newStage){

        switch (newStage){

            case BossStage.Stage0:
                HandleStage0();
                break;
            case BossStage.Stage1:
                HandleStage1();
                break;
            case BossStage.Stage2:
                HandleStage2();
                break;
            case BossStage.Stage3:
                HandleStage3();
                break;
            case BossStage.Stage4:
                HandleStage4();
                break;
            case BossStage.Stage5:
                HandleStage5();
                break;
            case BossStage.Stage6:
                HandleStage6();
                break;
            case BossStage.Stage7:
                HandleStage7();
                break;
        }

        Debug.Log($"New state: {newStage}");  
    }

    //Create how stages will play out in child classes
    protected virtual void HandleStage0(){

    }
    protected virtual void HandleStage1(){
        
    }
    protected virtual void HandleStage2(){
        
    }
    protected virtual void HandleStage3(){
        
    }
    protected virtual void HandleStage4(){
        
    }
    protected virtual void HandleStage5(){
        
    }
    protected virtual void HandleStage6(){
        
    }
    protected virtual void HandleStage7(){
        
    }

    ////////////////////////////////

    protected enum BossStage {

        Stage0 = 0,
        Stage1 = 1,
        Stage2 = 2,
        Stage3 = 3,
        Stage4 = 4,
        Stage5 = 5,
        Stage6 = 6,
        Stage7 = 7
    }

}



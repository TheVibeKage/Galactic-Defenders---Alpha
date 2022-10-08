using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : EnemyUnitBase
{
    [SerializeField] private GameObject IonCannons;

    [SerializeField] private GameObject EnergyLasers;

    [SerializeField] private GameObject ExpanisveLaser;

    // animate the game object from -1 to +1 and back
    public float minimum = -150;
    public float maximum =  150;

    // starting value for the Lerp
    static float t = 0.0f;

    private bool isMoving;
    private bool isHit;

    void Start()
    {
        IonCannons.SetActive(false);
        EnergyLasers.SetActive(true);
        ExpanisveLaser.SetActive(false);
        isMoving = false;
        isHit = true;
        //StartCoroutine(checkStatus());
        
    }


    void Update()
    {

        //if(isHit == true){
        //    StartCoroutine(repo1());
       // }

        if(isMoving == true){



            transform.position = new Vector3(Mathf.Lerp(minimum, maximum, t), 120, 0);
            t += 0.1f * Time.deltaTime;
            //Debug.Log(transform.position);

                if (t > 1.0f)
                {
                    float temp = maximum;
                    maximum = minimum;
                    minimum = temp;
                    t = 0.0f;
                }
                 
        }

        
        if(_health == 4){

        }

        if(_health == 3){

            isMoving = true;            
            IonCannons.SetActive(true);
            EnergyLasers.SetActive(false);

        }


        if (_health == 2){

            

            //Debug.Log("Aye");
            //Debug.Log("Mothership has  " + Stats.Health + " HP"); 

            //IonCannons.SetActive(true);
            //EnergyLasers.SetActive(true);

        }
        if (_health == 1){
            //Debug.Log("Mothership has  " + Stats.Health + " HP"); 

            IonCannons.SetActive(false);
            EnergyLasers.SetActive(false);
            ExpanisveLaser.SetActive(true);

        }
        
    }

    IEnumerator repo1(){

        

        Debug.Log("start");

        //isHit = false;
        //while(t < 1){
        transform.position = new Vector3(Mathf.Lerp(0, minimum, t), 120, 0);
        
        t += 0.1f * Time.deltaTime;
        //}

        yield return new WaitForSeconds(10f);

        t = 0f;

        //_Health--;
             
        //yield return new WaitForSeconds(1f);

        //transform.position = new Vector3(-150, 120, 0);

        //t = 0.0f;
        
        //StartCoroutine(reposition());
        
        
        transform.position = new Vector3(Mathf.Lerp(-150, 0, t), 120, 0);
        t += 0.1f * Time.deltaTime;

        yield return new WaitForSeconds(10f);

        StopCoroutine(repo1());

        //StartCoroutine(reposition());

        //Debug.Log(transform.position); 
    }

    IEnumerator reposition(){

        //yield return new WaitForEndOfFrame();

        Debug.Log("Started");

            transform.position = new Vector3(Mathf.Lerp(minimum, maximum, t), 120, 0);
            t += 0.1f * Time.deltaTime;
            //Debug.Log(transform.position);

                if (t > 1.0f)
                {
                    float temp = maximum;
                    maximum = minimum;
                    minimum = temp;
                    t = 0.0f;
                }
            //yield return null;
            yield return new WaitForEndOfFrame();
               
    }

IEnumerator Lerp()
    {
        //float timeElapsed = 0;
        while (t < 3)
        {
            transform.position = new Vector3(Mathf.Lerp(0, minimum, t / 3), 120, 0);
            t += Time.deltaTime;
            yield return null;
        }
        transform.position = new Vector3(-150, 120, 0);

        yield return new WaitForSeconds(1f);

        t = 0.0f;
        StopCoroutine(Lerp());
        StartCoroutine(vibeCheck());
        
    }

    IEnumerator vibeCheck(){

        Debug.Log("Check");
        yield return null;

    }

    IEnumerator execution(){

        transform.position = new Vector3(Mathf.Lerp(minimum, maximum, t), 120, 0);
        t += 0.1f * Time.deltaTime;
        Debug.Log(transform.position);
              
            if (t > 1.0f)
            {
                float temp = maximum;
                maximum = minimum;
                minimum = temp;
                t = 0.0f;
            }
        yield return new WaitForEndOfFrame();
    }

    

    
}

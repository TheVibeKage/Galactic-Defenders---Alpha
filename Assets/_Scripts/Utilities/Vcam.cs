using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Vcam : MonoBehaviour
{

    public static Vcam instance;
    
    public CinemachineVirtualCamera virtualCamera;


    void Awake()
    {
        instance = this;
    }

}




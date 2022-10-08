using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBarrier : MonoBehaviour
{
    public GameObject _leftGenerator;
    public bool _leftGeneratorStatus;
    public GameObject _rightGenerator;
    public bool _rightGeneratorStatus;
    public GameObject _barrier;

    // Update is called once per frame
    void Update()
    {
        if(_leftGenerator == null || _rightGenerator == null){
            _barrier.SetActive(false);
        }

    }


}

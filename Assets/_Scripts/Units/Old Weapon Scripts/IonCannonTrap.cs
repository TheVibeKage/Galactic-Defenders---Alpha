using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonCannonTrap : MonoBehaviour
{
    [SerializeField] private GameObject[] _verticalLasers;
    [SerializeField] private GameObject[] _horizontalLasers;

    private int _sizeOfVert;
    private int _sizeOfHori;

    private IEnumerator VerticalLasersCycle;
    private IEnumerator HorizontalLasersCycle;


    void Start()
    {
        _sizeOfVert = _verticalLasers.Length;

        _sizeOfHori = _horizontalLasers.Length;

        VerticalLasersCycle = _verticalLasersCycle();

        HorizontalLasersCycle = _horizontalLasersCycle();

        StartCoroutine(VerticalLasersCycle);
        StartCoroutine(HorizontalLasersCycle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator _verticalLasersCycle(){

        for(int y = 0; y < _sizeOfVert; y++){
            //yield return new WaitForSeconds(1f);
            _verticalLasers[y].SetActive(true);
            //Debug.Log("Working");
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator _horizontalLasersCycle(){

        for(int y = 0; y < _sizeOfHori; y++){
            //yield return new WaitForSeconds(1f);
            _horizontalLasers[y].SetActive(true);
            //Debug.Log("Working");
            yield return new WaitForSeconds(1f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextZone : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Camera _camera;
    private Transform _playerShip;
    private Vector3 _newPosition = new Vector3(0, 0, -22);
    private Vector3 _tempPlayerPosition;
    void Start()
    {
        //RedShip.instance.pos.position = _newPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "Player"){
            _camera.transform.position = _newPosition;
            _tempPlayerPosition = new Vector3(RedShip.instance._position.position.x, -135, RedShip.instance._position.position.z);
            RedShip.instance._position.position = _tempPlayerPosition;
            Destroy(this);
        }
    }

    
}

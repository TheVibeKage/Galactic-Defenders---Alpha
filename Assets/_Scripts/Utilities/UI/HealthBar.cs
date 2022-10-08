using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject[] _healthBars;

    [SerializeField] private GameObject _invulnrability;

    //PlayerUnitBase _playerUnitBase;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerUnitBase.instance._health == 2){
            _healthBars[2].SetActive(false);
        }
        if(PlayerUnitBase.instance._health == 1){
            _healthBars[1].SetActive(false);
        }
        if(PlayerUnitBase.instance._health == 0){
            _healthBars[0].SetActive(false);
        }

        if(PlayerUnitBase.instance._invulnrable == true){
            _invulnrability.SetActive(true);
        }
        if(PlayerUnitBase.instance._invulnrable == false){
            _invulnrability.SetActive(false);
        }

    }
}

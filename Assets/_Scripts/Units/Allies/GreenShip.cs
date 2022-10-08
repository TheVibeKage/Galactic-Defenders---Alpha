using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenShip : PlayerUnitBase
{
    
    void Awake() {

        instance = this;
        GameManager.OnBeforeStateChanged += OnStateChanged;
        _shipColor.material.SetColor("_Color", Color.green);

        _ionDamage = IonDamage();
        _justHitCo = JustGotHit();
        _invulnrable = false;
        _justHit = false;

        _rigidBody = GetComponent<Rigidbody2D>();
        theCam = Camera.main;
        _canDash = true;
        _position = GetComponent<Transform>();
        _getPosition = GetPosition();
        _stopDashing = StopDashing();


    }
}

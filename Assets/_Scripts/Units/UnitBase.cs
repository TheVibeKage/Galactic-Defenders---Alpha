using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour {

    [Header("UnitBase Variables")]
    public int _health;
    public int _shield;
    public bool _invulnrable;
    protected IEnumerator _ionDamage;
    protected IEnumerator _justHitCo;
    protected bool _justHit;
    protected bool _canMove;
    [SerializeField] protected GameObject _shieldObj;
    protected Stats _unitStats { get; private set; }
    protected Rigidbody2D _rigidBody; 

    /*void Start(){
        _ionDamage = IonDamage();
        _justHitCo = JustGotHit();
        _invulnrable = false;
        _justHit = false;

    }*/
   
    public virtual void SetStats(Stats stats) { 
        _unitStats = stats;
        _health = _unitStats.Health;
        _shield = _unitStats.Shield;
    }

    protected virtual void TakeDamage(int dmg) {
        _health -= dmg;
        if(_health <= 0){
            Destroy(gameObject);
        }
        Debug.Log(_health + " Health left");
    }

    protected virtual void TakeShieldDamage(int dmg) {
        _shield -= dmg;
        if(_shield == 0){
            _shieldObj.SetActive(false);
        }
        Debug.Log(_shield + " Shield left");
    }

    public virtual void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Laser" && _invulnrable == false){

            if(_shield > 0){
                TakeShieldDamage(1);
            }
            else{
                TakeDamage(1);
                StartCoroutine(JustGotHit()); 
            }
         }
         if(other.tag == "IonCannon" && _invulnrable == false){
            StartCoroutine(_ionDamage);
          }
    }

    public virtual void OnTriggerStay2D(Collider2D other){
        if(other.tag == "IonCannon" && _invulnrable == false){
            StartCoroutine(_ionDamage);
          }
    }

    public virtual void OnTriggerExit2D(Collider2D other){
        //Debug.Log("Exit");
        if(other.tag == "IonCannon"){
            StopCoroutine(_ionDamage);
        }
    }

    public IEnumerator IonDamage(){ 
        while(true){
            if(_justHit == false){
                TakeDamage(1);
                StartCoroutine(JustGotHit());
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    protected IEnumerator JustGotHit(){
        _justHit = true;
        _invulnrable = true;
        //Debug.Log("_justHit = " + _justHit);
        yield return new WaitForSeconds(1f);
        _justHit = false;
        _invulnrable = false;
        //Debug.Log("_justHit = " + _justHit);
        StopCoroutine(JustGotHit());
    }
    protected void OnStateChanged(GameState newState) {
        if (newState == GameState.FreePlay) 
            _canMove = true;
        else
            _canMove = false;
    }
}


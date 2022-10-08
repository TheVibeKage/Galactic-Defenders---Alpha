using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryTurret : EnemyUnitBase
{
    [Header("Sentry Turret Variables")]
    //public static SentryTurret instance;
    private float _distance;
    private float _initialRotation = -90;
    [SerializeField] private float _distanceToEngage = 200;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _fireType;
    [SerializeField] private Renderer _activationLight;
    [SerializeField] private float _timeBetweenShots;
    private bool _isActivated;

    private float _temp;

    //unused variables
    public IEnumerator _engageTarget;
    private bool _isCoroutineStarted;

    void Start(){
        _isActivated = true;
        _timeBetweenShots = _unitStats.AttackSpeed;
        _rigidBody = this.GetComponent<Rigidbody2D>();
        StartCoroutine(PlayerUnitBase.instance._getPosition);
    }

    void Update()
    {
        if (_canMove == true && _isActivated == true){

            Vector3 direction = PlayerUnitBase.instance._position.position - transform.position;
            _distance = Vector3.Distance(PlayerUnitBase.instance._position.position, transform.position);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            //implement transitions from player angle to resting angle
            if(_distance <= _distanceToEngage){
                _rigidBody.rotation = angle;

                if(_timeBetweenShots <= 0){
                    Instantiate(_fireType, _firePoint.position, transform.rotation);
                    _timeBetweenShots = _unitStats.AttackSpeed;
                }
                else{
                    _timeBetweenShots -= Time.deltaTime;
                }   
                
            }
            if (_distance > _distanceToEngage){
                _rigidBody.rotation = _initialRotation;

            }
        }

        if(_isActivated == false){
            _activationLight.material.SetColor("_Color", Color.red);
        }

    }

    //Find way to replace FireShot with a Coroutine
    public IEnumerator EngageTarget()
    {
        _isCoroutineStarted = true;
        while(true){
            Instantiate(_fireType, _firePoint.position, transform.rotation);
            yield return new WaitForSeconds(1f);
        }
        
    }

    private IEnumerator CoroutineChange(){
        yield return new WaitForSeconds(1f);
    }
}

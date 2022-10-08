using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUnitBase : UnitBase{


    [Header("Player Unit Base Variables")]
    public static PlayerUnitBase instance;
    public IEnumerator _getPosition;
    [HideInInspector] public Transform _position;
    [SerializeField] protected Renderer _shipColor;
    public Transform firePoint;
    public GameObject fireType;
    protected Camera theCam; //currently not being used

    
    [Header("Dash Variables")]
    [SerializeField] private float _dashingVelocity = 100f;
    [SerializeField] private float _dashingTime = 0.5f;
    private Vector2 _dashingDirection;
    protected bool _isDashing;
    protected bool _canDash;
    protected IEnumerator _stopDashing;

    void Awake() {
        _ionDamage = IonDamage();
        _justHitCo = JustGotHit();
        _invulnrable = false;
        _justHit = false;

        instance = this;
        _rigidBody = GetComponent<Rigidbody2D>();
        GameManager.OnBeforeStateChanged += OnStateChanged;
        theCam = Camera.main;
        _canDash = true;
        _position = GetComponent<Transform>();
        _getPosition = GetPosition();
        _stopDashing = StopDashing();

    }

    void Update()
    {
        if (_canMove == true){

            _shieldObj.SetActive(_invulnrable);

            if(_isDashing == false){
                _rigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * _unitStats.Speed;
            }

            Vector3 mouse = Input.mousePosition;
            Vector3 screenPoint = theCam.WorldToScreenPoint(transform.localPosition);
            Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
            float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

            if(Input.GetMouseButtonDown(0)){
                Instantiate(fireType, firePoint.position, transform.rotation);
            }

            if(Input.GetKeyDown(KeyCode.Space) && _canDash == true){
                _isDashing = true;
                _canDash = false;
                if(_invulnrable == false){
                    _invulnrable = true;
                }
                _dashingDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                StartCoroutine(StopDashing());
            }

            if(_isDashing){
                _rigidBody.velocity = _dashingDirection.normalized * _dashingVelocity;
                return;
            }

            //_shieldObj.SetActive(_invulnrable);

        }
    }

    protected void OnDestroy(){
        GameManager.OnBeforeStateChanged -= OnStateChanged;
        GameManager.instance.UpdateGameState(GameState.Lose);
        
    }
    public IEnumerator GetPosition(){

        _position = this.GetComponent<Transform>();
        yield return new WaitForEndOfFrame();
    }

    protected IEnumerator StopDashing(){

        yield return new WaitForSeconds(_dashingTime);

        if(_justHit == false){
            _invulnrable = false;
        }
        _isDashing = false;
        _canDash = true;
        
    }

}

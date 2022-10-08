using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBoss : BossBase
{
    public float _speed = 10.0f;
    public float _acceleration;

    [Header("Vertical Beam Variables")]
    public GameObject[] _beamCannons;
    public GameObject[] _activeBeams;
    public GameObject[] _inactiveBeams;
    public IEnumerator _beamAttack;
    public IEnumerator _reverseBeamAttack;
    public IEnumerator _beamAttackShutdown;
    public int _acc;
    //public Vector3[] _originalPositions;
    [Header("Horizonatal Beam Variables")]
    public GameObject[] _horizontalBeamCannons;
    public GameObject[] _horizontalActiveBeams;
    public GameObject[] _horizontalInactiveBeams;
    private bool _isMoving;
    private bool _isMovingReverse;
    private int _numOfRepeats;
    private int _numOfReverseRepeats;

    [Header("Target Objects")]
    public GameObject[] _targetsToDestroy;
    /////
    ///// Boolean Statge Variables
    ////
    private bool _temp;
    private bool _resumeAttack;
    private bool _stage1;
    private bool _stage2;
    private bool _stage3;
    private bool _stage4;
    private bool _stage5;
    private bool _stage6;
    private bool _stage7;

//////////////////////////////////////////////////
//              Declared Coroutines             //
//////////////////////////////////////////////////

    private IEnumerator _checking;
    private IEnumerator _stopAttack;


    void Start()
    {
        for(int i = 0; i < _beamCannons.Length; i ++){
            _activeBeams[i].SetActive(false);
            _inactiveBeams[i].SetActive(false);
        }

        for(int i = 0; i < _horizontalBeamCannons.Length; i ++){
            _horizontalActiveBeams[i].SetActive(false);
            _horizontalInactiveBeams[i].SetActive(false);
        }

        _beamAttack = BeamAttack();
        _reverseBeamAttack = ReverseBeamAttack();
        _beamAttackShutdown = BeamAttackShutdown();
        _checking = Checking();
        _stopAttack =StopAttack();
        //StartCoroutine(_beamAttack);
        _speed = _speed * Time.deltaTime;
        _numOfRepeats = 0;
        _numOfReverseRepeats = 0;
        _stage1 = false;
        UpdateBossStage(BossStage.Stage0);

    }

    // Update is called once per frame
    void Update()
    {
        if(_stage1 == true){

            if(_numOfRepeats <= 20){
                foreach(GameObject beamCannons in _beamCannons){
                    beamCannons.transform.position = Vector3.MoveTowards(beamCannons.transform.position, new Vector3(300,130,0), _speed);

                    if(beamCannons.transform.position == new Vector3(300,130,0)){
                        //Debug.Log(_numOfRepeats);
                        _numOfRepeats++;
                        Debug.Log(_numOfRepeats);
                        beamCannons.transform.position = new Vector3(-300,130,0);
                    }
                }

                foreach(GameObject horizontalBeamCannons in _horizontalBeamCannons){
                    horizontalBeamCannons.transform.position = Vector3.MoveTowards(horizontalBeamCannons.transform.position, new Vector3(0,-180,1), _speed);

                    if(horizontalBeamCannons.transform.position == new Vector3(0,-180,1)){
                        horizontalBeamCannons.transform.position = new Vector3(0,170,1);
                    }
                }

                if(_numOfRepeats == 21){
                    StartCoroutine(_stopAttack);
                }
            }

            if(_numOfRepeats > 20 && _resumeAttack == true){

                foreach(GameObject beamCannons in _beamCannons){
                    beamCannons.transform.position = Vector3.MoveTowards(beamCannons.transform.position, new Vector3(-300,130,0), _speed);

                    if(beamCannons.transform.position == new Vector3(-300,130,0)){
                        _numOfRepeats++;
                        Debug.Log(_numOfRepeats);
                        beamCannons.transform.position = new Vector3(300,130,0);
                    }
                }

                foreach(GameObject horizontalBeamCannons in _horizontalBeamCannons){
                    horizontalBeamCannons.transform.position = Vector3.MoveTowards(horizontalBeamCannons.transform.position, new Vector3(0,170,1), _speed);

                    if(horizontalBeamCannons.transform.position == new Vector3(0,170,1)){
                    horizontalBeamCannons.transform.position = new Vector3(0,-180,1);

                    }
                }
            }

            if(_numOfRepeats == 40){
                _stage1 = false;
                StartCoroutine(_beamAttackShutdown);
                UpdateBossStage(BossStage.Stage2);
            }
        }

        /*if(_numOfRepeats == 20){
            _isMoving = false;
            _numOfRepeats = 0;
            UpdateBossStage(BossStage.Stage2);
            StartCoroutine(_reverseBeamAttack);
        }

        if(_isMovingReverse == true && _numOfReverseRepeats != 20){

            foreach(GameObject beamCannons in _beamCannons){
                 beamCannons.transform.position = Vector3.MoveTowards(beamCannons.transform.position, new Vector3(-300,130,0), _speed);

                 if(beamCannons.transform.position == new Vector3(-300,130,0)){
                    Debug.Log(_numOfReverseRepeats);
                    _numOfReverseRepeats++;
                    beamCannons.transform.position = new Vector3(300,130,0);
                 }
            }

            foreach(GameObject horizontalBeamCannons in _horizontalBeamCannons){
                 horizontalBeamCannons.transform.position = Vector3.MoveTowards(horizontalBeamCannons.transform.position, new Vector3(0,170,1), _speed);

                 if(horizontalBeamCannons.transform.position == new Vector3(0,170,1)){
                    horizontalBeamCannons.transform.position = new Vector3(0,-180,1);
                 }
            }
        }
        if(_numOfReverseRepeats == 20){
            _isMovingReverse = false;
            _numOfReverseRepeats = 0;
            StartCoroutine(_beamAttackShutdown);
        }*/
        
    }

//////////////////////////////////////////////////
//             Custom Game Functions            //
//////////////////////////////////////////////////

    void tempFunction(){
        foreach(GameObject beamCannons in _beamCannons){
             beamCannons.transform.position = Vector3.MoveTowards(beamCannons.transform.position, new Vector3(300,130,0), _speed);

             if(beamCannons.transform.position == new Vector3(300,130,0)){                    
                Debug.Log(_numOfRepeats);
                _numOfRepeats++;
                beamCannons.transform.position = new Vector3(-300,130,0);
            }
        }

        foreach(GameObject horizontalBeamCannons in _horizontalBeamCannons){
            horizontalBeamCannons.transform.position = Vector3.MoveTowards(horizontalBeamCannons.transform.position, new Vector3(0,-180,1), _speed);

            if(horizontalBeamCannons.transform.position == new Vector3(0,-180,1)){
                horizontalBeamCannons.transform.position = new Vector3(0,170,1);
            }
        }
    }

    protected override void HandleStage0(){
        //spawn game objects that will be destroyed to initiate next boss stage
        StartCoroutine(_checking);
    }

    protected override void HandleStage1(){
        StartCoroutine(_beamAttack);
    }
    protected override void HandleStage2(){
        
    }
    protected override void HandleStage3(){
        
    }
    protected override void HandleStage4(){
        
    }
    protected override void HandleStage5(){
        
    }
    protected override void HandleStage6(){
        
    }
    protected override void HandleStage7(){
        
    }

//////////////////////////////////////////////////
//              Boss Coroutines                 //
//////////////////////////////////////////////////

    public IEnumerator Checking(){
        bool _stop = true;
        while(_stop){
            if(GameObject.FindGameObjectWithTag("Destructable") == null){
                //Debug.Log("is working as intended");
                _stop = false;
                yield return null;
            }
            yield return null;
        }
        UpdateBossStage(BossStage.Stage1);
    }

    public IEnumerator StopAttack(){
        Debug.Log("Working");
        yield return new WaitForSeconds(2f);
        _resumeAttack = true;
    }

   public IEnumerator BeamAttack(){

        for(int i = 0; i < _beamCannons.Length; i ++){
            _inactiveBeams[i].SetActive(true);
        }
        for(int i = 0; i < _horizontalBeamCannons.Length; i ++){
            _horizontalInactiveBeams[i].SetActive(true);
        }

        yield return new WaitForSeconds(5f);

        for(int i = 0; i < _horizontalBeamCannons.Length; i ++){
            _horizontalInactiveBeams[i].SetActive(false);
            _horizontalActiveBeams[i].SetActive(true);
        }
        for(int i = 0; i < _beamCannons.Length; i ++){
            _inactiveBeams[i].SetActive(false);
            _activeBeams[i].SetActive(true);
            
        }
        yield return new WaitForSeconds(1f);

        _stage1 = true;
   }
   public IEnumerator ReverseBeamAttack(){

        yield return new WaitForSeconds(2f);

        for(int i = 0; i < _beamCannons.Length; i ++){
            _activeBeams[i].SetActive(false);
            _inactiveBeams[i].SetActive(false);
        }

        for(int i = 0; i < _horizontalBeamCannons.Length; i ++){
             _horizontalActiveBeams[i].SetActive(false);
               _horizontalInactiveBeams[i].SetActive(false);
        }

        for(int i = 0; i < _beamCannons.Length; i ++){
            _inactiveBeams[i].SetActive(true);
        }
        for(int i = 0; i < _horizontalBeamCannons.Length; i ++){
            _horizontalInactiveBeams[i].SetActive(true);
        }

        yield return new WaitForSeconds(5f);

        for(int i = 0; i < _horizontalBeamCannons.Length; i ++){
            _horizontalInactiveBeams[i].SetActive(false);
            _horizontalActiveBeams[i].SetActive(true);
        }
        for(int i = 0; i < _beamCannons.Length; i ++){
            _inactiveBeams[i].SetActive(false);
            _activeBeams[i].SetActive(true);
            _isMovingReverse = true;
        }
        StopCoroutine(ReverseBeamAttack());

   }

   public IEnumerator BeamAttackShutdown(){

        yield return new WaitForSeconds(2f);

        for(int i = 0; i < _beamCannons.Length; i ++){
            _activeBeams[i].SetActive(false);
            _inactiveBeams[i].SetActive(false);
        }

        for(int i = 0; i < _horizontalBeamCannons.Length; i ++){
             _horizontalActiveBeams[i].SetActive(false);
               _horizontalInactiveBeams[i].SetActive(false);
        }

        StopCoroutine(BeamAttackShutdown());

   }
}

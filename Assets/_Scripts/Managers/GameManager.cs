using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : StaticInstance<GameManager>
{
    public static event Action<GameState> OnBeforeStateChanged;
    public static event Action<GameState> OnAfterStateChanged;

    public GameState State { get; private set; }


    void Start() {
        UpdateGameState(GameState.Starting);
    }
    
    public void UpdateGameState(GameState newState) {

        OnBeforeStateChanged?.Invoke(newState);

        State = newState;

        switch (newState){

            case GameState.Starting:
                HandleStarting();
                break;
            case GameState.SpawnPlayer:
                HandleSpawnPlayer();
                break;
            case GameState.SpawnEnemies:
                HandleSpawnEnemies();
                break;
            case GameState.FreePlay:
                HandleFreePlay();
                break;
            case GameState.Victory:
                HandleVictory();
                break;
            case GameState.Lose:
                HandleLose();
                break;
            case GameState.Reset:
                HandleReset();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);

        }

        OnAfterStateChanged?.Invoke(newState); 

        Debug.Log($"New state: {newState}");       
    }

    private void HandleStarting(){
        UpdateGameState(GameState.SpawnPlayer);
    }

    private void HandleSpawnPlayer(){
        UnitManager.instance.SpawnPlayer();
        UpdateGameState(GameState.SpawnEnemies);
    }

    private void HandleSpawnEnemies(){
        UnitManager.instance.SpawnEnemies();
        UpdateGameState(GameState.FreePlay);
    }

    private void HandleFreePlay(){
        //ExampleUnitManager.Instance.Decision();
    }

    private void HandleVictory(){

        ActivateScreen.instance._VistoryScreen.SetActive(true);
        
    }

    private void HandleLose(){

        ActivateScreen.instance._LoseScreen.SetActive(true);
        
    }
    private void HandleReset(){

        SceneManager.LoadScene(0);
        
        
    }
     public void DeleteAll(){

        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("EnemyBase");

        //taggedObjects = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject o in taggedObjects) {
             Destroy(o);
         }

        GameObject[] taggedObjects1 = GameObject.FindGameObjectsWithTag("Player");

        //taggedObjects = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject o in taggedObjects1) {
             Destroy(o);
         }
     }
}


[Serializable]
    public enum GameState {
        
        Starting = 0,
        SpawnPlayer = 1,
        SpawnEnemies = 2,
        FreePlay = 3,
        Victory = 4,
        Lose = 5,
        Reset = 6
    }


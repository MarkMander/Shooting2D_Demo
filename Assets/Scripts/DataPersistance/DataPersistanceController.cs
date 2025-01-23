using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceController : MonoBehaviour
{
    private GameState gameState;
    private List<IDataPersistance> dataPersObjs;
    public static DataPersistanceController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Why the fuck is there another Data Controller here!", Instance);
        }   
        Instance = this;
    }

    private void Start()
    {
        dataPersObjs = FindDataPersObjs();
        LoadGame();
    }
     
    public void NewGame()
    {
        this.gameState = new GameState();
    }

    private void SaveGame()
    {
        //TODO send the gameState object to other classes so they can update it as needed

        //TODO use data handler to write gameState object information 
    }

    private void LoadGame()
    {
        //TODO use dataHandler to load gamestate 
        // if no data is found, that means we need to start a new game 
        if (this.gameState == null)
        {
            Debug.Log("No game data was found, initializing new game");
            NewGame();
        }
        //TODO send saved GameState to all functions that may need it
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistance> FindDataPersObjs()
    {
        IEnumerable<IDataPersistance> dataPersObjs = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        return new List<IDataPersistance>(dataPersObjs); 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class DataPersistanceController : MonoBehaviour
{
    private GameState gameState; 
    private List<IDataPersistance> dataPersObjs;
    [SerializeField] private string fileName;
    private FileDataHandler fileDataHandler;
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
        fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        dataPersObjs = FindDataPersObjs();
        LoadGame();
    }
     
    public void NewGame()
    {
        this.gameState = new GameState();
    }

    private void SaveGame()
    {
        foreach (IDataPersistance dataObj in dataPersObjs)
        {
            dataObj.SaveData(ref gameState);
        }

        fileDataHandler.Save(gameState);

        Debug.Log("Saving score " + gameState.totalScore);
    }

    private void LoadGame()
    {
        gameState = fileDataHandler.Load();
        if (this.gameState == null)
        {
            Debug.Log("No game data was found, initializing new game");
            NewGame();
        }

        foreach (IDataPersistance dataObj in dataPersObjs)
        {
            dataObj.LoadData(gameState); 
        }
        Debug.Log("Loading score " + gameState.totalScore);
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

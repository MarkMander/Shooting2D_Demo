using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDir;
    private string fileName;

    public FileDataHandler(string dataDir, string fileName)
    {
        this.dataDir = dataDir;
        this.fileName = fileName;
    }

    public GameState Load()
    {
        string path = Path.Combine(dataDir, fileName);
        GameState gameState = null;
        if (File.Exists(path)) {
            string loadData = "";
            try
            {
                using(FileStream stream = new FileStream(path,FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        loadData = reader.ReadToEnd();
                    }
                }
            }
            catch(Exception e)
            {
                Debug.LogError("Error while trying to load file\n" + e);
            }
            gameState = JsonUtility.FromJson<GameState>(loadData);
        }
        else
        {
            Debug.Log("File Not Found");
        }
        return gameState;
    }

    public void Save(GameState state)
    {
        string path = Path.Combine(dataDir, fileName); 
        try
        {
            Directory.CreateDirectory(dataDir);
            string dataStore = JsonUtility.ToJson(state,true);

            using (FileStream stream = new FileStream(path,FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream)) 
                {
                    writer.Write(dataStore);
                }
            }            
        }
        catch (Exception e)
        {
            Debug.LogError("Error occured while saving data\n" + e);

        }

    }
}


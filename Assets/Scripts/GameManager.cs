using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName;
    public string playerNameBest;
    public int hiScore;
    private string DataFile;

    private void Awake() 
    {
        DataFile = Application.persistentDataPath + "/savefile.json";
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DataLoad();

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // json data structure
    [System.Serializable]
    class PlayerData
    {
        public string playerNameBest;
        public int score;
    }

    // save the data to json
    public void DataSave()
    {
        PlayerData data = new PlayerData();
        data.playerNameBest = playerNameBest;
        data.score = hiScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(DataFile, json);
    }

    // read the json saev file
    public void DataLoad()
    {
        if(File.Exists(DataFile))
        {
            string json = File.ReadAllText(DataFile);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            playerNameBest = data.playerNameBest;
            hiScore = data.score;
        }
    }
}

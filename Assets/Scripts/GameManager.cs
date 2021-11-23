using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.IO;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public MainManager mainManager;
    public TMP_InputField inputField;
    public string playerName;
    public string highScore;
    private Text displayName;
    string currentScene;
    

    private void Awake()
    {
        // if we already have this gameobject, destroy the duplicate that's created
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        currentScene = SceneManager.GetActiveScene().name;

        // set the playername ui if we are in the game and it has been set
        if (playerName != "" && currentScene == "main")
        {
            mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
            highScore = GameObject.Find("MainManager").GetComponent<MainManager>().ScoreText.ToString();
            displayName = GameObject.Find("Canvas/PlayerName").GetComponent<Text>();
            displayName.text = playerName;
        }
    }

    // start the game with input field name
    public void startGame()
    {
        //set player text, even if the input field is empty
        playerName = (inputField.text != ""? inputField.text : "Mystery Player");
        SceneManager.LoadScene("main");
    }

[System.Serializable]
class SaveData
{
    public string playerName;
    public string highScore;
}

public void SaveScore()
{
    SaveData data = new SaveData();
    data.playerName = playerName;
    data.highScore = highScore;

    string json = JsonUtility.ToJson(data);
  
    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
}

public void LoadScore()
{
    string path = Application.persistentDataPath + "/savefile.json";
    if (File.Exists(path))
    {
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        playerName = data.playerName;
        highScore = data.highScore;
    }
}
}
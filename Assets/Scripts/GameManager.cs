using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TMP_InputField inputField;
    public string playerName;
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
}
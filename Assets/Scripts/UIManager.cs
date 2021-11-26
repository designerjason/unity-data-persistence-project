using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public InputField playerNameInput;

    public void StartGame()
    {
        GameManager.Instance.playerName = playerNameInput.text;
        Debug.Log(GameManager.Instance.playerName.ToString());
        SceneManager.LoadScene("main");
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public Text bestScoreText;
    public int bestScore;
    public string bestPlayerName;
    public InputField input;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.LoadHighScore();

        bestPlayerName = GameManager.Instance.bestPlayerName;
        bestScore = GameManager.Instance.bestScore;

        if (GameManager.Instance.bestScore != 0)
        {
            bestScoreText.text = "Best Score : " + bestPlayerName + " : " + bestScore;

            Debug.Log(Application.persistentDataPath);
        }
    }
    // Update is called once per frame
    public void StartGame()
    {
        GameManager.Instance.currentPlayerName = input.text;
        Debug.Log("entered name: " + GameManager.Instance.currentPlayerName);
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] private Button start;
    [SerializeField] private Button exit;

    private void Start()
    {
        JsonPlayerPrefs prefs = new JsonPlayerPrefs(Application.persistentDataPath + "/Preferences.json");
        float bestTime = prefs.GetFloat("hiscore");
        int minutes = Mathf.FloorToInt(bestTime / 60);
        int seconds = Mathf.FloorToInt(bestTime % 60);
        time.SetText(string.Format("{0:00}:{1:00}", minutes, seconds));
        start.onClick.AddListener(() => startGame());
        exit.onClick.AddListener(() => exitGame());
    }

    private void startGame()
    {
        SceneManager.LoadScene("Game");
    }
    private void exitGame()
    {
        Application.Quit();
    }
}

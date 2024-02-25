using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject highscoreGO;

    [SerializeField] public Boolean playing = true;

    private float timer = 0f;


    private void Start()
    {
        timer = 0f;
    }

    private void Update()
    {
        if (playing)
        {
            timer += Time.deltaTime;

            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);
            timerText.SetText(string.Format("{0:00}:{1:00}", minutes, seconds));
        }
    }

    public void record()
    {
        playing = false;
        JsonPlayerPrefs prefs = new JsonPlayerPrefs(Application.persistentDataPath + "/Preferences.json");
        float bestTime = prefs.GetFloat("hiscore");
        if (prefs.HasKey("hiscore"))
        {
            if (timer < prefs.GetFloat("hiscore"))
            {
                prefs.SetFloat("hiscore", timer);
                prefs.Save();
                highscoreGO.SetActive(true);

            }
        }
        else
        {
            prefs.SetFloat("hiscore", timer);
            prefs.Save();
            highscoreGO.SetActive(true);
        }
    }
}

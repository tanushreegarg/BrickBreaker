using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour {

    [Header("MainMenu")]
    public Canvas Mainmenu;
    public Canvas Highscore;
    public Canvas Setting;

    [Header("HighScore")]
    public Text[] player;
    public Text[] score;

    [Header("Settings")]
    public AudioMixer MusicAudio;


    public void Start()
    {

        Mainmenu.gameObject.SetActive(true);
        Highscore.gameObject.SetActive(false);
        Setting.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (Application.platform == RuntimePlatform.Android && Input.GetKey(KeyCode.Escape))
        {

            if (Mainmenu.isActiveAndEnabled)
            {
                Application.Quit();
                return;
            }
            else 
            {
                Back();
            }


        }
    }

    public void Back()
    {
        Highscore.gameObject.SetActive(false);
        Setting.gameObject.SetActive(false);
        Mainmenu.gameObject.SetActive(true);
    }
        

    //Functions For Main Menu Canvos Buttons
    public void StartGame()
    {
        SceneManager.LoadScene("level1");
    }
    public void HighScore()
    {
        string tag;

        for (int i = 1; i <= 5; ++i)
        {
            tag = "Player0" + i.ToString();
            player[i - 1].text += PlayerPrefs.GetString(tag, "");
            tag = "score0" + i.ToString();
            score[i - 1].text = PlayerPrefs.GetString(tag, "000");
            if (PlayerPrefs.GetString(tag) == "")
                break;
        }

        Mainmenu.gameObject.SetActive(false);
        Highscore.gameObject.SetActive(true);
    }
    public void Settings()
    {
        Mainmenu.gameObject.SetActive(false);
        Setting.gameObject.SetActive(true);
    }
    public void Exit()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }
   

    //Functions For HighScore Canvos Buttons
    public void ResetScore()
    {
        PlayerPrefs.DeleteAll();
        for (int i = 1; i <= 5; ++i)
        {
            player[i - 1].text = i.ToString() + ". ";
            score[i - 1].text = "000";
        }
    }

    //Functions For Settings Canvos Buttons
    public void MusicSlider(float volume)
    {
        MusicAudio.SetFloat("Music Volume", volume);
    }

    public void EffectsSlider(float volume)
    {
        Debug.Log("Effects Slider moved");
    }

}

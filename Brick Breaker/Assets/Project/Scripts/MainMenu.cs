using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
// Music: https://www.bensound.com
public class MainMenu : MonoBehaviour {

    [Header("MainMenu")]
    public Canvas Mainmenu;
    public Canvas Highscore;
    public Canvas Setting;

    [Header("HighScore")]
    public Text score;

    [Header("Settings")]
    public AudioSource MusicAudio;
    public Slider Music;
    public Slider Effects;


    public void Start()
    {

        Mainmenu.gameObject.SetActive(true);
        Highscore.gameObject.SetActive(false);
        Setting.gameObject.SetActive(false);
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("level", 2);
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
       // DontDestroyOnLoad(MusicAudio);
        SceneManager.LoadScene("level1");
    }
    public void HighScore()
    {
        score.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        Mainmenu.gameObject.SetActive(false);
        Highscore.gameObject.SetActive(true);
    }
    public void Settings()
    {
        Mainmenu.gameObject.SetActive(false);
        Setting.gameObject.SetActive(true);
        Music.value = PlayerPrefs.GetFloat("MusicVolume", 1);
        Effects.value = PlayerPrefs.GetFloat("EffectVolume", 1);

    }
    public void Exit()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }
   

    //Functions For HighScore Canvos Buttons
    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        for (int i = 1; i <= 5; ++i)
        {
           score.text = "000";
        }
    }

    //Functions For Settings Canvos Buttons
    public void MusicSlider(float VolumeM)
    {
        PlayerPrefs.SetFloat("MusicVolume", VolumeM);
        MusicAudio.volume = VolumeM;
    }

    public void EffectsSlider(float VolumeE)
    {
        PlayerPrefs.SetFloat("EffectsVolume", VolumeE);
    }

}

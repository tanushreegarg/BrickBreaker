using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

    public int score;
    public int highScore;
    public Text HighScore;
    public Canvas enterName;
	// Use this for initialization
	void Start () {
        score = PlayerPrefs.GetInt("Score");
        highScore = PlayerPrefs.GetInt("HighScore",0);  

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (highScore > score)
        {
            HighScore.text = "Your Score: " + score;           
        }
        else
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            //HighScore.text = "HighScore: " + highScore + "\n By: " + uname;
        }
	}

    public void EnterName()
    {
        enterName.gameObject.SetActive(true);
    }
}

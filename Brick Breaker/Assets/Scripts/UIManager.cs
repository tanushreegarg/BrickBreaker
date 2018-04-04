using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public int score;
    public int playerlife = 3;
    public Canvas level;
    public Text scoreText;
    public Text lifeText;
    
    public Button nextLevel;

    public Canvas PauseMenu;

    	// Use this for initialization
	void Start () {
        scoreText.text = "Score: " + score;
    }
	
	// Update is called once per frame
	void Update ()
    {
        lifeText.text = "Lives: " + playerlife;
        
	}
    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;
    }
    public void DeductLife(int val)
    {        
        playerlife -= val;
        if(playerlife == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    public void Pause()
    {
        Time.timeScale = 0;
        level.gameObject.SetActive(false);
        PauseMenu.gameObject.SetActive(true);
    }

}

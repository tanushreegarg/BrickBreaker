using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public int score;
    public int playerlife = 3;
    public Text scoreText;
    public Text lifeText;
	// Use this for initialization
	void Start () {
		
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
}

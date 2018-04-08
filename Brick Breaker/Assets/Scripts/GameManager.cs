using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

    public float time = 100f;
    public Text timeup;
    private int lvl;
    public BallControl ball;
    public GameObject ui;


	// Use this for initialization
	void Start () {
        Time.timeScale = 1f;
        lvl = PlayerPrefs.GetInt("Level", 2);
        ui.gameObject.GetComponent<UIManager>().score = PlayerPrefs.GetInt("Score",0);
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(ball.timer==true)
        {
            time -= Time.deltaTime;
            if (time <= 0f || ui.GetComponent<UIManager>().playerlife == 0)
            {
                if (lvl < 4)
                {
                    Debug.Log("Level Over");
                    Time.timeScale = 0f;
                    timeup.gameObject.SetActive(true);

                    PlayerPrefs.SetInt("Score", ui.gameObject.GetComponent<UIManager>().score);
                    Wait();
                    SceneManager.LoadScene(lvl);
                    ++lvl;
                    PlayerPrefs.SetInt("Level", lvl);                    
                }
                else
                {


                    Debug.Log("Game over");
                    Time.timeScale = 0f;
                    timeup.gameObject.SetActive(true);
                    Wait();
                    SceneManager.LoadScene(lvl);
                    lvl = 2;
                    PlayerPrefs.SetInt("Level", lvl);
                    
                    

                }

            }
           
        }      

    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(5f);
    }
}

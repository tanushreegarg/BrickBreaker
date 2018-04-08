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
    string subject = "Brick Breaker";
    string body;
    // Use this for initialization
    void Start () {
        score = PlayerPrefs.GetInt("Score");
        highScore = PlayerPrefs.GetInt("HighScore",0);
        if (highScore > score)
        {
            HighScore.text = "Your Score: " + score;
            body = "Your Friend Scored: " + score.ToString();
        }
        else
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            HighScore.text = "HighScore: " + highScore;
            body = "Your Friend got a HighScore: " + highScore.ToString();
        }
        PlayerPrefs.DeleteKey("Score");
    }
	
	// Update is called once per frame
	void Update ()
    {
       
	}

    public void EnterName()
    {
        enterName.gameObject.SetActive(true);
    }

    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ShareText()
    {
        //execute the below lines if being run on a Android device
#if UNITY_ANDROID
        //Refernece of AndroidJavaClass class for intent
        AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
        //Refernece of AndroidJavaObject class for intent
        AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
        //call setAction method of the Intent object created
        intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
        //set the type of sharing that is happening
        intentObject.Call<AndroidJavaObject>("setType", "text/plain");
        //add data to be passed to the other activity i.e., the data to be sent
        intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject);
        intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), body);
        //get the current activity
        AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
        //start the activity by sending the intent data
        currentActivity.Call("startActivity", intentObject);
#endif

    }
}

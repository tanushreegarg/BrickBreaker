using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Back : MonoBehaviour {

    public Canvas Level;

    public void BACK()
    {
        this.gameObject.SetActive(false);
        Level.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        SceneManager.LoadScene("Main Menu");
    }

    // Update is called once per frame
    void Update () {
		
	}
}

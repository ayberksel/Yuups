using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Text highscoreText;

	void Start() {
		highscoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt ("Highscore").ToString ();
	}

	public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}

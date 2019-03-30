using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Score : MonoBehaviour {
	public static int score;
	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (score > PlayerPrefs.GetInt ("Highscore", 0)) {
			PlayerPrefs.SetInt ("Highscore", score);
		}
	}
}

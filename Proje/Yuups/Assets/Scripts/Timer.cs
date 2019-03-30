using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    private float startTime;
	public GameObject player;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<Player_Collision>().gameEnd == false) {
			float t = Time.time - startTime;

			string minutes = (((int)t / 60).ToString ());
			string seconds = (t % 60).ToString ("f0");

			if (t < 10 * 60) {          
				timerText.text = "0" + minutes + ":" + CheckSeconds (seconds);
			} else {
				timerText.text = minutes + ":" + CheckSeconds (seconds);
			}
		}
    }

    string CheckSeconds(string seconds_)
    {
        switch (seconds_)
        {
            case "0":
                seconds_ = "00";
                break;
            case "1":
                seconds_ = "01";
                break;
            case "2":
                seconds_ = "02";
                break;
            case "3":
                seconds_ = "03";
                break;
            case "4":
                seconds_ = "04";
                break;
            case "5":
                seconds_ = "05";
                break;
            case "6":
                seconds_ = "06";
                break;
            case "7":
                seconds_ = "07";
                break;
            case "8":
                seconds_ = "08";
                break;
            case "9":
                seconds_ = "09";
                break;
            case "60":
                seconds_ = "00";
                break;
        }
        return seconds_;
    }

}

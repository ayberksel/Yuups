using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour {

	public int playerJumpPower = 500;
	public AudioClip jumpSound;
    public bool isTouch;

    // Update is called once per frame
    void Update()
    {
        /*if (isTouch == true) {
			if (Input.touchCount > 0) {
				Touch myTouch = Input.touches [0];
				if (myTouch.phase == TouchPhase.Began) {
					Jump ();
				}
			}
		}
        else {
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }*/
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

    }

	void Jump() {
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * playerJumpPower);
		GetComponent<AudioSource> ().PlayOneShot (jumpSound, 1.2f);
	}
}

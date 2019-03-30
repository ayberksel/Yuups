using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Move : MonoBehaviour {

	public int coinSpeed;

	// Use this for initialization
	void Start () {
		coinSpeed = 7;
	}

	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-1, 0) * coinSpeed;
		if (gameObject.GetComponent<Transform> ().localPosition.x < -15)
			Destroy (gameObject);
	}
}
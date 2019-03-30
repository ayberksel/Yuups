using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour {
	public int enemySpeed;

	void Start() {
		enemySpeed = 10;
	}

	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-1, 0) * enemySpeed;
		if (gameObject.GetComponent<Transform> ().localPosition.x < -15)
			Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "enemy")
			Destroy (gameObject);
	}
}
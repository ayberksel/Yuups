using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour {

	private float backgroundLength = 32f;
	public float backgroundSpeed = 2f;
	public List<GameObject> backgroundCollection;

	void Start() {
		backgroundCollection.Add (GameObject.FindGameObjectWithTag ("background1"));
		backgroundCollection.Add (GameObject.FindGameObjectWithTag ("background2"));
	}

	void Update () {
		MoveAndLoopCity ();
	}

	void MoveAndLoopCity () {
		foreach (GameObject background in backgroundCollection) {
			Vector3 newbackgroundPos = background.transform.position;
			newbackgroundPos.x -= backgroundSpeed * Time.deltaTime;
			if (newbackgroundPos.x < (-40-backgroundLength) / 2)
				newbackgroundPos.x += 2*backgroundLength;
			background.transform.position = newbackgroundPos;
		}
	}
}
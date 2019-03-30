using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Spawner : MonoBehaviour {

	// Use this for initialization
	public GameObject coin;
	public GameObject enemy;
	public GameObject player;
	private float coinTimer = 2.0f;
	private float enemyTimer = 2.0f;

	// Update is called once per frame
	void Update () {
		coinTimer -= Time.deltaTime;
		enemyTimer -= Time.deltaTime;
		if (coinTimer < 0) {
			if(player.GetComponent<Player_Collision>().gameEnd == false){
				SpawnCoin ();
			}
		}
		if (enemyTimer < 0) {
			if(player.GetComponent<Player_Collision>().gameEnd == false){
				SpawnEnemy ();
			}
		}
	}

	void SpawnCoin() {
		GameObject c = Instantiate (coin, new Vector2 (20, Random.Range (-4.5f, 2.0f)), Quaternion.identity) as GameObject;
		coinTimer = Random.Range (0.5f, 2.5f);
	}

	void SpawnEnemy() {
		GameObject c = Instantiate (enemy, new Vector2 (20, Random.Range (-4.5f, 2.0f)), Quaternion.identity) as GameObject;
		enemyTimer = Random.Range (1.0f, 2.5f);
	}
}

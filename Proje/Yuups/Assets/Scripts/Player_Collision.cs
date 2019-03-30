using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Collision : MonoBehaviour {

	public GameObject cam;
	private int health;
	private float transparencyTime = 1.5f;
	private bool enemyCollided = false;
	private bool invulnerability = false;
    public GameObject coinUI;
	public AudioClip collectToken;
	public AudioClip hitEnemy;
	public GameObject gameOverMenu;
	public bool gameEnd = false;
	private Color tmp = new Color (1f, 1f, 1f, 1f);

	void Start () {
		health = 3;
	}

	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<SpriteRenderer> ().color = tmp;
		checkHealth ();
		if (enemyCollided) {
			invulnerability = true;
			if (tmp.a != 0.2f)
				tmp.a = 0.2f;
			else
				tmp.a = 0.8f;
			transparencyTime -= Time.deltaTime;
			if (transparencyTime < 0) {
				tmp.a = 1f;
				transparencyTime = 1.5f;
				invulnerability = false;
				enemyCollided = false;
			}
		}
	}

	void checkHealth() {
		if (health < 0) {
			Die ();
		}
	}

	void Die() {
		gameObject.GetComponent<Rigidbody2D> ().gravityScale = 6.5f;
		if (gameEnd == false) {
			gameEnd = true;
			gameOverMenu.SetActive(true);
		}
	}
	public void Restart(){

		Time.timeScale = 1;

		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		//gameEnd == false;

	}
	void OnTriggerEnter2D(Collider2D trig) {
		if (trig.gameObject.tag == "coin") {
			Destroy (trig.gameObject);
			Player_Score.score += 100;
            if (gameObject.GetComponent<Transform>().localScale.x < 0.185)
            {
                transform.localScale += new Vector3(0.001f, 0.001f);
            }
            coinUI.GetComponent<UnityEngine.UI.Text>().text = ("Score:" + Player_Score.score.ToString());
			if (gameObject.GetComponent<Rigidbody2D> ().gravityScale > 2.5f) {
				gameObject.GetComponent<Rigidbody2D> ().gravityScale = 2.5f;
			} else if(gameObject.GetComponent<Rigidbody2D> ().gravityScale < 2.5f){
				gameObject.GetComponent<Rigidbody2D> ().gravityScale += 0.02f;
			}
			GetComponent<AudioSource> ().PlayOneShot (collectToken, 1f);
		}
		if (trig.gameObject.tag == "enemy") {
			if (!invulnerability) {
				enemyCollided = true;
				health--;
				if(health == 2)
					Destroy (GameObject.FindGameObjectWithTag("heart3"));
				if(health == 1)
					Destroy (GameObject.FindGameObjectWithTag("heart2"));
                if (health == 0)
                    Destroy(GameObject.FindGameObjectWithTag("heart1"));
				Destroy (trig.gameObject);
				GetComponent<AudioSource> ().PlayOneShot (hitEnemy, 2f);
				iTween.ShakePosition (cam, new Vector3 (0.2f, 0.2f, 0.2f), 1);
			}
		}
		if (trig.gameObject.tag == "lowend") {
			Die ();
		}
	}
}

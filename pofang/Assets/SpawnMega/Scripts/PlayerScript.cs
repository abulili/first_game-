using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
	Rigidbody2D rigid;

	public static float Health;
	public Text healthText;
	public GameObject gameOver;
	bool canJump = true;
	// Use this for initialization
	void Start ()
	{
		Health = 100f;
		rigid = gameObject.GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKey (KeyCode.LeftArrow)) {
			rigid.AddForce (new Vector3 (-20f, 0));
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			rigid.AddForce (new Vector3 (20f, 0));
		}
		if (Input.GetKeyDown (KeyCode.Space) && canJump) {
			rigid.velocity = new Vector2 (rigid.velocity.x, 7f);
			canJump = false;
		}
	
		if (rigid.velocity.x > 10f)
			rigid.velocity = new Vector2 (10f, rigid.velocity.y);
		if (rigid.velocity.x < -10f)
			rigid.velocity = new Vector2 (-10f, rigid.velocity.y);

		healthText.text = "Health " + Health;

		if (Health <= 0) {
			SpawnMega.isDead = true;
			gameOver.SetActive (true);
			Invoke ("reloadGame", 5f);
		}
	}

	void reloadGame ()
	{
		SpawnMega.isDead = false;
		SceneManager.LoadScene (0);
	}

	void FixedUpdate ()
	{
		rigid.position = new Vector2 (Mathf.Clamp (rigid.position.x, -8.5f, 8.5f), rigid.position.y);
	}

	void OnCollisionStay2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "floor") {

			canJump = true;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class badObject : MonoBehaviour
{
	Scene scene;
	// Use this for initialization
	void Start ()
	{
		scene = SceneManager.GetActiveScene ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnCollisionEnter2D (Collision2D Coll)
	{
		if (Coll.gameObject.tag == "Player") {
			PlayerScript.Health -= 25f;
		}
		if (Coll.gameObject.tag == "floor") {
			scoreManager.Score++;
			StartCoroutine (wait ());
		}
	}

	IEnumerator wait ()
	{
		yield return new WaitForSeconds (2);
		Destroy (gameObject);
	}
}

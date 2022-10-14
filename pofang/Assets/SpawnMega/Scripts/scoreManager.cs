using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
	public Text scoreText;
	public static int Score;
	// Use this for initialization
	void Start ()
	{
		Score = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (scoreText != null)
			scoreText.text = "Score: " + Score;
	}
}

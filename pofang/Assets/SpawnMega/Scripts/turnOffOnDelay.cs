using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOffOnDelay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("turnOffAfterDelay", 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void turnOffAfterDelay(){
		gameObject.SetActive (false);
	}
}

using UnityEngine;
using System.Collections;

public class CreateBalls : MonoBehaviour {

	// Use this for initialization
	void Start () {

		// Creates 2 balls at start
		for (int i = 1; i < 3; i++) {
			newBall ();
		}

		InvokeRepeating ("newBall", 5f, 5f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Instantiates one ball at origin
	void newBall () {
		Instantiate (GameObject.FindGameObjectWithTag("ball") , new Vector3 (0f, 0f, 0f), Quaternion.identity);
	}
}

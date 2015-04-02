using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		// Sets a random color
		SpriteRenderer renderer = gameObject.GetComponent <SpriteRenderer>();
		renderer.color = startColor();

	}

	// Randomly returns one of 3 predetermined colors
	Color startColor(){
		Color startColor;
		int newcolor = Random.Range (0, 3);
		if (newcolor == 0)
			startColor = new Color (0.4f, 1, 1);
		else if (newcolor == 1)
			startColor = new Color (1, 1, 0.4f);
		else 
			startColor = new Color (1, 0.4f, 1);
		return startColor;
	}

	// Update is called once per frame
	void Update () {

	}

	// Wall Collisions:
	void OnCollisionEnter2D (Collision2D col){
		// Collision with ball:
		if(col.gameObject.tag == "ball") {
			// Gets wall color
			SpriteRenderer wallRenderer = this.GetComponent<SpriteRenderer>();
			Color wallColor = wallRenderer.color;
			
			// Switches ball's color to wall's color
			SpriteRenderer ballRenderer = col.gameObject.GetComponent <SpriteRenderer>();
			ballRenderer.color = wallColor;

			LensFlare ballFlare = col.gameObject.GetComponent<LensFlare> ();
			ballFlare.color = wallColor;

			// Randomizes wall's new color
			wallRenderer.color = startColor();
		}

		audio.Play ();
	}
}

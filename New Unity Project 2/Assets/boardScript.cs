using UnityEngine;
using System.Collections;

public class boardScript : MonoBehaviour {

	public bool IsLeft = false;

	public KeyCode moveUp;
	public KeyCode moveDown;
	public KeyCode colorswap;
	public float speed = 30f;

	// Use this for initialization
	void Start () {
		// Sets a random color
		SpriteRenderer renderer = gameObject.GetComponent <SpriteRenderer>();
		renderer.color = startColor();
	
	}
	
	// Update is called once per frame
	void Update () {

				// Up and Down movement
				if (Input.GetKey (moveUp)) {
						float ypos = transform.position.y;
						float xpos = transform.position.x;
						ypos = ypos + speed * Time.deltaTime;
						transform.position = new Vector3 (xpos, ypos, 0f);
				}

				if (Input.GetKey (moveDown)) {
						float ypos = transform.position.y;
						float xpos = transform.position.x;
						ypos = ypos - speed * Time.deltaTime;
						transform.position = new Vector3 (xpos, ypos, 0f);
				}
				
				// Cycles through colors
				if (Input.GetKeyDown (colorswap)) {
						Color cyan = new Color (0.4f, 1, 1);
						Color magenta = new Color (1, 1, 0.4f);
						Color yellow = new Color (1, 0.4f, 1);
						SpriteRenderer renderer = this.gameObject.GetComponent<SpriteRenderer> ();
						Color color = renderer.color;
						if (color == cyan)
								renderer.color = magenta;
						if (color == magenta)
								renderer.color = yellow;
						if (color == yellow)
								renderer.color = cyan;
				}



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
	
}

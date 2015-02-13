using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	public int maxspeed = 30;
	public int minspeed = 20;

	// Use this for initialization
	void Start () {

		// Sets a random color
		SpriteRenderer renderer = gameObject.GetComponent <SpriteRenderer>();
		renderer.color = startColor();

		Color ballcolor = renderer.color;
		LensFlare ballflare = gameObject.GetComponent<LensFlare> ();
		ballflare.color = ballcolor;

		// Random start velocity
		int start_x = Random.Range (minspeed, maxspeed);
		int x_neg = Random.Range (0, 2);
		if (x_neg == 1) {
			start_x = -start_x;
			}
		int start_y = Random.Range (minspeed, maxspeed);
		int y_neg = Random.Range (0, 2);
		if (y_neg == 1) {
			start_y = -start_y;
		}

		Vector2 start_force = new Vector2 (start_x, start_y);

		rigidbody2D.AddForce(start_force, ForceMode2D.Impulse);
			
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

		// Gets ball color and collider - could make global var at start???
		SpriteRenderer ballrenderer = this.GetComponent<SpriteRenderer>();
		Color ballcolor = ballrenderer.color;
		Collider2D ballcollider = this.GetComponent<Collider2D>();

		// Finds all boards
		GameObject[] AllBoards = GameObject.FindGameObjectsWithTag("board");

		for (int i = 0; i < AllBoards.Length; i++){
			// Gets individual board color and collider
			SpriteRenderer boardrenderer = AllBoards[i].GetComponent<SpriteRenderer>();
			Collider2D boardcollider = AllBoards[i].GetComponent<Collider2D>();
			Color boardcolor = boardrenderer.color;
			// If board and ball color are different, tells them to ignore collisions
			if(boardcolor != ballcolor){
				Physics2D.IgnoreCollision(boardcollider, ballcollider, true);
			}
			// Resets collision if board and ball color are the same
			else{
				Physics2D.IgnoreCollision(boardcollider, ballcollider, false);
			}
		}
	
	}
	
}

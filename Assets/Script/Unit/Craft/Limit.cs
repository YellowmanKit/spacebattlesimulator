using System.Collections;
using UnityEngine;

public class Limit : Craft {

	float clampForce { get { return rb.mass * 2; } }

	void Update () {
		ClampPosition ();
	}

	void ClampPosition(){
		if(!outOfArea){ return; }

		float xDir =
		transform.position.x < xMin? 1f:
		transform.position.x > xMax? -1f:
		0f;

		float yDir =
		transform.position.y < yMin? 1f:
		transform.position.y > yMax?	-1f:
		0f;

		rb.AddForce (new Vector2 (clampForce * xDir, clampForce * yDir));
	}
}

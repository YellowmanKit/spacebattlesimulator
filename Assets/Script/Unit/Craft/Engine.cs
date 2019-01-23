using System.Collections;
using UnityEngine;

public class Engine : Craft {

	void FixedUpdate(){
		Accelerate ();
		Brake ();
	}

	public Vector2 destination;
	public void SetDestination(Vector2 newDest){
		destination = new Vector2(newDest.x < xMin? xMin: newDest.x > xMax? xMax: newDest.x,
		newDest.y < yMin? yMin: newDest.y > yMax? yMax: newDest.y);
	}
	public float acceleration;
	float engineForce { get { return rb.mass * acceleration; } }
	void Accelerate(){
		Vector2 diff = destination - (Vector2)transform.position;
		Vector2 forceToAdd = Vector3.Normalize(diff) * engineForce * Mathf.Clamp(diff.magnitude, 0f, 3f);
		rb.AddForce (forceToAdd);
	}

	public float maxSpeed, brakeDistance ,brakeFactor;
	bool braking { get { return
		Vector3.Distance (transform.position, destination) < brakeDistance ||
		rb.velocity.magnitude > maxSpeed; } }

	void Brake(){
		if (!braking) { return; }
		rb.velocity = rb.velocity * brakeFactor;
	}

}

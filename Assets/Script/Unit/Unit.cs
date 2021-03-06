﻿using System.Collections;
using UnityEngine;

public abstract class Unit : Script {

	protected Rigidbody2D rb { get { return GetComponent<Rigidbody2D>(); } }
	protected SpriteRenderer sr { get { return GetComponentInChildren<SpriteRenderer>(); }}
	protected bool dead{ get { return GetComponentInParent<Hitpoint>().isDead; } }

	protected float targetAlpha = 1;
	protected float minDelta = 0.001f;
	protected float currentAlpha { get { return sr.color.a; } }
	protected void Alpha(){
		var delta = (targetAlpha - currentAlpha) * deltaTime * 2f;
		SetAlpha (currentAlpha + (Mathf.Abs(delta) > minDelta? delta: delta > 0f? minDelta: -minDelta));
		if (currentAlpha > 0f) { return; }
		OnAlphaZero ();
	}

	protected void SetAlpha(float alpha){
		Color color = sr.color;
		color.a = alpha > 0f? alpha: 0f;
		sr.color = color;
	}

	protected abstract void OnAlphaZero();

	public void SetAllColliders(bool active) {
		foreach(Collider2D collider in GetComponents<Collider2D>()) { collider.enabled = active; }
	}

	protected float x { get { return transform.position.x; } }
	protected float y { get { return transform.position.y; } }
	protected bool outOfArea { get { return x > xMax || x < xMin || y > yMax || y < yMin;  } }

}

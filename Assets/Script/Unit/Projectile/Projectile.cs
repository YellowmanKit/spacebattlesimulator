using System.Collections;
using UnityEngine;

public abstract class Projectile : Unit {

	protected CapsuleCollider2D capsule { get { return GetComponent<CapsuleCollider2D>(); } }
	protected ParticleSystem onHitEffect { get { return GetComponentInChildren<ParticleSystem>(); } }

	protected void CheckIfOutOfArea(){
		if(outOfArea){ Destroy(gameObject, 1f); }
	}

	protected override void OnAlphaZero(){}

}

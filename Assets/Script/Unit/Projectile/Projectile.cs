using System.Collections;
using UnityEngine;

public abstract class Projectile : Unit {

	protected CapsuleCollider2D capsule { get { return GetComponent<CapsuleCollider2D>(); } }
	protected ParticleSystem onHitEffect { get { return GetComponentInChildren<ParticleSystem>(); } }

	protected float deadTime;
	protected void CheckDead(){ if(outOfArea || time > deadTime){ projectilePool.Destroyed(gameObject); } }

	protected override void OnAlphaZero(){}

}

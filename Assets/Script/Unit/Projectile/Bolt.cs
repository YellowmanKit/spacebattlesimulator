using System.Collections;
using UnityEngine;

public class Bolt : Projectile {

	public float initSpeed;
	void OnEnable(){ rb.velocity = transform.up * initSpeed; }

	void Update(){
		CheckIfOutOfArea();
	}

	void OnTriggerEnter2D(Collider2D other){
		Hitpoint otherHp = other.GetComponent<Hitpoint>();
		if(!otherHp){ return; }
		ApplyDamage(otherHp);
		OnHit();
	}

	void OnHit(){
		rb.velocity = Vector2.zero;
		sprite.enabled = false;
		capsule.enabled = false;
		onHitEffect.Play();
		Destroy(gameObject, 1f);
	}

	public float damage;
	void ApplyDamage(Hitpoint otherHitpoint){
		otherHitpoint.TakeDamage(damage);
	}

}

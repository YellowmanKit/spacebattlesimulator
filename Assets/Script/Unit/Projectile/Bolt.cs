using System.Collections;
using UnityEngine;

public class Bolt : Projectile {

	public float speed;
	void OnEnable(){
		rb.velocity = transform.up * speed;
		sprite.enabled = true;
		capsule.enabled = true;
		deadTime = float.MaxValue;
		used = false;
	}

	void OnHit(){
		onHitEffect.Play();
		rb.velocity = Vector2.zero;
		sprite.enabled = false;
		capsule.enabled = false;
		deadTime = time + 1f;
		used = true;
	}

	bool used;
	void OnTriggerEnter2D(Collider2D other){
		Hitpoint otherHp = other.GetComponent<Hitpoint>();
		if(!otherHp || used){ return; }
		ApplyDamage(otherHp);
		OnHit();
	}

	public float damage;
	void ApplyDamage(Hitpoint otherHitpoint){ otherHitpoint.TakeDamage(damage); }

	void Update(){ CheckDead(); }

}

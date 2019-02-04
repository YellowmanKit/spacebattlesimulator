using System.Collections;
using UnityEngine;

public class Bolt : Projectile {

	public float speed;
	void OnEnable(){
		rb.velocity = transform.up * speed;
		sr.enabled = true;
		capsule.enabled = true;
		deadTime = float.MaxValue;
		used = false;
	}

	void OnHit(){
		onHitEffect.Play();
		rb.velocity = Vector2.zero;
		sr.enabled = false;
		capsule.enabled = false;
		deadTime = time + 1f;
		used = true;
	}

	bool used;
	void OnTriggerEnter2D(Collider2D other){
		CheckIfHitCraft(other);
		CheckIfHitShield(other);
	}

	public float damage;
	void CheckIfHitCraft(Collider2D other){
		Hitpoint hitpoint = other.GetComponent<Hitpoint>();
		if(!hitpoint || used){ return; }
		hitpoint.TakeDamage(damage);
		OnHit();
	}

	void CheckIfHitShield(Collider2D other){
		Shield shield = other.GetComponent<Shield>();
		if(!shield || used){ return; }
		shield.TakeDamage(damage);
		transform.Rotate(new Vector3(0f, 0f, 180f));
		OnHit();
	}

	void Update(){ CheckDead(); }

}

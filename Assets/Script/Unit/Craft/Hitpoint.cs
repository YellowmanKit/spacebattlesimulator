using System.Collections;
using UnityEngine;

public class Hitpoint : Craft {

	public float hp, maxHp;
	public bool isDead { get { return hp <= 0f; } }
	void OnEnable(){
		SetAllColliders(true);
		hp = maxHp;
		targetAlpha = 1;
		SetAlpha(1f);
	}

	public void TakeDamage(float damage){
		SetAlpha(0.5f);
		hp -= damage;
		if(isDead){ OnDead(); }
	}

	public ParticleSystem destroyedEffect;
	void OnDead(){
		SetAllColliders(false);
		destroyedEffect.Play();
		targetAlpha = 0;
	}

	void Update(){ Alpha(); }

}

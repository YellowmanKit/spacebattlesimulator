using System.Collections;
using UnityEngine;

public class Hitpoint : Craft {

	public float hp, maxHp;
	public bool isDead;
	void OnEnable(){
		SetAllCollidersStatus(true);
		hp = maxHp;
		isDead = false;
		targetAlpha = 1;
	}

	public void TakeDamage(float damage){
		SetAlpha(0.5f);
		hp -= damage;
		if(hp <= 0f){ HitpointDroppedToZero(); }
	}

	public ParticleSystem destroyedEffect;
	void HitpointDroppedToZero(){
		SetAllCollidersStatus(false);
		destroyedEffect.Play();
		isDead = true;
		targetAlpha = 0;
	}

	void Update(){
		Alpha();
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Ability {

	protected override bool shallUse{ get { return true; } }
	protected override void UseAbility(){ }

	public float hp, maxHp;
	void OnEnable(){ Recharge(); }

	public override void Prewarm(){ Recharge(); }

	void Recharge(){
		SetAllColliders(true);
		SetAlpha(0f);
		targetAlpha = 0f;
		hp = maxHp;
	}

	public bool isDown { get { return hp <= 0f; } }
	public void TakeDamage(float damage){
		SetAlpha(sr.color.a + 0.3f);
		hp -= damage;
		if(isDown){ OnDown(); }
	}

	void OnDown(){
		SetAllColliders(false);
	}

	void Update () { Alpha(); }

}

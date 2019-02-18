using System.Collections;
using UnityEngine;

public class Launcher : Ability {

	protected override bool shallUse{ get { return true; } }

	public float prewarm;
	public override void Prewarm(){ next = time + prewarm + randomize; }

	public PType projectile;
	public ParticleSystem chargeEffect;
	protected override void UseAbility(){
		chargeEffect.Play();
		var psmain = chargeEffect.main;
		launchTime = time + psmain.duration;
	}

	void Update(){
		AttemptToUseAbility();
		Launch();
	}

	float launchTime = float.MaxValue;
	void Launch(){
		if(time < launchTime){ return; }
		launchTime = float.MaxValue;
		projectilePool.Spawn(projectile, transform);
	}

}

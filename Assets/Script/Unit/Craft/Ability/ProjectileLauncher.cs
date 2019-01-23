using System.Collections;
using UnityEngine;

public class ProjectileLauncher : Ability {

	void OnEnable(){
		Prewarm();
	}

	protected override bool shallUse(){ return true; }

	public GameObject projectile;
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
		Instantiate(projectile, transform.position, transform.rotation);
	}

}

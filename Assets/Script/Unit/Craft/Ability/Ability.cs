using System.Collections;
using UnityEngine;

public abstract class Ability : Script {

	public Vector2[] shotSpawns;
	public float coolDown, prewarm, variation;
	float randomize { get { return Random.Range (-variation, variation); } }

	protected float next;
	protected void Prewarm(){ next = time + prewarm + randomize; }

	bool craftIsDead{ get { return GetComponentInParent<Hitpoint>().isDead; } }
	bool canUse(){ return !craftIsDead && time > next; }
	protected abstract bool shallUse();
	protected abstract void UseAbility();
	protected void AttemptToUseAbility(){
		if (!canUse() || !shallUse()) { return; }
		next = time + Mathf.Clamp(coolDown + randomize, 0.02f, float.MaxValue);
		UseAbility ();
	}

}

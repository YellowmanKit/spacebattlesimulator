using System.Collections;
using UnityEngine;

public abstract class Ability : Script {

	void OnEnable(){ Prewarm(); }

	public Vector2[] shotSpawns;
	public float coolDown, prewarm;
	float randomize { get { return Random.Range (-1f, 1f); } }

	protected float next;
	public void Prewarm(){ next = time + prewarm + randomize; }

	bool dead { get { return GetComponentInParent<Hitpoint>().isDead; } }
	bool canUse { get { return time > next && !dead && game.phase == Phase.Battle; } }
	protected abstract bool shallUse { get; }

	protected abstract void UseAbility();
	protected void AttemptToUseAbility(){
		if (!canUse || !shallUse) { return; }
		next = time + Mathf.Clamp(coolDown, 0.01f, float.MaxValue);
		UseAbility ();
	}

}

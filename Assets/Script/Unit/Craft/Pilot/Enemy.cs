using System.Collections;
using UnityEngine;

public class Enemy : Pilot {

	public float engageDistance;
	public Transform targetCraft;
	protected override void SetDestination(){
		if(!targetCraft || !targetCraft.gameObject.activeSelf){
			targetCraft = ClosestOpponent(GameObject.FindGameObjectsWithTag("Ally"));
		}
		engine.SetDestination(new Vector2(targetCraft.position.x, targetCraft.position.y + engageDistance));
	}

}

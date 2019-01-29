using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pilot : Script {

	protected Engine engine { get { return gameObject.GetComponent<Engine>(); } }

	protected float variant = 0.5f;
	protected float randomize { get { return Random.Range(-variant, variant); } }

	protected abstract float spawnY{ get; }
	protected abstract Vector2 startPosition{ get; }
	void OnEnable(){
		transform.position = new Vector2(Random.Range(xMin, xMax), spawnY);
		ToCoordinate(startPosition);
	}

	float next;
	protected abstract void SetDestination ();
	protected void Destination (){
		if(time < next){ return; }
		next = time + 0.2f;
		SetDestination();
	}

	public float preferY;
	public Transform targetCraft;
	protected bool targetExist { get { return targetCraft && targetCraft.gameObject.activeSelf; } }

	protected void SearchTarget(string side){
		if(targetExist){ return; }
		targetCraft = ClosestRival(side);
	}

	protected void TrackTarget(){
		if(!targetExist){ return; }
		engine.SetDestination(
		new Vector2(targetCraft.position.x + randomize, transform.position.y + randomize));
	}

	protected void ToCoordinate(Vector2 coord){
		engine.SetDestination(new Vector2(coord.x + randomize, coord.y + randomize));
	}

	protected Transform ClosestRival(string side){
		List<GameObject> selfPool = craftPool.pool[side]["Active"];
		List<GameObject> rivalPool = craftPool.pool[side == "Ally"?"Enemy":"Ally"]["Active"];
		if(rivalPool.Count == 0){ return null; }
		return rivalPool[(int)Mathf.Floor(selfPool.IndexOf(gameObject) * rivalPool.Count / selfPool.Count)].transform;
	}

}

using System.Collections;
using UnityEngine;

public class Enemy : Pilot {

	protected override float spawnY{ get{ return yMax + Random.Range(0.5f, 1.5f); } }
	protected override Vector2 startPosition{ get{ return new Vector2(0f, 3.5f); } }

	public float delay;
	protected override void SetDestination(){
		if(time > spawnTime + delay){ TrackTarget(); }
	}

}

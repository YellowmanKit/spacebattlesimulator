using System.Collections;
using UnityEngine;

public class Ally : Pilot {

	protected override float spawnY{ get { return yMin - Random.Range(0.5f, 1.5f); } }
	protected override Vector2 startPosition{ get { return new Vector2(0f, -3.5f); } }

	protected override void SetDestination(){
		if(command.last > time - 1.5f){ ToCoordinate(command.target);
		} else if(targetExist){ TrackTarget(); }
		else{ ToCoordinate(startPosition); }
	}

}

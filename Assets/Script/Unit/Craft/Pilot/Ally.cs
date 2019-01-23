using System.Collections;
using UnityEngine;

public class Ally : Pilot {

	protected override void SetDestination(){
		engine.SetDestination(input.target);
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Craft : Unit {

	protected Engine engine { get { return GetComponent<Engine>(); }}
	protected Hitpoint hitpoint { get { return GetComponent<Hitpoint>(); }}

	protected override void OnAlphaZero(){ DestroyCraft(); }

	protected void DestroyCraft(){
		craftPool.Destroyed(gameObject);
	}

}

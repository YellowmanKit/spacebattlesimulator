using System.Collections;
using UnityEngine;

public abstract class Craft : Unit {

	protected Engine engine { get { return GetComponent<Engine>(); }}

	protected override void OnAlphaZero(){ DestroyCraft(); }

	protected void DestroyCraft(){
		gameObject.SetActive(false);
	}

}

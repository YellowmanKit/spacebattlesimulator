using System.Collections;
using UnityEngine;

public abstract class Pilot : Script {

	protected Engine engine { get { return gameObject.GetComponent<Engine>(); }}

	protected abstract void SetDestination ();
	void Update (){ SetDestination(); }

	protected Transform ClosestOpponent(GameObject[] opponentList){
		if(opponentList.Length == 0){ return null; }
		return opponentList[0].transform;
	}

}

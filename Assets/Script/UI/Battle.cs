using System.Collections;
using UnityEngine;

public class Battle : UI {

	public static Battle instance;
	void Awake(){ Battle.instance = this; }

	protected override void OnShow(){ game.phase = Phase.Battle; }
	protected override void OnAlphaZero(){ }

	void Start(){ Hide(); }


}

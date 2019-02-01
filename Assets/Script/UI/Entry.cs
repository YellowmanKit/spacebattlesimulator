using System.Collections;
using UnityEngine;

public class Entry : UI {

	public static Entry instance;
	void Awake(){ Entry.instance = this; }

	protected override void OnShow(){ game.phase = Phase.Entry; }
	protected override void OnAlphaZero(){ game.StartGame(); }

	void Start(){ Show(); }

	public void Enter(){ Hide(); }

}

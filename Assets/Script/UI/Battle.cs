using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Battle : UI {

	public static Battle instance;
	void Awake(){ Battle.instance = this; }

	protected override void OnShow(){ game.phase = Phase.Battle; message.text = "Wave " + game.waveCount; }
	protected override void OnAlphaZero(){ }

	public Text message;
	void Start(){ Hide(); }


}

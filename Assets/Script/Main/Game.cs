using System.Collections;
using UnityEngine;

public class Game : Script {

	public static Game instance;
	void Awake(){ Game.instance = this; }

	public Phase phase;
	public GameObject title;

	public void GameStart(){
		Destroy(title);
		phase = Phase.Upgrade;
	}

}

public enum Phase {
	Entry,
	Upgrade,
	Battle
}

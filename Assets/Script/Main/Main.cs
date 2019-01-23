using System.Collections;
using UnityEngine;

public class Main : Script {

	public static Main instance;
	void Awake(){ Main.instance = this; }

	public float scale;

	public float timeScale;
	void Update(){
		Time.timeScale = timeScale;
	}

}

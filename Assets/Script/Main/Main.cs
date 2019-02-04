using System.Collections;
using UnityEngine;

public class Main : Script {

	public static Main instance;
	void Awake(){ Main.instance = this; }

	public float scale;
	public void UpdateScale(AType type, int amount, bool destroyed){
		float weight =
		type == AType.Eagle? 0.02f: 0.02f;
		if(destroyed){ scale -= weight; }else{ scale += weight * amount; }
		cam.UpdateCamera();
	}

	public float timeScale;
	void Update(){
		Time.timeScale = timeScale;
	}

}

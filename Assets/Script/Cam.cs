using System.Collections;
using UnityEngine;

public class Cam : Script {

	public static Cam instance;
	void Awake(){ Cam.instance = this; }

	void Start(){ UpdateCamera (); }

	public float camMin,camMax;
	float targetCamSize;
	public void UpdateCamera(){
		targetCamSize = camMin + Mathf.Clamp ((camMax - camMin) * main.scale, 0f, camMax - camMin);
	}

	float actualSize { get { return Camera.main.orthographicSize; } }
	void Update(){
		var diff = targetCamSize - actualSize;
		Camera.main.orthographicSize = actualSize + diff * deltaTime * 3;
	}

	public float height { get { return actualSize * 2; } }
	public float width { get { return height * Camera.main.aspect; } }

}

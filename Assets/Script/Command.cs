using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Command : Script {

	public static Command instance;
	void Awake(){ Command.instance = this; }

	void Update () {
		GetTarget();
		HandleKey();
	}

	float next;
	void GetTarget(){
		if(time < next || game.phase != Phase.Battle){ return; }
		ByClick();
		ByTouch();
	}

	void ByClick(){
		if(!Input.GetKey(KeyCode.Mouse0)){ return; }
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		CastRay(ray);
	}

	void ByTouch(){
		if(Input.touchCount != 1){ return; }
		Ray ray = Camera.main.ScreenPointToRay(Input.touches [0].position);
		CastRay(ray);
	}

	public float last;
	public Vector2 target;
	void CastRay(Ray ray){
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, 100f, uiLayer);
		if (hit && hit.collider.gameObject.name == "Area") {
			target = new Vector2 (hit.point.x, hit.point.y);
			EmitParticle ();
		}
		next = time + 0.1f;
		last = time;
	}

	public ParticleSystem onGet;
	void EmitParticle(){
		onGet.transform.position = new Vector3 (target.x, target.y, 0f);
		var psmain = onGet.main;
		onGet.Emit (1);
	}

	void HandleKey(){
		if(!Input.GetKey(KeyCode.Escape)){ return; }
		SceneManager.LoadScene ("main");
	}

}

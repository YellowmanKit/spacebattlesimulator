using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawn : Pool {

	public static ProjectileSpawn instance;
	void Awake(){ ProjectileSpawn.instance = this; }

	public GameObject[] prefab;
	void Start () {
		InitPool();
	}

	void InitPool(){
		AddPool("Projectile");
		foreach(PType type in System.Enum.GetValues(typeof(PType))){
			AddType("Projectile", type.ToString(), prefab[(int)type]); }
	}

	public void Spawn(PType type, Transform shotSpawn){
		GameObject projectile = Fetch("Projectile", type.ToString());
		projectile.transform.position = shotSpawn.position;
		projectile.transform.rotation = shotSpawn.rotation;
		projectile.SetActive(true);
	}

	public void Destroyed(GameObject projectile){
		projectile.SetActive(false);
	}
}

public enum PType {
	PlasmaBolt,
	NeutronBolt
}

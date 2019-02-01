using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftSpawn : Pool {

	public static CraftSpawn instance;
	void Awake(){ CraftSpawn.instance = this; }

	public GameObject[] allyPrefab;
	public GameObject[] enemyPrefab;

	void Start(){
		InitAllyPool();
		InitEnemyPool();
	}

	void InitAllyPool(){
		AddPool("Ally");
		AddType("Ally", "Active", null);
		foreach(AType type in System.Enum.GetValues(typeof(AType))){
			AddType("Ally", type.ToString(), allyPrefab[(int)type]); }
	}

	void InitEnemyPool(){
		AddPool("Enemy");
		AddType("Enemy", "Active", null);
		foreach(EType type in System.Enum.GetValues(typeof(EType))){
			AddType("Enemy", type.ToString(), enemyPrefab[(int)type]); }
	}

	public void Spawn(string side, string type){
		GameObject craft = Fetch(side, type);
		craft.SetActive(true);
		pool[side.ToString()]["Active"].Add(craft);
	}

	public void SpawnAlly(AType type, int amount){
		for(int i=0;i<amount;i++){
		Spawn("Ally", type.ToString()); }
	}
	public void SpawnEnemy(EType type, int amount){
		for(int i=0;i<amount;i++){
		Spawn("Enemy", type.ToString()); }
	}

	public void Destroyed(GameObject craft){
		craft.SetActive(false);
		List<GameObject> activePool = pool[craft.tag]["Active"];
		activePool.Remove(craft);
		if(activePool.Count == 0 && game.phase == Phase.Battle){
			if(craft.tag == "Ally"){ game.GameOver(); }
			else if(game.phase == Phase.Battle){ game.WaveCleared(); }
		}
	}

	public void Sort(List<GameObject> craftPool){
		craftPool.Sort((a,b)=>( a.transform.position.x.CompareTo(b.transform.position.x) ));
	}

	float next;
	void Update(){
		if(time < next){ return; }
		next = time + 1f;
		Sort(pool["Ally"]["Active"]);
		Sort(pool["Enemy"]["Active"]);
	}

	public void PrewarmAllWeapons(){ BroadcastMessage("Prewarm"); }

}

public enum AType {
	Eagle
}

public enum EType {
	Bat
}

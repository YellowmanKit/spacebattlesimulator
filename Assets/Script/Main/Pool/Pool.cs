using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pool : Script {

	public Dictionary<string, Dictionary<string, List<GameObject>>> pool =
	new Dictionary<string, Dictionary<string, List<GameObject>>>();

	protected void AddPool(string key){
		pool.Add(key, new Dictionary<string, List<GameObject>>());
	}

	protected void AddType(string key, string type, GameObject prefab){
		pool[key].Add(type, new List<GameObject>());
		if(prefab){ AddTypeSet(type); }
		AddObject(key, type, prefab);
	}

	void AddTypeSet(string type){
		GameObject typeSet = new GameObject();
		typeSet.name = type;
		typeSet.transform.SetParent(transform);
	}

	protected GameObject AddObject(string key, string type, GameObject prefab){
		if(!prefab){ return null; }
		GameObject clone = Instantiate(prefab, transform.Find(type));
		pool[key][type].Add(clone);
		clone.SetActive(false);
		return clone;
	}

	public GameObject Fetch(string key, string type){
		foreach(GameObject poolObject in pool[key][type]){
			if(poolObject.activeSelf){ continue; }
			return poolObject;
		}
		return AddObject(key, type, pool[key][type][0]);
	}

}

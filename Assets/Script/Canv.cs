using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canv : Ref {

    public static Canv instance;

    public GameObject entry, prepare, battle;

	void Start () {
        Canv.instance = this;
	}

    public void PrepareCanvas() {
        entry.SetActive(false);
        prepare.SetActive(true);
    }

}

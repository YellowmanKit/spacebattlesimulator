using System.Collections;
using UnityEngine;

public class Main : Ref {

    public static Phase phase;

    public static Main instance;

    void Start() {
        Main.instance = this;
    }

    public void StartGame () {
        Debug.Log("StartGame");
        phase = Phase.Prepare;
        canv.PrepareCanvas();
    }

}

public enum Phase {
    Entry,
    Prepare,
    Battle
}

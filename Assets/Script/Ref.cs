using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ref : MonoBehaviour {

    protected Main main { get { return Main.instance; } }
    protected Canv canv { get { return Canv.instance; } }

}

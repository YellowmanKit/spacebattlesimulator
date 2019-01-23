using System.Collections;
using UnityEngine;

public abstract class Script : MonoBehaviour {

	protected Main main { get { return Main.instance; } }
	protected Game game { get { return Game.instance; } }

	protected CustomCamera cam { get { return CustomCamera.instance; } }
	protected CustomInput input { get { return CustomInput.instance; } }

	protected float time { get { return Time.timeSinceLevelLoad; } }
	protected float deltaTime { get { return Time.deltaTime; } }

	protected int uiLayer { get { return 1 << 5; } }
	protected int allyLayer { get { return 1 << 8; } }
	protected int enemyLayer { get { return 1 << 9; } }
	
}

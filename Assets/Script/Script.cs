using System.Collections;
using UnityEngine;

public abstract class Script : MonoBehaviour {

	protected Main main { get { return Main.instance; } }
	protected Game game { get { return Game.instance; } }

	protected CraftSpawn craftPool { get { return CraftSpawn.instance; } }
	protected ProjectileSpawn projectilePool { get { return ProjectileSpawn.instance; } }

	protected CustomCamera cam { get { return CustomCamera.instance; } }
	protected CustomInput input { get { return CustomInput.instance; } }

	protected Entry entry { get { return Entry.instance; } }
	protected Reward reward { get { return Reward.instance; } }
	protected Battle battle { get { return Battle.instance; } }

	protected float time { get { return Time.timeSinceLevelLoad; } }
	protected float deltaTime { get { return Time.deltaTime; } }

	protected float xMax { get { return cam.width / 2; }}
	protected float xMin { get { return xMax * -1; }}
	protected float yMax { get { return cam.height / 2; }}
	protected float yMin { get { return yMax * -1; }}

	protected int uiLayer { get { return 1 << 5; } }
	protected int allyLayer { get { return 1 << 8; } }
	protected int enemyLayer { get { return 1 << 9; } }
	protected int allyBoltLayer { get { return 1 << 10; } }
	protected int enemyBoltLayer { get { return 1 << 11; } }
	
}

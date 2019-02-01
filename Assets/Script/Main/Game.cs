using System.Collections;
using UnityEngine;

public class Game : Script {

	public static Game instance;
	void Awake(){ Game.instance = this; }

	public Phase phase;

	public void StartGame(){
		InitAlly();
		reward.Show();
	}

	void InitAlly(){
		craftPool.SpawnAlly(AType.Eagle, 1);
	}

	public int waveCount;
	public void NextWave(){
		if(phase != Phase.Reward){ return; }
		waveCount++;
		StartCoroutine(WaveRoutine());
	}
	IEnumerator WaveRoutine(){
		battle.ShowForSeconds(2f);
		craftPool.PrewarmAllWeapons();
		yield return new WaitForSeconds(1f);
		craftPool.SpawnEnemy(EType.Bat, waveCount);
	}

	public void WaveCleared(){
		reward.Show();
	}

	public void GameOver(){
		end.Show();
	}

}

public enum Phase {
	Entry,
	Reward,
	Battle,
	GameOver
}

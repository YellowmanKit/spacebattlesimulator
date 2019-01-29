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
		for(int i=0;i<5;i++){
		craftPool.SpawnAlly(AllyType.Eagle);}
	}

	public int waveCount;
	public void NextWave(){
		if(phase != Phase.Reward){ return; }
		StartCoroutine(WaveRoutine());
	}
	IEnumerator WaveRoutine(){
		waveCount++;
		battle.Show();
		craftPool.PrewarmAll();
		for(int i=0;i<5;i++){
			yield return new WaitForSeconds(0.2f);
			craftPool.SpawnEnemy(EnemyType.Bat);
		}
	}

	public void WaveCleared(){
		phase = Phase.Reward;
		reward.Show();
	}

	public void GameOver(){

	}

}

public enum Phase {
	Entry,
	Reward,
	Battle
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reward : UI {

	public static Reward instance;
	void Awake(){ Reward.instance = this; }

	protected override void OnShow(){ game.phase = Phase.Reward; SetReward(); }
	protected override void OnAlphaZero(){ game.NextWave(); }

	void Start(){ Hide(); }

	public Text[] rewardText;
	void SetReward(){
		rewardText[0].text = "Recruit 3 eagles immediately";
		rewardText[1].text = "Recruit 5 eagles over 5 turns";
		rewardText[2].text = "";
	}

	List<KeyValuePair<AType, int>> pending = new	List<KeyValuePair<AType, int>>();
	public void RewardPicked(int index){
		switch(index){
			case 0: craftPool.SpawnAlly(AType.Eagle, 3); break;
			case 1: pending.Add(new KeyValuePair<AType, int>(AType.Eagle, game.waveCount + 5)); break;
			case 2:
				break;
		}
		PendingRecruit();
		Hide();
	}

	void PendingRecruit(){
		for(int i=0;i<pending.Count;i++){
			KeyValuePair<AType, int> pair = pending[i];
			if(pair.Value > game.waveCount){ craftPool.SpawnAlly(pair.Key, 1); }
			if(pair.Value == game.waveCount){ pending.Remove(pair); i--; }
		}
	}

}

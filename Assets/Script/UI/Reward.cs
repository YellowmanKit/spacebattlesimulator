using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Reward : UI {

	public static Reward instance;
	void Awake(){ Reward.instance = this; }

	protected override void OnShow(){ game.phase = Phase.Reward; SetReward(); }
	protected override void OnAlphaZero(){ game.NextWave(); content.SetActive(false); }

	void Start(){ Hide(); }

	public Text[] rewardText;
	void SetReward(){
		for(int i=0;i<3;i++){
			rewardText[i].text = "Reward" + i;
		}
	}

	public void RewardPicked(int index){
		Hide();
	}


}

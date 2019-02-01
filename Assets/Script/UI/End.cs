using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : UI {

	public static End instance;
	void Awake(){ End.instance = this; }

	public Text message;
	protected override void OnShow(){ game.phase = Phase.GameOver;
		message.text = "Game Over\n( Wave " + game.waveCount + " )"; }
	protected override void OnAlphaZero(){ SceneManager.LoadScene ("main"); }

	void Start(){ Hide(); }

}

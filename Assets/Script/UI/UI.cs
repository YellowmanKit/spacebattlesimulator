using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class UI : Script {

	protected CanvasGroup cg { get { return GetComponent<CanvasGroup>(); } }
	protected GameObject content { get { return transform.GetChild(0).gameObject; } }

	protected abstract void OnShow();
	public void Show(){ cg.interactable = true; cg.alpha = 0f; targetAlpha = 1f; content.SetActive(true); OnShow(); }
	public void Hide(){ cg.interactable = false; targetAlpha = 0f; nextHide = float.MaxValue; }
	protected float nextHide = float.MaxValue;
	protected void NextHide(){ if(time > nextHide){ Hide(); } }
	public void ShowForSeconds(float seconds){ Show(); nextHide = time + seconds; }

	protected float targetAlpha;
	protected abstract void OnAlphaZero();
	protected bool alphaZero { get { return cg.alpha <= 0.01f; } }
	protected void Alpha(){
		if(alphaZero && targetAlpha == 0f){ return; }
		float delta = targetAlpha - cg.alpha;
		cg.alpha += delta * deltaTime * 5f;
		if(alphaZero){ OnAlphaZero(); content.SetActive(false); }
	}

	void Update(){ Alpha(); NextHide(); }
}

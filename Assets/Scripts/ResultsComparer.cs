using System;
using System.Collections;
using UnityEngine;

public class ResultsComparer : MonoBehaviour {
	public Action OnEndTurn;

	public int winLoseCount { get; private set; }

	public void CompareCards(GameCardBase currentCardAI, GameCardBase currentCardPlayer) {
		if (!currentCardAI.isFlipped || !currentCardPlayer.isFlipped) { return; }

		if (int.Parse(currentCardPlayer.textMP.text) > int.Parse(currentCardAI.textMP.text)) { StartCoroutine(OnWin()); }
		else if (int.Parse(currentCardPlayer.textMP.text) < int.Parse(currentCardAI.textMP.text)) { StartCoroutine(OnLose()); }
		else { StartCoroutine(OnDraw()); }

		OnEndTurn.Invoke();
	}

	IEnumerator OnWin() {
		yield return new WaitForSeconds(1f);
		Debug.Log("You won~ :party_yay:");
		// Play Animation, Sound, SFX
		winLoseCount++;
	}

	IEnumerator OnLose() {
		yield return new WaitForSeconds(1f);
		Debug.Log("You lost :(");
		// Play Animation, Sound, SFX
	}

	IEnumerator OnDraw() {
		yield return new WaitForSeconds(1f);
		Debug.Log("It's a draw :O ");
		// Play Animation, Sound, SFX
	}
}

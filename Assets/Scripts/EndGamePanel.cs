using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGamePanel : MonoBehaviour {
	[SerializeField] ResultsComparer compareResults;
	[Space]
	[SerializeField] UI_Button mainMenuButton;

	void Start() {
		mainMenuButton.btn.onClick.AddListener(Restart);
	}

	void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

	public void EndGameSequence(int deckSize) => PlayEndGameSequence(deckSize);

	IEnumerator PlayEndGameSequence(int deckSize) {
		// play end panel
		yield return new WaitForSeconds(1f);
		if (compareResults.winLoseCount > deckSize / 2) { OnVictory(); }
		else if (compareResults.winLoseCount < deckSize / 2) { OnDefeat(); }
		else { OnDraw(); }

		//reset 
	}

	void OnVictory() {
		Debug.Log("Victory! :D");
		// Set Text
	}

	void OnDefeat() {
		Debug.Log("Defeat :( ");
		// Set Text
	}

	void OnDraw() {
		Debug.Log("Draw! >ω< ");
		// Set Text
	}
}

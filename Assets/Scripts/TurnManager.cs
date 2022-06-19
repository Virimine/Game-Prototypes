using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {
	[SerializeField] EndGamePanel endGamePanel;
	[SerializeField] ResultsComparer compareResults;
	[Space]
	[SerializeField] List<GameCardPlayer> deckPlayer;
	[SerializeField] List<GameCardBase> DeckAI;
	[Space]
	[SerializeField] Transform duelPosPlayer;
	[SerializeField] Transform duelPosAI;
	[SerializeField] Transform discardPosPlayer;
	[SerializeField] Transform discardPosAI;
	[Space]
	[SerializeField] int deckSize = 10;

	List<int> deckNumbersAI = new List<int>();
	List<int> deckNumbersPlayer = new List<int>();
	GameCardBase currentCardAI;
	GameCardPlayer currentCardPlayer;
	int currentTurnIndex;

	/// THEME: MAGIC, FANTASY, ALCHEMY, SACRED GEOMETRY, RUNES
	/// SYMBOLS: (circle(1), platonic solids(5), dual polyhedra(3), star polyhedra(?))

	void Start() {
		foreach (var card in deckPlayer) {
			card.button.onClick.AddListener(() =>
			card.MoveToAndFlip(duelPosPlayer, true, 0, () => compareResults.CompareCards(currentCardAI, currentCardPlayer)));
		}
		for (int i = 1; i < deckSize + 1; i++) {
			deckNumbersAI.Add(i);
			deckNumbersPlayer.Add(i);
		}
		compareResults.OnEndTurn += EndTurn;

		Debug.Log("TODO: improve deal and discard animations");
		Debug.Log("TODO: Improve Main and Pause Menus and End Panel");
		Debug.Log("TODO: Graphics, SFX, Animations");

		Debug.Log("TODO POLISH: Implement who plays first logic");
	}

	public void SetTurn() {

		currentCardAI = DeckAI[currentTurnIndex];
		currentCardPlayer = deckPlayer[currentTurnIndex];

		AssignNumber(currentCardAI, deckNumbersAI);
		AssignNumber(currentCardPlayer, deckNumbersPlayer);

		currentCardAI.MoveToAndFlip(duelPosAI, true, 2f, () => { compareResults.CompareCards(currentCardAI, currentCardPlayer); currentCardPlayer.isInteractable = true; }); //uugh


		void AssignNumber(GameCardBase currentCard, List<int> deckNumbers) {
			var rndIndex = Random.Range(0, deckNumbers.Count);
			currentCard.textMP.text = deckNumbers[rndIndex].ToString();
			deckNumbers.RemoveAt(rndIndex);
		}
	}

	void EndTurn() => StartCoroutine(PlayEndTurn());
	IEnumerator PlayEndTurn() {
		var waitTime = 1.5f;

		currentCardAI.Discard(discardPosAI, waitTime);
		currentCardPlayer.Discard(discardPosPlayer, waitTime);

		currentCardAI.transform.SetAsLastSibling();
		currentCardPlayer.transform.SetAsLastSibling();

		yield return new WaitForSeconds(waitTime);
		if (currentTurnIndex < deckPlayer.Count - 1) {
			currentTurnIndex++;
			SetTurn();
		}
		else {
			endGamePanel.EndGameSequence(deckSize);
			compareResults.OnEndTurn -= EndTurn;
		}
	}
}

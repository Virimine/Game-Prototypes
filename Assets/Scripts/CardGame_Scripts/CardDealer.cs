using System;
using System.Collections;
using UnityEngine;

public class CardDealer : MonoBehaviour {
	[SerializeField] TurnManager turnManager;

	public void PlayDealAnimation() => StartCoroutine(PlayDealAnim());
	IEnumerator PlayDealAnim() {
		// Deal 5 Cards: IEnumerator/Animation: Curve/Easing
		//foreach (var card in deckPlayerCards) {
		//	//play enter anim: set positions || animation
		//	yield return new WaitForSeconds(0.1f);
		//}
		yield return new WaitForSeconds(0.01f);
		turnManager.SetTurn();
	}
}

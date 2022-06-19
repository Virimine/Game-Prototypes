using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	[SerializeField] CardDealer CardDealer;
	[SerializeField] UI_Button playButton;
	[SerializeField] UI_Button exitButton;

	private void Start() {
		playButton.btn.onClick.AddListener(OnGameBegin);
		exitButton.btn.onClick.AddListener(Application.Quit);
	}

	void OnGameBegin() {
		CardDealer.PlayDealAnimation();
		this.gameObject.SetActive(false); // make anim
	}
}

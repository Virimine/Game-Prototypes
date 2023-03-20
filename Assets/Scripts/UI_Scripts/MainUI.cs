using System.Collections;
using System.Collections.Generic;
using Prototypes.FallingCubes;
using UnityEngine;

public class MainUI : MonoBehaviour {
	public EndGamePanel endGamePanel;
	public mainHUD mainHUD;

	public static MainUI instance { get; private set; }

	void Awake() => instance = this;

	void Start() => GameManager.instance.player.OnPlayerKilled += OnEndGame;

	void OnEndGame() {
		endGamePanel.Show();
		mainHUD.Hide();

		GameManager.instance.player.OnPlayerKilled -= OnEndGame;
	}
}

using System.Collections;
using System.Collections.Generic;
using Prototypes.FallingCubes;
using TMPro;
using UnityEngine;

public class mainHUD : BaseUIElement {

	[SerializeField] TextMeshProUGUI scoreTMP;
	[SerializeField] TextMeshProUGUI timeTMP;

	public override void Hide() => Toggle();
	public override void Show() => Toggle();

	void Update() => UpdateCounter();

	void UpdateCounter() {
		scoreTMP.text = GameManager.instance.gameScore.ToString();
		timeTMP.text = $"{(int) GameManager.instance.gameplayTime}";
	}

}

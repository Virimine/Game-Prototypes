using System;
using UnityEngine;
using UnityEngine.UI;

public class GameCardPlayer : GameCardBase {
	public bool isInteractable { get => button.interactable; set => button.interactable = value; }

	public Button button { get; private set; }

	public override void Awake() {
		base.Awake();
		button = image.GetComponent<Button>();
		isInteractable = false;
	}

	public override void MoveToAndFlip(Transform targetPosition, bool shouldFlip, float waitTime, Action callback) {
		base.MoveToAndFlip(targetPosition, shouldFlip, waitTime, callback);
		isInteractable = false;
	}
}

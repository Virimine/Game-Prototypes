using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCardBase : MonoBehaviour {
	[SerializeField] Transform rectTransform;
	[Space]
	[SerializeField] Sprite cardBack;
	[SerializeField] Sprite cardFront;
	[Space]
	[SerializeField] float animationSpeed;

	public Image image { get; private set; }
	public Animator anim { get; private set; }
	public TextMeshProUGUI textMP { get; private set; }
	public bool isFlipped { get; private set; }

	//SUMMARY: 

	public virtual void Awake() {
		anim = GetComponent<Animator>();
		image = GetComponentInChildren<Image>();
		textMP = GetComponentInChildren<TextMeshProUGUI>();
	}

	public virtual void Discard(Transform targetPosition, float waitTime) => StartCoroutine(PlayMoveToAnim(targetPosition, false, waitTime, null));

	public virtual void MoveToAndFlip(Transform targetPosition, bool shouldFlip, float waitTime, Action callback) {
		StartCoroutine(PlayMoveToAnim(targetPosition, shouldFlip, waitTime, callback));
	}

	IEnumerator PlayMoveToAnim(Transform targetPosition, bool shouldFlip, float waitTime, Action callback) {
		var targetPos = targetPosition.transform.position;

		yield return new WaitForSeconds(waitTime);
		while (true) {
			rectTransform.position = Vector3.MoveTowards(rectTransform.position, targetPos, animationSpeed * Time.deltaTime);
			if (rectTransform.position == targetPos) { break; }
			yield return null;
		}
		if (shouldFlip) { StartCoroutine(PlayFlipAnim(callback)); }
	}

	IEnumerator PlayFlipAnim(Action callback) {
		anim.Play("CardFlip");
		yield return new WaitForSeconds(0.6f); //make utilities: Run Delayed (instead of waiTime in coroutines), Return Animation Length
		isFlipped = true;
		callback?.Invoke();
	}

	//called in CardFlip Animation Event
	public void ChangeCardSprite() {
		if (image.sprite == cardFront) { image.sprite = cardBack; }
		else { image.sprite = cardFront; }

		textMP.enabled = !textMP.enabled;
	}
}

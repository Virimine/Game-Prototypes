using System.Collections;
using System.Collections.Generic;
using Prototypes.FallingCubes;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Prototypes.FallingCubes {
	public class EndGamePanel : BaseUIElement {
		[SerializeField] TextMeshProUGUI scoreTMP;
		[SerializeField] TextMeshProUGUI timeTMP;

		void Update() {
			if (Input.GetKeyDown(KeyCode.Space)) { Restart(); }
		}

		void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

		public override void Show() {
			scoreTMP.text = GameManager.instance.gameScore.ToString();
			timeTMP.text = $"{(int) GameManager.instance.gameplayTime} sec";

			Toggle();
		}

		public override void Hide() => Toggle();
	}
}

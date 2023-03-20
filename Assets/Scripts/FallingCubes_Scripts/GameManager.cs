using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototypes.FallingCubes {
	public class GameManager : MonoBehaviour {

		public PlayerController player;

		public float gameScore { get; private set; }
		public float gameplayTime { get; private set; }
		public float screenWidth => Camera.main.orthographicSize * Camera.main.aspect;

		public static GameManager instance { get; private set; }

		void Awake() => instance = this;

		private void Start() {
			Debug.Log("Add Wrap Ability");  // add a wrap count and when it reaches 0 the player needs to wait 3 sec before they can wrap again. wrap ability replenishes every 3 sec for a max of 4 
			Debug.Log("Add Difficulty");    // every 30 sec spawn goes down by 0.05 (6 times) or Commet speed goes up by 0.5 (6 times)
			Debug.Log("Add Upgrades");      // slow down cubes, less spawned cubes, insta replenish wrap, extra points, slo-mo || commet tail sfx? || wrap
			Debug.Log("Add SFX");           // commet || portal || 
		}

		void Update() => gameplayTime += Time.deltaTime;

		public float UpdateScore() => gameScore += 10;
	}
}

using System.Collections;
using System.Collections.Generic;
using Prototypes.FallingCubes;
using UnityEngine;

namespace Prototypes.FallingCubes {
	public class CubeSpawner : MonoBehaviour {
		[SerializeField] Cube cube;

		Vector3 spawnPos;
		Quaternion spawnRot;
		float spawnTimer = 0.5f;
		float t = 0f;

		void Start() => GameManager.instance.player.OnPlayerKilled += ()=> SetSpawnTimer(0f);

		void Update() => SpawnCube();

		public void SetSpawnTimer(float value) => spawnTimer = value;

		//public float SetSpawnTimerReturn(float value) => spawnTimer = value;

		void SpawnCube() {
			t += Time.deltaTime;

			if (t >= spawnTimer) {
				spawnPos = new Vector3(Random.Range(-GameManager.instance.screenWidth + cube.transform.localScale.x / 2, GameManager.instance.screenWidth - cube.transform.localScale.x / 2), Camera.main.orthographicSize + cube.transform.localScale.y / 2);
				spawnRot.eulerAngles = new Vector3(0, 0, Random.Range(-15, 15));

				var newCube = Instantiate(cube, spawnPos, spawnRot);
				newCube.SetDisplay();

				t = 0;
			}
		}
	}
}

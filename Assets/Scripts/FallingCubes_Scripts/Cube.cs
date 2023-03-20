using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototypes.FallingCubes {
	public class Cube : MonoBehaviour {

		[SerializeField] MeshRenderer meshRenderer;
		[SerializeField] float cubeSpeed = 5f;
		[SerializeField] List<Color> cubeColors;

		public System.Action OnDestroy;
		//public bool isDestroyed { get; private set; }

		void Update() {
			MoveCube(cubeSpeed);
			DestroyCube();
		}

		public void SetDisplay() {
			var spawnScale = Vector3.one * Random.Range(0.5f, 1f);
			transform.localScale = spawnScale;

			var rndColorIndex = Random.Range(0, cubeColors.Count);
			meshRenderer.material.color = cubeColors[rndColorIndex];
		}
		public void MoveCube(float speed) => transform.Translate(Vector3.down * speed * Time.deltaTime);

		public void DestroyCube() {

			bool hasReachedMaxHeight = transform.position.y < -Camera.main.orthographicSize - transform.localScale.y;
			if (hasReachedMaxHeight) {
				Destroy(gameObject);

				GameManager.instance.UpdateScore(); //OnDestroy?.Invoke();

			}
		}
	}
}

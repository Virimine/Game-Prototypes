using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototypes.FallingCubes {
	public class PlayerController : MonoBehaviour {

		[SerializeField] float speed;
		[SerializeField] bool wrapPlayer;

		public Action OnPlayerKilled;

		bool disableInput { get; set; }

		void Update() {
			MovePlayer();
			WrapPlayer();
		}

		void MovePlayer() {
			if (disableInput) { return; }

			float x = Input.GetAxis("Horizontal");
			Vector3 movemement = new Vector3(x * speed * Time.deltaTime, 0, 0);

			transform.Translate(movemement);
		}

		void WrapPlayer() {
			var playerPos = transform.position;
			var playerScale = transform.localScale;
			var screenBound = new Vector3(Camera.main.orthographicSize * Camera.main.aspect + playerScale.x / 2, 0, 0);

			if (wrapPlayer) {
				if (transform.position.x < -screenBound.x) { transform.Translate(screenBound * 2); }
				if (transform.position.x > screenBound.x) { transform.Translate(-screenBound * 2); }
			}
			else {
				if (transform.position.x < -screenBound.x + playerScale.x) { playerPos.x = -screenBound.x + playerScale.x; }
				if (transform.position.x > screenBound.x - playerScale.x) { playerPos.x = screenBound.x - playerScale.x; }
				transform.position = playerPos;
			}
		}

		void OnTriggerEnter(Collider other) {

			var layerIndex = LayerMask.NameToLayer("Enemy");
			if (other.gameObject.layer == layerIndex) {

				OnPlayerKilled?.Invoke();
				disableInput = true;
			}
		}
	}
}

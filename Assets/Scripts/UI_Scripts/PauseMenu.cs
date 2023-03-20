using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	[SerializeField] UI_Button resumeButton;
	[SerializeField] UI_Button mainMenuButton;
	[SerializeField] CanvasGroup canvasGroup;

	void Start() {
		resumeButton.btn.onClick.AddListener(Toggle);
		mainMenuButton.btn.onClick.AddListener(Restart);
	}

	void Update() => CheckForInput();

	void CheckForInput() { if (Input.GetKeyDown(KeyCode.Escape)) { Toggle(); } }

	bool isVisible;
	void Toggle() {
		canvasGroup.alpha = isVisible ? 1 : 0; // one-liner if statements == still confusing >ω<
		Time.timeScale = isVisible ? 0 : 1;
		isVisible = !isVisible;
	}

	void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

	void OnDisable() => Time.timeScale = 1;
}

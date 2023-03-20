using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour {

	public Button btn { get; private set; }
	public Image img { get; private set; }
	public TextMeshProUGUI txt { get; private set; }

	void Awake() {
		btn = GetComponentInChildren<Button>();
		img = GetComponentInChildren<Image>();
		txt = GetComponentInChildren<TextMeshProUGUI>();
	}
}

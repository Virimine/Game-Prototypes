using System;
using UnityEngine;

public interface IBaseUIElement {
	public bool isActive { get; }

	void Show() { }
	void Hide() { }
}


public abstract class BaseUIElement : MonoBehaviour, IBaseUIElement {

	public GameObject basePanel;

	public bool isActive => basePanel.activeInHierarchy;

	public abstract void Show();
	public abstract void Hide();

	public void Toggle() => basePanel.SetActive(!isActive);
}

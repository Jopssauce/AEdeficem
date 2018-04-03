using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMessage : MonoBehaviour {

	public GameObject MessagePanel;
	public void ShowMessagePanel()
	{
		MessagePanel.SetActive(true);
		FindObjectOfType<AudioManager> ().Play ("Generic");
	}
}

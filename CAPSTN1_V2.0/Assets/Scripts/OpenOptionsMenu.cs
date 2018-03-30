using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOptionsMenu : MonoBehaviour
{
	public GameObject Menu;
	public void OptionsButtonPressed()
	{
		FindObjectOfType<AudioManager> ().Play ("Generic");
		Menu.SetActive (true);
		this.transform.parent.gameObject.SetActive (false);
	}
}

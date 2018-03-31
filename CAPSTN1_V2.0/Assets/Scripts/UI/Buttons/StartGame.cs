﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {
	public Text loading;

	public void Click()
    {
		FindObjectOfType<AudioManager> ().Play ("Generic");
		loading.gameObject.SetActive (true);
		this.transform.parent.gameObject.SetActive (false);
		SceneManager.LoadSceneAsync("Main Scene");
    }
}

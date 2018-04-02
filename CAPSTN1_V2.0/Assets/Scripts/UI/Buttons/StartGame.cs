using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {
	public GameObject loading;
	public string SceneName;

	public void Click()
    {
		FindObjectOfType<AudioManager> ().Play ("Generic");
		loading.SetActive (true);
		this.transform.parent.gameObject.SetActive (false);
		SceneManager.LoadSceneAsync(SceneName);
    }
}

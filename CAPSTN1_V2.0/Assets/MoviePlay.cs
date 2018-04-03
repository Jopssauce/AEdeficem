using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class MoviePlay : MonoBehaviour {

	private VideoPlayer videoPlayer;
	public GameObject loading;
	public GameObject UIDisable;
	// Use this for initialization

	void Awake()
	{
		videoPlayer = GetComponent<VideoPlayer> ();
	}

	void Start () 
	{
		FindObjectOfType<AudioManager> ().StopMusic ("Theme");
		videoPlayer.loopPointReached += OnEndVideo;
	}

	public void OnEndVideo(VideoPlayer vp)
	{
		videoPlayer.Stop ();
		loading.SetActive (true);
		UIDisable.SetActive (false);
		SceneManager.LoadSceneAsync("Main Scene");
	}
}

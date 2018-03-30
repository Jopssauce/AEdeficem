using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOption : MonoBehaviour {

	public Slider[] VolumeSliders;

	void Awake()
	{
		DontDestroyOnLoad (gameObject);
	}

	void Start()
	{
		FindObjectOfType<AudioManager> ().Sounds [3].Source.volume = VolumeSliders[0].value;
		FindObjectOfType<AudioManager> ().Sounds [0].Source.volume = VolumeSliders[1].value;
		FindObjectOfType<AudioManager> ().Sounds [1].Source.volume = VolumeSliders[1].value;
		FindObjectOfType<AudioManager> ().Sounds [2].Source.volume = VolumeSliders[1].value;
	}

	public void SetMusicVolume()
	{
		FindObjectOfType<AudioManager> ().Sounds [3].Source.volume = VolumeSliders[0].value;
	}

	public void SetSFXVolume()
	{
		FindObjectOfType<AudioManager> ().Sounds [0].Source.volume = VolumeSliders[1].value;
		FindObjectOfType<AudioManager> ().Sounds [1].Source.volume = VolumeSliders[1].value;
		FindObjectOfType<AudioManager> ().Sounds [2].Source.volume = VolumeSliders[1].value;
	}
}

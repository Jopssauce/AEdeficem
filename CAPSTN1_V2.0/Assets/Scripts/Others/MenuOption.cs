using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOption : MonoBehaviour {

	public Slider[] VolumeSliders;

	void Start()
	{
		/*
		VolumeSliders[0].value = FindObjectOfType<AudioManager> ().Sounds [3].Source.volume;
		VolumeSliders[1].value = FindObjectOfType<AudioManager> ().Sounds [0].Source.volume;
		VolumeSliders[1].value = FindObjectOfType<AudioManager> ().Sounds [1].Source.volume;
		VolumeSliders[1].value = FindObjectOfType<AudioManager> ().Sounds [2].Source.volume;
		*/

		foreach (SoundFX s in FindObjectOfType<AudioManager>().Music)
		{
			VolumeSliders [0].value = s.Source.volume;
		}

		foreach (SoundFX s in FindObjectOfType<AudioManager>().Sounds)
		{
			VolumeSliders [1].value = s.Source.volume;
		}
	}

	public void SetMusicVolume()
	{
		foreach (SoundFX s in FindObjectOfType<AudioManager>().Music)
		{
			s.Source.volume = VolumeSliders [0].value;
		}
	}

	public void SetSFXVolume()
	{
		foreach (SoundFX s in FindObjectOfType<AudioManager>().Sounds)
		{
			s.Source.volume = VolumeSliders [1].value;
		}
	}
}

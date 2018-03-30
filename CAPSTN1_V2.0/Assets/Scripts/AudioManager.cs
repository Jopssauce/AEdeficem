using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

	//for now imma do dis
	[HideInInspector]
	public static AudioManager instance;

	public SoundFX[] Sounds;
	// Use this for initialization
	void Awake () 
	{
		foreach (SoundFX s in Sounds)
		{
			s.Source = gameObject.AddComponent<AudioSource> ();
			s.Source.clip = s.SoundEffect;
		}

		if (instance == null) 
		{
			instance = this;	
		}
		else if (instance != this) 
		{
			Destroy (gameObject);
		}
	}

	void OnDestroy()
	{
		instance = null;
	}
	
	public void Play (string name)
	{
		SoundFX s = Array.Find (Sounds, sound => sound.name == name);
		s.Source.Play();
	}
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

	public SoundFX[] Sounds;
	// Use this for initialization
	void Awake () 
	{
		foreach (SoundFX s in Sounds)
		{
			s.Source = gameObject.AddComponent<AudioSource> ();
			s.Source.clip = s.SoundEffect;
			s.Source.loop = s.Loop;
			// this is to help jops not get heart attack
			s.Source.volume = s.Volume;
		}
	}

	void Start()
	{
		Play ("Theme");
	}
	
	public void Play (string name)
	{
		SoundFX s = Array.Find (Sounds, sound => sound.name == name);
		s.Source.Play();
	}
}

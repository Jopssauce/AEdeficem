using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class SoundFX
{
	public string name;
	public AudioClip SoundEffect;

	[HideInInspector]
	public AudioSource Source;

	public bool Loop;

	[Range(0.0f, 1.0f)]
	public float Volume;
}

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
}

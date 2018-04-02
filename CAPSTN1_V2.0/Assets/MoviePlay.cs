using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MoviePlay : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		FindObjectOfType<AudioManager> ().PauseMusic ("Theme");
	}
}

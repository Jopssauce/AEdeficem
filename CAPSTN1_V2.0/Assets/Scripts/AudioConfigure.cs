using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class AudioConfigure : MonoBehaviour, IPointerClickHandler
{
	private AudioManager audioManager;

	void Start()
	{
		if (AudioManager.instance != null) 
		{
			audioManager = AudioManager.instance;
		}
	}

	public void OnPointerClick (PointerEventData eventData)
	{
		if (gameObject.tag == "End Turn") 
		{
			FindObjectOfType<AudioManager>().Play("SFX_EndTurnButton");
		}

		else if (gameObject.tag == "ResearchTag") {
			audioManager.Play ("SFX_ResearchButton");
		}

		else 
		{
			audioManager.Play ("SFX_ButtonCLick");
		}
	}
}

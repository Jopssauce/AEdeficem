using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetThumbNail : MonoBehaviour {

	public ResearchManager researchManager { get; set;}
	public Texture DefaultThumbnail;

	void Start()
	{
		if (ResearchManager.instance != null)
		{
			researchManager = ResearchManager.instance;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		SetSelectedResearchThumbnail ();
	}

	public void SetSelectedResearchThumbnail()
	{
		if (researchManager.selectedResearch != null) 
		{
			this.GetComponent<RawImage>().texture = researchManager.selectedResearch.Thumbnail;
		}

		if (researchManager.selectedResearch == null) 
		{
			this.GetComponent<RawImage> ().texture = DefaultThumbnail;
		}
	}

}

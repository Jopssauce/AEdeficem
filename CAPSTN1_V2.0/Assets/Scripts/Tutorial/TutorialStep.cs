using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialStep : MonoBehaviour 
{
	public GameObject backgroundPanel;
	public GameObject blockerPanel;

	public TutorialManager tutorialUI;

	public Image 	pointer;
	public Text 	textBox;
	public Button	nextButton;


	public Vector3 	  uiPos;
	public bool 	  isStepDone;
	public int 		  stepNumber;

	[TextArea(3,10)]
	public string tutorialDescription;

	void Start()
	{
		StartStep();
	}

	public void StartStep()
	{
		textBox.text = tutorialDescription;
		this.transform.SetParent(tutorialUI.transform);
		this.transform.SetAsLastSibling();
		this.GetComponent<RectTransform>().localPosition = uiPos;
		nextButton.onClick.AddListener(nextButtonClick);
	}

	public void nextButtonClick()
	{
		tutorialUI.NextStep.Invoke();
	}

}

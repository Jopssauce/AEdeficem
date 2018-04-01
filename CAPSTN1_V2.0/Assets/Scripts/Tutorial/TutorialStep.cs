using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialStep : MonoBehaviour 
{
	public TutorialManager tutorialUI;
	public TurnManager     turnManager;

	public Image 	pointer;
	public Text 	textBox;
	public Button	nextButton;


	public bool 	  isStepDone;
	public int 		  stepNumber;


	[TextArea(3,10)]
	public string tutorialDescription;

	void Start()
	{
		if (TurnManager.instance != null)
		{
			turnManager = TurnManager.instance;
		}
		StartStep();
	}

	public virtual void StartStep()
	{
		textBox.text = tutorialDescription;
		this.transform.SetAsLastSibling();
		nextButton.onClick.AddListener(nextButtonClick);
	}

	public virtual void nextButtonClick()
	{
		tutorialUI.NextStep.Invoke();
	}
	

}

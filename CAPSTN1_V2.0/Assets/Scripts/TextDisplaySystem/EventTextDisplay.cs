using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EventTextDisplay : MonoBehaviour {


    public EventDetails eventDetails;

    public Text EventText;
    public Text EventTitle;
	public Animator animator;

	Queue<string> details;

    // Use this for initialization
    void Start()
    {
		details = new Queue<string> ();
        StartText(eventDetails.eventText[Random.Range(0, eventDetails.eventText.Count)]);
    }


	public void StartText(EventText text)
 	{
		details.Clear();
        this.EventTitle.text = text.eventName;
		this.details.Enqueue(text.eventDetails);
 		
        if (this.details.Count <= 0)
		{
			//EndDialogue();
			return;
		}
		//description.text = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine( TypeSentence(details.Dequeue() ));
	}
    IEnumerator TypeSentence(string text)
	{
		EventText.text = "";
		foreach (char letter in text.ToCharArray())
		{
			EventText.text += letter;
			yield return new WaitForSeconds(0.0f);
		}
    }

	void OnEnable()
	{
		details = new Queue<string> ();
        StartText(eventDetails.eventText[Random.Range(0, eventDetails.eventText.Count)]);
		if (animator != null)
		{
			animator.SetBool("isOpen", true);
		}
		
	}
	void OnDisable()
	{
		if (animator != null)
		{
			animator.SetBool("isOpen", false);
		}
	}


}

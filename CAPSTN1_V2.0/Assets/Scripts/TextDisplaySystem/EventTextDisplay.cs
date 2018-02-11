using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EventTextDisplay : MonoBehaviour {
	public GameObject 	eventOrigin;
    public Text 		eventText;
    public Text 		eventTitle;
	public Animator 	animator;

	Queue<string> details;

    // Use this for initialization
    void Start()
    {
		details = new Queue<string> ();
		if (eventOrigin != null)
		{
			StartText(eventOrigin.GetComponent<EventPopUpBase>().eventData);
		}
    }


	public void StartText(EventData data)
 	{
		details.Clear();
        this.eventTitle.text = data.eventName;
		this.details.Enqueue(data.eventDetails);
 		
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
		eventText.text = "";
		foreach (char letter in text.ToCharArray())
		{
			eventText.text += letter;
			yield return new WaitForSeconds(0.0f);
		}
    }

	void OnEnable()
	{
		details = new Queue<string> ();
		if (eventOrigin != null)
		{
			StartText(eventOrigin.GetComponent<EventPopUpBase>().eventData);
		}
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

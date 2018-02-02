/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
	public Text eventName;
	public Text description;
	public Animator animator;
	Queue<string> sentences;
	//public static DialogueManager instance = null;
	

	void Start()
	{
		sentences = new Queue<string> ();
		
	}

	public void StartText(Dialogue dialogue)
	{
		animator.SetBool("open", true);
		sentences.Clear();
		this.eventName.text = dialogue.eventName;
		foreach (string sentence in dialogue.sentence)
		{
			this.sentences.Enqueue(sentence);
		}
		NextSentence();
	}

	public void NextSentence()
	{
		if (this.sentences.Count <= 0)
		{
			EndDialogue();
			return;
		}
		//description.text = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine( TypeSentence(sentences.Dequeue() ));
	}
	
	IEnumerator TypeSentence(string sentence)
	{
		description.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			description.text += letter;
			yield return new WaitForSeconds(0.0f);
		}
	}

	public void EndDialogue()
	{
		animator.SetBool("open", false);
	}


}
*/

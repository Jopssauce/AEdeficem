using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public struct Notification
{
	public string Title;
	public Sprite Icon;
	public UnityAction OnCancel;
}

public class Manager : MonoBehaviour {
	
	public int MaxNumberOfEvents;
	public GameObject ActionQueuePrefab;
	private List<Notification> notifications;
	// Use this for initialization
	void Start () {
		notifications = new List<Notification> ();
	}

	//shows notifs
	public void ShowNotification(Notification notification)
	{
		//float posY = 386.1f + (60.3f * (float)notifications.Count);
		/*if (notifications.Count >= MaxNumberOfEvents) 
		{
			// deletes the first index of the events
		}*/

		//GameObject NewNotif = Instantiate (ActionQueuePrefab, new Vector3 (0.0f, posY, 0.0f), Quaternion.identity);
		//notifications.Add (notification);
	}
}

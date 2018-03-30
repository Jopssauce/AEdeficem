using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventReader : EventPanel
{
	public Button   refundButton;
	public Button   resolveButton;
	public Text     unitIsBeingSent;
	
	public NotificationPanel notificationPanel;
	public void refundClick()
	{
		eventManager.IgnoredEvent.Invoke ();
		eventOrigin.GetComponent<EventPopUpBase> ().RefundEvent ();
		FindObjectOfType<AudioManager> ().Play ("Generic");
	}
	public void resolveClick()
	{
		eventManager.ResolvedEvent.Invoke ();
		eventOrigin.GetComponent<EventPopUpBase> ().ResolveEvent ();
		FindObjectOfType<AudioManager> ().Play ("Generic");
	}


}
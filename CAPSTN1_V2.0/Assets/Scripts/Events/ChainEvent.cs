using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChainEvent : EventPopUpBase 
{
	public List<GameObject> persistentEvents;
	public GameObject 		persistentEventPrefab;
	void OnClick()
	{
		eventManager.selectedEvent = this.GetComponent<EventPopUpBase>();
		eventPanel = Instantiate (eventPanelPrefab);
	}

	public override void ResolveEvent ()
	{
		base.ResolveEvent ();
		Debug.Log ("Short Resolve");
	}

	public void LongTermResolve()
	{
		base.ResolveEvent ();
		SpawnChildEvents (3);
		Debug.Log ("Long Resolve");
	}

	public override void IgnoreEvent ()
	{
		base.IgnoreEvent ();
	}

	public override void AssignButtons ()
	{
		eventPanel.GetComponent<EventReader>().ignoreButton.GetComponent<ResolveButton>().eventOrigin      = this.GetComponent<ChainEvent>();
		eventPanel.GetComponent<EventReader>().resolveButton.GetComponent<LongResolveButton>().eventOrigin    = this.GetComponent<ChainEvent>();
	}

	public void SpawnChildEvents(int amount)
	{
		for (int i = 0; i < amount; i++) 
		{
			if (persistentEvents.Count != 3) 
			{
				GameObject newEvent = Instantiate(persistentEventPrefab);
				newEvent.GetComponent<ChildEvent>().regionOrigin = this.regionOrigin;
				newEvent.GetComponent<ChildEvent>().eventOrigin = this.gameObject;
				newEvent.transform.SetParent(Canvas.FindObjectOfType<Canvas>().transform);
				persistentEvents.Add (newEvent);
			}

		}

	
	}
}

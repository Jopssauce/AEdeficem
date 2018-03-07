using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChainEvent : EventPopUpBase 
{
	public List<GameObject> persistentEvents;
	public GameObject 		persistentEventPrefab;
	public bool longTerm;
	public bool shortTerm;
	public override void Start ()
	{
		base.Start ();
		longTerm = true;
		shortTerm = true;
	}
	void OnClick()
	{
		eventManager.selectedEvent = this.GetComponent<EventPopUpBase>();
		eventPanel = Instantiate (eventPanelPrefab);
	}

	public override void ResolveEvent ()
	{
		base.ResolveEvent ();
		shortTerm = false;
		longTerm = true;
	}

	public void LongTermResolve()
	{
		base.ResolveEvent ();
		longTerm = false;
		shortTerm = true;
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
				newEvent.GetComponent<ChainChildEvent>().regionOrigin = this.regionOrigin;
				newEvent.GetComponent<ChainChildEvent>().eventOrigin = this.gameObject;
				newEvent.transform.SetParent(Canvas.FindObjectOfType<Canvas>().transform);
				newEvent.GetComponent<ChainChildEvent>().eventData    = eventManager.eventsList.tier1Events[Random.Range(0, eventManager.eventsList.tier1Events.Count)];
				persistentEvents.Add (newEvent);
			}

		}
	}

}

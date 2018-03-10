using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventPanel : MonoBehaviour 
{
	public GameObject ActionQueue;

    public EventPopUpBase   eventOrigin;

    public Button       exitButton;
    public Button       unitButton;
    public Image        eventThumbnail;
    public EventManager eventManager;
    public TurnManager  turnManager;

    private GameObject  NewQueueItem;
    public AQManager    aqManager;
    // Use this for initialization
    public virtual void Start()
    {
        if (EventManager.instance != null)
		{
			eventManager = EventManager.instance;
		}
        if (AQManager.instance != null)
        {
            aqManager = AQManager.instance;
        }

    }

    /*public virtual void AddToActionQue()
    {
        if (eventOrigin.GetComponent<EventPopUpBase>().isResolved == false)
        {
            if (ResourceManager.instance.isEnoughRes(eventOrigin.gameObject) == true)
            {           
                aqManager.Panel.SetActive(true);
                NewQueueItem = Instantiate(ActionQueue) as GameObject;
                NewQueueItem.transform.SetParent(aqManager.ParentPrefab.transform, false);
                //NewQueueItem.GetComponent<UIActionElement>().eventOrigin = this.eventOrigin;
            }
        }
       
    }*/
    public virtual void SendUnitButtonClick()
    {
        eventOrigin.cityOrign.SpawnUnit(eventOrigin);
        Destroy(eventOrigin.eventPanel);
    }
}

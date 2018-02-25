using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventReader : MonoBehaviour
{
    public GameObject ActionQueue;

    public GameObject   eventOrigin;
    public GameObject   ignoreButton;
    public GameObject   resolveButton;
    public Image        eventThumbnail;
    EventManager        eventManager;

    private GameObject  NewQueueItem;
    public AQManager    aqManager;
    // Use this for initialization
    void Start()
    {
        if (EventManager.instance != null)
		{
			eventManager = EventManager.instance;
		}
        if (AQManager.instance != null)
        {
            aqManager = AQManager.instance;
        }
        //ignoreButton.GetComponent<IgnoreButton>().eventOrigin = this.eventOrigin.GetComponent<EventPopUpBase>();
        //resolveButton.GetComponent<ResolveButton>().eventOrigin = this.eventOrigin.GetComponent<EventPopUpBase>();

        //eventOrigin.GetComponent<EventPopUpBase>().ResolvedEvent.AddListener(AddToActionQue);
    }

    public void AddToActionQue()
    {
        if (eventOrigin.GetComponent<EventPopUpBase>().isResolved == false)
        {
            if (ResourceManager.instance.isEnoughRes(eventOrigin) == true)
            {           
                aqManager.Panel.SetActive(true);
                NewQueueItem = Instantiate(ActionQueue) as GameObject;
                NewQueueItem.transform.SetParent(aqManager.ParentPrefab.transform, false);
                NewQueueItem.GetComponent<UIActionElement>().eventOrigin = this.eventOrigin;
            }
        }
       
    }

  


}
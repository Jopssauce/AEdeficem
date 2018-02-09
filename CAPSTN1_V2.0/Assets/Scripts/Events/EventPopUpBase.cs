using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventPopUpBase : MonoBehaviour
{
    public string EventTitle;
    public int TurnsBeforeFail;
    [TextArea]
    public string EventDetails;
    public bool isResolved;
    public GameObject EventCanvas;

    public GameObject RegionOrigin;

	public Vector3 randPos;

	// Use this for initialization
	void Start ()
    {
        this.GetComponent<Button>().onClick.AddListener(Click);
	}
	
	// Update is called once per frame
	void Update ()
    {
		this.transform.position = Camera.main.WorldToScreenPoint(RandomPointInPolygon(RegionOrigin.GetComponent<BoxCollider>().bounds.center, RegionOrigin.GetComponent<BoxCollider>().bounds, randPos) );
	}

    void Click()
    {
        EventManager.instance.EventPanel.SetActive(true);
        EventManager.instance.EventPanel.GetComponent<EventReader>().EventOrigin = this.GetComponent<Button>();
        EventManager.instance.EventPanel.transform.SetAsLastSibling();
    }
	private Vector3 RandomPointInPolygon(Vector3 center, Bounds size, Vector3 randPos)
	{
		return center + new Vector3((randPos.x - 0.55f) * size.extents.x,(randPos.y - 0.55f) * size.extents.y, (randPos.z - 0.55f) * size.extents.z);
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResearchManager : MonoBehaviour 
{

    public struct TierProgress
    {
        public int disasterPrepTier;
        public int resourceProdTier;
        public int transportEffTier;
        public int regionalPlanTier;
    }

    

    public List<Technology> disasterPrepTech;
    public List<Technology> disasterPrepTechCopy;

	public List<Technology> resourceProdTech;
    public List<Technology> resourceProdTechCopy;

	public List<Technology> transportEffTech;
    public List<Technology> transportEffTechCopy;

	public List<Technology> regionalPlanTech;
    public List<Technology> regionalPlanTechCopy;

    public List<Technology> unlockedTech;

    public static ResearchManager instance;
    public TierProgress tierProgress;

    public Technology selectedResearch;

    public class ProgressResearchTier : UnityEvent<Technology.TechType>{} 
    public ProgressResearchTier progressResearchTier;
    public UnityEvent ResearchFinished;
    void Awake()
    {
        if (instance == null) 
		{
			instance = this;	
		}
		else if (instance != this) 
		{
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
        progressResearchTier = new ProgressResearchTier();
        progressResearchTier.AddListener(AddTier);
    }

    void Start()
    {
        tierProgress.disasterPrepTier = 0;
        tierProgress.resourceProdTier = 0;
        tierProgress.transportEffTier = 0;
        tierProgress.regionalPlanTier = 0;

        foreach (var item in disasterPrepTech)
        {
            disasterPrepTechCopy.Add(Instantiate(item));
        }

        foreach (var item in resourceProdTech)
        {
             resourceProdTechCopy.Add(Instantiate(item));
        }

        foreach (var item in transportEffTech)
        {
            transportEffTechCopy.Add(Instantiate(item));
        }
        
        foreach (var item in regionalPlanTech)
        {
            regionalPlanTech.Add(Instantiate(item));
        }
        
    }

    public void AddTier(Technology.TechType type)
    {
        switch (type)
        {
            case Technology.TechType.Disaster :
            tierProgress.disasterPrepTier++;
            break;
            case Technology.TechType.Resource :
            tierProgress.disasterPrepTier++;
            break;
            case Technology.TechType.Transport :
            tierProgress.disasterPrepTier++;
            break;
            case Technology.TechType.Regional :
            tierProgress.disasterPrepTier++;
            break;
            default:
            break;
        }
    }

}

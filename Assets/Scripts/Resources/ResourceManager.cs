using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResourceManager : MonoBehaviour
{
    // SINGLETON
    public static ResourceManager Instance { private set; get; }

    public event UnityAction<ResourceTypeSO, int> OnResourceCollected;

    public Dictionary<string, int> mResourcesAvailable
        = new Dictionary<string, int>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddResourceType(ResourceTypeSO resourceType)
    {
        mResourcesAvailable.Add(resourceType.name, 0);
    }

    public void AddResourceAmount(ResourceTypeSO resourceType, int amount)
    {
        mResourcesAvailable[resourceType.name] += amount;
        OnResourceCollected?.Invoke(
            resourceType,
            mResourcesAvailable[resourceType.name]
        );
    }
}

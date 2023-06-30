using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField]
    private ResourceTypeSO resourceType;

    private int mCurrentAmount;

    private void Awake()
    {
        mCurrentAmount = resourceType.maxAmount;
    }

    public void FarmResource(int quantity)
    {
        if (mCurrentAmount > 0)
        {
            mCurrentAmount -= quantity;
            ResourceManager.Instance.AddResourceAmount(resourceType, quantity);
        }else
        {
            Destroy(gameObject);
        }
        
    }
}

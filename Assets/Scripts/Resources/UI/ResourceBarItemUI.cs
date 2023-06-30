using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResourceBarItemUI : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image image;
    
    public ResourceTypeSO ResourceType { set; get; }

    void Start()
    {
        ResourceManager.Instance.OnResourceCollected += OnResourceCollectedDelegate;
    }

    public void Init(Sprite sprite)
    {
        image.sprite = sprite;
    }

    private void OnResourceCollectedDelegate(ResourceTypeSO resourceType, int resourceAmount)
    {
        if (resourceType == ResourceType)
        {
            text.text = resourceAmount.ToString();
        }
    }
}

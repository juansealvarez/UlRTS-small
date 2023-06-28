using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBarUI : MonoBehaviour
{
    [SerializeField]
    private List<ResourceTypeSO> resourceList;
    [SerializeField]
    private Transform resourceItemBarUI;
    private void Start()
    {
        float offset = 55f;
        int index = 0;
        foreach(var resourceType in resourceList)
        {
            var resourceItem = Instantiate(resourceItemBarUI, transform);
            resourceItem.GetComponent<RectTransform>().anchoredPosition =
                new Vector2(
                    offset * index,
                    0f
                );
            index++;
        }
    }
}

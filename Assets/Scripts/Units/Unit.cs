using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private GameObject selected;
    [SerializeField]
    private FirstUnitSO unitType;
    public bool Selected { private set; get; } = false;

    public void Select()
    {
        Selected = !Selected;
        selected.SetActive(Selected);
    }
}

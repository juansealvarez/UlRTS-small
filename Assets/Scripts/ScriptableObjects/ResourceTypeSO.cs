using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Resource")]
public class ResourceTypeSO : ScriptableObject
{
    public new string name;
    public Transform prefab;
    public int maxAmount;
    public Sprite sprite;
}

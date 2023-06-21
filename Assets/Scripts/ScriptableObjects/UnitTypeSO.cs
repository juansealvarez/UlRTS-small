using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Unit")]
public class UnitTypeSO : ScriptableObject
{
    public new string name;
    public float speed;
    public float awakeRange;
    public Transform prefab;
    public Sprite sprite;
}

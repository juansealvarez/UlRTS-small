using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Unit")]
public class FirstUnitSO : ScriptableObject
{
    public new string name;
    public float speed;
    public float awakeRange;
}

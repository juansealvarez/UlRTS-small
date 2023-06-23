using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAction : MonoBehaviour
{
    public bool IsActive;
    private NavMeshAgent mAgent;
    private Unit mUnit;
    private void Awake()
    {
        mAgent = GetComponent<NavMeshAgent>();
        mUnit = GetComponent<Unit>();
    }

    private void Start()
    {
        mAgent.speed = mUnit.GetUnitTypeSO().speed;
    }
    
    public void Move(Vector3 position)
    {
        mAgent.destination = position;
    }
}

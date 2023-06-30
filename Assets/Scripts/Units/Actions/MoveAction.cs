using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAction : MonoBehaviour
{
    public bool IsActive = true;
    [SerializeField]
    private float colliderRadius = 2f;
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

    private void Update()
    {
        if (IsActive)
        {
            if (mUnit.GetComponent<CollectAction>() != null && IsResourceNear(out Resource resource))
            {
                
                mAgent.isStopped = true;
                mUnit.Collect(resource);
            }    
        }
    }

    private bool IsResourceNear(out Resource resource)
    {
        resource = null;
        var colliders = Physics.OverlapSphere(
            transform.position,
            colliderRadius,
            LayerMask.GetMask("Resource"));
        if (colliders.Length > 0)
        {
            return colliders[0].TryGetComponent<Resource>(out resource);
        }else
        {
            return false;
        }
    }

    public void Move(Vector3 position)
    {
        mAgent.isStopped = false;
        mAgent.destination = position;
    }
}

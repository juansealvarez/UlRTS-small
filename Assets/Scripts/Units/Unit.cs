using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private GameObject selected;
    [SerializeField]
    private UnitTypeSO unitType;

    private MoveAction mMoveAction;
    private CollectAction mCollectAction;
    public bool Selected { private set; get; } = false;

    private void Awake()
    {
        mMoveAction = GetComponent<MoveAction>();
        mCollectAction = GetComponent<CollectAction>();
    }

    public void Select()
    {
        Selected = !Selected;
        selected.SetActive(Selected);
    }

    public void Move(Vector3 position)
    {
        if (TryGetComponent<MoveAction>(out MoveAction moveAction))
        {
            mMoveAction.IsActive = true;
            moveAction.Move(position);
        }
    }
    
    public UnitTypeSO GetUnitTypeSO()
    {
        return unitType;
    }

    public void Collect(Resource resource)
    {
        if (mCollectAction != null)
        {
            mCollectAction.resource = resource;
            mMoveAction.IsActive = false;
            mCollectAction.IsActive = true;
        }
    }
}

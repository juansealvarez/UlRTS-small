using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public enum SpawningState
{
    Selection, Spawn
}

public class UnitInputCrontroller : MonoBehaviour
{
    public SpawningState CurrentSpawningState = SpawningState.Selection;

    public event UnityAction OnCancelSelection;

    public static UnitInputCrontroller Instance { get; private set; }
    private bool mPressed = false;
    private Vector3 mMultipleSelectionStartPosition;
    private Vector3 mMultipleSelectionEndPosition;
    private Vector3 center;
    private Vector3 halfExtends;

    private void Awake() {
        Instance = this;
    }
    private void OnSelection(InputValue value)
    {
        if (value.isPressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(
                Mouse.current.position.x.value,
                Mouse.current.position.y.value
            ));

            if (Physics.Raycast(
                ray,
                out RaycastHit hit,
                float.MaxValue
            ))
            {
                if (CurrentSpawningState == SpawningState.Selection)
                {
                    if (hit.collider.TryGetComponent<Unit>(out Unit unit))
                    {
                        UnitManager.Instance.SelectUnit(unit);
                    }
                }else
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        UnitManager.Instance.SpawnUnit(hit.point);
                    }
                }
            }
        }
    }

    private void OnCancel(InputValue value)
    {
        if (value.isPressed)
        {
            CurrentSpawningState = SpawningState.Selection;
            OnCancelSelection?.Invoke();
            UnitManager.Instance.DeselectAll();
        }
    }

    private void OnMoveUnit(InputValue value)
    {
        if (value.isPressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(
                Mouse.current.position.x.value,
                Mouse.current.position.y.value
            ));

            if (Physics.Raycast(
                ray,
                out RaycastHit hit,
                float.MaxValue
            ))
            {
                // Mover las unidades
                UnitManager.Instance.MoveUnits(hit.point);
            }
        }
    }

    private void OnMultipleSelectionPress(InputValue value)
    {
        if (value.isPressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(
                Mouse.current.position.x.value,
                Mouse.current.position.y.value
            ));

            if (Physics.Raycast(
                ray,
                out RaycastHit hit,
                float.MaxValue
            ))
            {
                mMultipleSelectionStartPosition = hit.point;
                mMultipleSelectionEndPosition = mMultipleSelectionStartPosition;
                mPressed = true;
            }
        }
    }

    private void OnMultipleSelectionRelease(InputValue value)
    {
        if (mPressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(
                Mouse.current.position.x.value,
                Mouse.current.position.y.value
            ));

            if (Physics.Raycast(
                ray,
                out RaycastHit hit,
                float.MaxValue
            ))
            {
                mMultipleSelectionEndPosition = hit.point;

                center = new Vector3(
                    (mMultipleSelectionStartPosition.x + mMultipleSelectionEndPosition.x)/2f,
                    0f,
                    (mMultipleSelectionStartPosition.z + mMultipleSelectionEndPosition.z)/2f
                );

                halfExtends = new Vector3(
                    Mathf.Abs(mMultipleSelectionEndPosition.x - mMultipleSelectionStartPosition.x)/2,
                    1f,
                    Mathf.Abs(mMultipleSelectionEndPosition.z - mMultipleSelectionStartPosition.z)/2
                );

                var colliders = Physics.OverlapBox(
                    center,
                    halfExtends,
                    Quaternion.identity,
                    LayerMask.GetMask("Unit")
                );

                foreach (var collider in colliders)
                {
                    if (collider.TryGetComponent<Unit>(out Unit unit))
                    {
                        UnitManager.Instance.SelectUnit(unit);
                        mPressed = false;
                    }
                }
            }
            
        }
    }
}

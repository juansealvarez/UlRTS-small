using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public enum SpawningState
{
    Selection, Spawn
}
public class UnitInputCrontroller : MonoBehaviour
{
    public SpawningState CurrentSpawningState = SpawningState.Selection;

    public static UnitInputCrontroller Instance { get; private set; }

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
            UnitManager.Instance.DeselectAll();
        }
    }
}

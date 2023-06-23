using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance { private set; get; }
    private List<Unit> mSelectedUnits = new List<Unit>();
    private UnitTypeSO mSelectedUnitToSpawn = null;
    public int unitSelected = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectUnit(Unit unit)
    {
        if (!unit.Selected)
        {
            mSelectedUnits.Add(unit);
        }else
        {
            mSelectedUnits.Remove(unit);
        }
        
        unit.Select();
        unitSelected = mSelectedUnits.Count;
    }

    public void DeselectAll()
    {
        foreach (var unit in mSelectedUnits)
        {
            unit.Select();
        }
        mSelectedUnits.Clear();
    }

    public void SelectUnitToSpawn(UnitTypeSO unitType)
    {
        UnitInputCrontroller.Instance.CurrentSpawningState = SpawningState.Spawn;
        mSelectedUnitToSpawn = unitType;
    }

    public void SpawnUnit(Vector3 position)
    {
        if (mSelectedUnitToSpawn != null)
        {
            Instantiate(mSelectedUnitToSpawn.prefab, position, Quaternion.identity);
        }
    }

    public void MoveUnits(Vector3 position)
    {
        foreach (var unit in mSelectedUnits)
        {
            unit.Move(position);
        }
    }
}

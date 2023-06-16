using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance { private set; get; }
    private List<Unit> mSelectedUnits = new List<Unit>();
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
}

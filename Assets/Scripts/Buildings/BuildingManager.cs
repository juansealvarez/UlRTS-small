using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance { private set; get; }

    private BuildingTypeSO mSelectedBuildingToBuild = null;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectBuildingToSpawn(BuildingTypeSO buildingType)
    {
        UnitInputCrontroller.Instance.CurrentSpawningState = SpawningState.Spawn;
        mSelectedBuildingToBuild = buildingType;
    }

    public void BuildBuilding(Vector3 position)
    {
        if (mSelectedBuildingToBuild != null)
        {
            Instantiate(
                mSelectedBuildingToBuild.prefab,
                position,
                Quaternion.identity
            );
        }
    }
}

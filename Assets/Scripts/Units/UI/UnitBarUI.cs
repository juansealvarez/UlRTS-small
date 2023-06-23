using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitBarUI : MonoBehaviour
{
    [SerializeField]
    private List<UnitTypeSO> unitTypeList;
    [SerializeField]
    private Transform pfUnitBarItemUI;
    private Transform prefabSeleccionado = null;

    private void Start() {
        float offset = 100f;
        int index = 0;
        foreach (var unitType in unitTypeList)
        {
            // Instanciar PF_UnitBarItemUI
            var unitBarItem = Instantiate(pfUnitBarItemUI, transform);
            unitBarItem.GetComponent<RectTransform>().anchoredPosition =
                new Vector2(
                    index * offset,
                    0f
            );
            unitBarItem.GetComponent<UnitBarItemUI>().Init(
                unitType.sprite,
                () => {
                    Debug.Log($"Se spawneara {unitType.name}");
                    if (prefabSeleccionado != null)
                    {
                        prefabSeleccionado.GetComponent<UnitBarItemUI>().DeSelect();
                    }
                    unitBarItem.GetComponent<UnitBarItemUI>().Select();
                    prefabSeleccionado = unitBarItem;
                    UnitManager.Instance.SelectUnitToSpawn(unitType);
                }
            );
            index++;
        }
    }
}

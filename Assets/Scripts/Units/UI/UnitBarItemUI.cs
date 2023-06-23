using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UnitBarItemUI : MonoBehaviour
{
    [SerializeField]
    private Image image;
    private Button mButtonClick;
    private void Awake() {
        mButtonClick = GetComponent<Button>();
    }

    private void Start()
    {
        UnitInputCrontroller.Instance.OnCancelSelection += UnitBarItemUI_OnCancelSelection;
    }

    private void UnitBarItemUI_OnCancelSelection()
    {
        DeSelect();
    }

    public void Init(Sprite sprite, UnityAction onClickListener)
    {
        //Inicializar el GO
        image.sprite = sprite;
        mButtonClick.onClick.AddListener(onClickListener);
    }

    public void Select()
    {
        GetComponent<Image>().color = Color.red;
    }

    public void DeSelect()
    {
        GetComponent<Image>().color = Color.white;
    }
}

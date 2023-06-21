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
    public void Init(Sprite sprite, UnityAction onClickListener)
    {
        //Inicializar el GO
        image.sprite = sprite;
        mButtonClick.onClick.AddListener(onClickListener);
    }
}

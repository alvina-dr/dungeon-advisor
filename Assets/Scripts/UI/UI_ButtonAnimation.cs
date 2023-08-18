using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class UI_ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject button;
    public void OnPointerEnter(PointerEventData eventData)
    {
        button.transform.DOLocalMoveY(10, .1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button.transform.DOLocalMoveY(0, .1f);
    }
}

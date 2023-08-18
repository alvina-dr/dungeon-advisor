using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class UI_ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject button;
    [SerializeField] private List<Image> backgroundList = new List<Image>();
    [SerializeField] private Color active;
    [SerializeField] private Color selected;
    public void OnPointerEnter(PointerEventData eventData)
    {
        button.transform.DOLocalMoveY(10, .1f);
        for (int i = 0; i < backgroundList.Count; i++)
        {
            backgroundList[i].color = selected;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button.transform.DOLocalMoveY(0, .1f);
        for (int i = 0; i < backgroundList.Count; i++)
        {
            backgroundList[i].color = active;
        }
    }
}

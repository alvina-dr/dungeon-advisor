using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class UINotif : MonoBehaviour
{
    public TextMeshProUGUI text;
    public CanvasGroup canvas;

    public void Pop(string _text)
    {
        text.text = _text;
        canvas.DOFade(1, .3f);
        DOVirtual.DelayedCall(1, () => canvas.DOFade(0, .3f));
    }
}

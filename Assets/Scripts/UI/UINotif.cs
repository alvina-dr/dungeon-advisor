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
        canvas.DOFade(1, .3f).OnComplete(() =>
        {
            DOVirtual.DelayedCall(3f, () => canvas.DOFade(0, .3f));
        });
    }
}

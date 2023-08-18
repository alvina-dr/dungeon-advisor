using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HeroIcon : MonoBehaviour
{
    public float targetScale;
    public Transform target;

    private void Start()
    {
        target.DOScale(targetScale, .4f).SetLoops(-1, LoopType.Yoyo);
    }
}

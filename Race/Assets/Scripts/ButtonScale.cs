using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonScale : MonoBehaviour
{
    private void Start()
    {
        Change();
    }

    private void Change()
    {
        transform.DOScale(2, 1).SetLoops(-1, LoopType.Yoyo);
    }
}

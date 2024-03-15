using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BasePopup : MonoBehaviour
{
    [SerializeField] protected Transform main;
    [SerializeField] protected Button btnClose;

    public virtual void Awake()
    {
        btnClose?.onClick.AddListener(Hide);
    }

    public void Show()
    {
        main.transform.localScale = Vector3.one * 0.6f;
        main.DOScale(1, 0.33f).SetEase(Ease.Linear);
    }

    public void Hide()
    {
        main.DOScaleX(0.01f, 0.33f).SetEase(Ease.Linear).OnComplete(() =>
        {
            main.DOScaleY(0, 0.33f).SetEase(Ease.Linear).OnComplete(() => { gameObject.SetActive(false); });
        });
    }
}
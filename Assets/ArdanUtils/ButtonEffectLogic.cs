﻿using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

[AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
public class ButtonAttribute : PropertyAttribute
{
}

public class ButtonEffectLogic : Button
{
    public bool hasEffect = false;
    public bool clickSound = true;
    public bool isUsingRealTime = true;
    bool Delay = true;
    public float TimeDeLay = 0;

    public UnityEvent onEnter = new UnityEvent(),
        onDown = new UnityEvent(),
        onExit = new UnityEvent(),
        onUp = new UnityEvent();

    Vector3 initScale;

    protected override void Awake()
    {
        initScale = transform.localScale;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (clickSound)
        {
            // AudioManage.instance.PlaySound(soundsGame.click,0.5f);
        }

        if (Delay)
        {
            Delay = false;
            base.OnPointerClick(eventData);
            DG.Tweening.DOVirtual.DelayedCall(TimeDeLay, () => { Delay = true; });
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        onDown.Invoke();
        EffectDown();
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        onEnter.Invoke();
        EffectDown();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        onUp.Invoke();
        EffectUp();
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        onExit.Invoke();
        EffectUp();
    }


    void EffectDown()
    {
        //SoundManageLogic.Instance?.PlayButton(SoundManageLogic.Instance.btnClickSound);
        //ScaleUp();
    }

    void EffectUp()
    {
        ScaleDown();
    }

    void ScaleUp()
    {
        if (hasEffect)
        {
            transform.localScale = initScale;
            transform.DOScale(initScale * 0.9f, 0.1f).SetEase(Ease.InBounce).SetUpdate(isUsingRealTime);
        }
    }

    void ScaleDown()
    {
        if (hasEffect)
        {
            transform.localScale = initScale * 0.9f;
            transform.DOScale(initScale, 0.4f).SetEase(Ease.OutElastic).SetUpdate(isUsingRealTime);
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        transform.DOKill();
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(ButtonEffectLogic))]
public class ButtonEffectLogicEditor : Editor
{
    ButtonEffectLogic mtarget;

    private void OnEnable()
    {
        mtarget = target as ButtonEffectLogic;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}
#endif
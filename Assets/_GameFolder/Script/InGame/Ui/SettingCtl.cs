using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingCtl : MonoBehaviour
{
    public void BtnListener_ReturnHome()
    {
    }

    public void BtnListener_Replay()
    {
    }

    public void BtnListener_Continue()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }
}
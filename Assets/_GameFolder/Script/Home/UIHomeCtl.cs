using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHomeCtl : MonoBehaviour
{
    public Notify notify;

    [Header("Panel Shop")] public SelectWeapon panelShopWeapon;
    public SelectCharacter panelShopCharacter;
    public PanelMission panelMission;


    #region BtnListener

    public void BtnListener_InfinityMode()
    {
    }

    public void BtnListener_SinglePlayerMode()
    {
        SceneManager.LoadScene(CONST.SINGLE_MODE_NAME_SCENE);
    }

    public void BtnListener_MultiPlayerMode()
    {
    }

    public void BtnListener_SelectWeapon()
    {
        panelShopWeapon.gameObject.SetActive(true);
        panelShopWeapon.Show();
    }

    public void BtnListener_SelectCharacter()
    {
        panelShopCharacter.gameObject.SetActive(true);
        panelShopCharacter.Show();
    }

    public void BtnListener_SelectSupportItem()
    {
    }

    public void BtnListener_SelectSkill()
    {
    }

    public void BtnListener_OpenMasteries()
    {
    }

    public void BtnListener_OpenCollections()
    {
    }

    public void BtnListener_OpenLeaderBoards()
    {
    }

    public void BtnListener_OpenContact()
    {
    }

    #endregion

    public void UpdateNotify(string title, string content)
    {
        notify.gameObject.SetActive(true);
        notify.Show();
        notify.UpdateNotify(title, content);
    }
}
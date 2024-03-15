using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectWeapon : BasePopup
{
    public static SelectWeapon Instance;
    public GunDataSO gunData;

    [Header("Button Select Gun")] public Transform content;
    public SelectGunButton btnSelectPrefabs;
    public GameObject btnSelectGun;
    [HideInInspector] public List<SelectGunButton> listItemSelects;

    [Header("Model Data Gun")] public Transform model;
    public List<(GameObject guns, int indexInSO)> gunSelects = new();
    public TMP_Text nameGun;
    public GameObject dataUI;
    public TMP_Text damage;
    public TMP_Text rateOfFire;
    public TMP_Text numberBullet;
    public TMP_Text timeReload;

    private int _oldIndexSelectGun = 0;

    public override void Awake()
    {
        base.Awake();
        Instance = this;
    }

    private void OnEnable()
    {
        var numGunActive = 0;
#if UNITY_EDITOR
        PrefData.SetHaveGun(0);
        PrefData.SetHaveGun(1);
#endif


        #region Funtion Init

        void InstanceGun()
        {
            for (var i = 0; i < gunData.listGunData.Count; i++)
            {
                if (PrefData.IsHaveGun(i))
                {
                    var gun = Instantiate(gunData.listGunData[i].model.transform.GetChild(0).gameObject, model);
                    gunSelects.Add((gun, i));
                    gun.transform.localScale = Vector3.one * 100;
                    gun.transform.localRotation = Quaternion.Euler(0, 90, 0);
                    gun.gameObject.SetActive(false);
                    var btn = Instantiate(btnSelectPrefabs, content);
                    listItemSelects.Add(btn);
                    btn.index = numGunActive;
                    btn.SetGunData = gunData.listGunData[i].data;
                    btn.Init();
                    numGunActive++;
                }
            }
        }

        #endregion
    }

    public void ChangeUI(int index, GunData data)
    {
        nameGun.text = data.name;
        nameGun.gameObject.SetActive(true);
        gunSelects[_oldIndexSelectGun].guns.SetActive(false);
        gunSelects[index].guns.SetActive(true);
        _oldIndexSelectGun = index;
        dataUI.SetActive(true);
        damage.text = data.damage + "";
        rateOfFire.text = data.rateOfFire + "";
        numberBullet.text = data.maxBullet + "";
        timeReload.text = data.bulletReloadTime + "";
        btnSelectGun.SetActive(PrefData.gun_type != gunSelects[_oldIndexSelectGun].indexInSO);
    }

    public void BtnListener_SelectThisItem()
    {
        PrefData.gun_type = gunSelects[_oldIndexSelectGun].indexInSO;
        btnSelectGun.SetActive(false);
    }

    private void OnDisable()
    {
        dataUI.SetActive(false);
        gunSelects[_oldIndexSelectGun].guns.SetActive(false);
        nameGun.gameObject.SetActive(false);
        btnSelectGun.SetActive(false);
    }
}
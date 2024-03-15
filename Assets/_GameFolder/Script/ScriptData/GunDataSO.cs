using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GunData
{
    public Sprite avatar;
    public float rateOfFire;
    public float damage;
    public float bulletReloadTime;
    public float bulletSpeed;
    public int maxBullet;
    public string name;
}


[CreateAssetMenu(fileName = "GunData", menuName = "datas/GunData")]
public class GunDataSO : ScriptableObject
{
    [Serializable]
    public class GunModel
    {
        public GameObject model;
        public GunData data;
    }

    public List<GunModel> listGunData;
}
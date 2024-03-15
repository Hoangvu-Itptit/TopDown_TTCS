using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class BaseGun : MonoBehaviour
{
    [SerializeField] protected Transform bulletPosStart;
    [SerializeField] protected BaseBullet bullet;
    protected GunData gunData;
    protected int curBullet;
    protected bool isReloading;
    protected List<BaseBullet> listBullet = new();
    protected float _timer = 0f;

    public GunData GetGunData => gunData;
    public abstract void GunShoot(Vector2 dir);

    protected void Update()
    {
        if (_timer < gunData.rateOfFire)
        {
            _timer += Time.deltaTime;
        }
    }

    public virtual void Start()
    {
        Init();
        UiController.Instance.UpdatePlayerNumberBullet($"{curBullet:00}/{gunData.maxBullet}");
    }

    public void Init()
    {
        gunData = GameController.Instance.gunData.listGunData[PrefData.gun_type].data;
        bullet.Damage = gunData.damage;
        curBullet = gunData.maxBullet;
        // Debug.Log(gunData.rateOfFire);
    }

    public virtual IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(gunData.bulletReloadTime);
        curBullet = gunData.maxBullet;
        UiController.Instance.UpdatePlayerNumberBullet($"{curBullet:00}/{gunData.maxBullet}");
        isReloading = false;
    }

    public BaseBullet GetNewBullet()
    {
        var newBullet = listBullet.FirstOrDefault(bul => bul.gameObject.activeSelf == false);
        if (newBullet == null)
        {
            newBullet = Instantiate(bullet);
            newBullet.ActiveTrailRenderer(false);
            newBullet.gameObject.SetActive(false);
            listBullet.Add(newBullet);
        }

        newBullet.SetVelocity(Vector3.zero);
        newBullet.Damage = bullet.Damage;
        newBullet.Length = bullet.Length;
        newBullet.ActiveTrailRenderer(false);
        return newBullet;
    }
}
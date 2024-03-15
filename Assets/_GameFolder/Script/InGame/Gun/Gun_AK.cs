using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Gun_AK : BaseGun
{
    private void Update()
    {
        if (_timer < gunData.rateOfFire)
        {
            _timer += Time.deltaTime;
        }
    }

    public override void GunShoot(Vector2 dir)
    {
        if (isReloading || _timer < gunData.rateOfFire) return;
        _timer = 0f;
        var newBullet = GetNewBullet();
        newBullet.transform.position = bulletPosStart.position;
        newBullet.gameObject.SetActive(true);
        newBullet.AddForce(new Vector3(dir.x, 0, dir.y).normalized * gunData.bulletSpeed);
        curBullet--;
        if (curBullet == 0)
        {
            isReloading = true;
            StartCoroutine(Reload());
        }

        UiController.Instance.UpdatePlayerNumberBullet($"{curBullet:00}/{gunData.maxBullet}");
    }
}
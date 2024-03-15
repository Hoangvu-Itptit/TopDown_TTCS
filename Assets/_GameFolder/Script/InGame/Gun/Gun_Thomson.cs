using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Gun_Thomson : BaseGun
{
    public override void GunShoot(Vector2 dir)
    {
        if (isReloading || _timer < gunData.rateOfFire) return;
        _timer = 0f;
        Action shoot = () =>
        {
            if (isReloading || curBullet <= 0) return;
            var newBullet = GetNewBullet();
            newBullet.transform.position = bulletPosStart.position;
            newBullet.gameObject.SetActive(true);
            newBullet.AddForce(new Vector3(dir.x, 0, dir.y).normalized * gunData.bulletSpeed);
            curBullet--;
            UiController.Instance.UpdatePlayerNumberBullet($"{curBullet:00}/{gunData.maxBullet}");
        };
        shoot();
        this.StartDelayAction(0.05f, shoot);

        if (curBullet == 0)
        {
            isReloading = true;
            StartCoroutine(Reload());
        }
    }
}
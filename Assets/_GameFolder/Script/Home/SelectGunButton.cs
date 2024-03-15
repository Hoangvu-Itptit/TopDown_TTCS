using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGunButton : BaseItemSelectButton
{
    private GunData _gunData;

    public GunData SetGunData
    {
        set => _gunData = value;
    }

    public void Init()
    {
        ChangeUI(_gunData.avatar, _gunData.name);
    }

    public override void BtnListener_Select()
    {
        SelectWeapon.Instance.ChangeUI(index, _gunData);
    }
}
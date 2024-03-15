using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectModelButton : BaseItemSelectButton
{
    protected PlayerData playerData;

    public PlayerData SetPlayerData
    {
        set => playerData = value;
    }

    public void Init()
    {
        ChangeUI(playerData.avatar, playerData.name);
    }

    public override void BtnListener_Select()
    {
        SelectCharacter.Instance.ChangeUI(index, playerData);
    }
}
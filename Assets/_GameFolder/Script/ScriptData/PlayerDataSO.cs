using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData : HumanData
{
    public string name;
}

[CreateAssetMenu(fileName = "PlayerData", menuName = "datas/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    public List<PlayerData> listPlayerData;
}
using System;
using System.Collections.Generic;
using UnityEngine;

public enum MissionType
{
    KillEnemy,
    GameWin,
}

[Serializable]
public class MissionData
{
    public string txtTitle;
    public int missionProgress;
    public MissionType missionType;
}

[CreateAssetMenu(fileName = "MissionData", menuName = "datas/MissionData")]
public class MissionDataSO : ScriptableObject
{
    public List<MissionData> listMissionData;
}
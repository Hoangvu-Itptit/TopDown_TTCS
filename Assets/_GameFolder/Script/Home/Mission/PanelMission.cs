using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMission : BasePopup
{
    public static PanelMission Instance;
    public ItemMission itemMissionPrefab;
    public MissionDataSO missionDataSO;
    [HideInInspector] public List<ItemMission> listItemMission;
    public Transform content;

    public override void Awake()
    {
        Instance = this;
        base.Awake();
    }

    public override void Show()
    {
        base.Show();
        InitMission();
    }

    public void InitMission()
    {
        var listMissionData = missionDataSO.listMissionData;
        if (listMissionData.Count > listItemMission.Count)
        {
            while (listMissionData.Count != listItemMission.Count)
            {
                var newItem = Instantiate(itemMissionPrefab, content);
                listItemMission.Add(newItem);
            }
        }
        else
        {
            for (var index = 0; index < listItemMission.Count; index++)
            {
                listItemMission[index].gameObject.SetActive(index < missionDataSO.listMissionData.Count);
            }
        }

        for (var index = 0; index < listMissionData.Count; index++)
        {
            var missionData = listMissionData[index];
            var itemMission = listItemMission[index];
            itemMission.SetData(
                missionData.txtTitle,
                MissionFactory.CreateMission(missionData.missionType).DoMission(missionData.missionProgress)
            );
        }
    }
}
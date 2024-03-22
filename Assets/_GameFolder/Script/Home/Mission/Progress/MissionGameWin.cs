using System;

[Serializable]
public class MissionGameWin : MissionProgress
{
    public override string DoMission(int missionTarget)
    {
        var numberGameWin = PrefData.GetNumberWin();
        return $"{numberGameWin}/{missionTarget}";
    }
}
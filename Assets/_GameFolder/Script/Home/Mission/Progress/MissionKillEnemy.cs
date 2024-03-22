using System;

[Serializable]
public class MissionKillEnemy : MissionProgress
{
    public override string DoMission(int missionTarget)
    {
        var numberEnemyKilled = PrefData.GetNumberKillEnemy();
        return $"{numberEnemyKilled}/{missionTarget}";
    }
}
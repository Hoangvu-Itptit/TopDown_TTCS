public static class MissionFactory
{
    public static MissionProgress CreateMission(MissionType missionType)
    {
        return missionType switch
               {
                   MissionType.KillEnemy => new MissionKillEnemy(),
                   MissionType.GameWin   => new MissionGameWin(),
                   _                     => new MissionKillEnemy()
               };
    }
}
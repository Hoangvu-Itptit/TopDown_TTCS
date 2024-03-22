using System;

[Serializable]
public abstract class MissionProgress
{
    public abstract string DoMission(int missionTarget);
}
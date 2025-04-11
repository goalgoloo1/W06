using UnityEngine;

public class EngineRoom : RoomSystem, IRoomAction
{
    float _baseAvoidance;

    protected override void Init()
    {
        base.Init();
        RoomManager.Instance.Rooms.Add(this);
    }

    public void RoomAction()
    {
        float additionalAvoidance = 0;
        foreach(Crew crew in CrewsInRoom)
        {
            additionalAvoidance += crew.GetCrewStat(2);
        }
        GameManager.Truck.SetMissChance(_baseAvoidance + additionalAvoidance);
    }

    public void CrewLevelUp()
    {
        if(GameManager.Instance.CurrentState == State.Combat)
        {
            foreach(Crew crew in CrewsInRoom)
            {
                crew.UpdateAdditionalStats(3);
            }
        }
    }
}

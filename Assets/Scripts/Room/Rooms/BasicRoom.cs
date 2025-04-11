using UnityEngine;

public class BasicRoom : RoomSystem, IRoomAction
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Init()
    {
        base.Init();
        RoomManager.Instance.Rooms.Add(this);
    }

    public void RoomAction()
    {
        if (GameManager.Instance.CurrentState == State.Combat)
        {
            Debug.Log("Doing RoomAction");
            return;
        }
        
    }

    public void crewLevelUp()
    {
        if (GameManager.Instance.CurrentState == State.Combat)
        {
            Debug.Log("Doing Crew Level Up");
            return;
        }
    }
}

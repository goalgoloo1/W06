using UnityEngine;

public class BasicRoom : RoomSystem, IRoomAction
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Init()
    {
        base.Init();
    }

    public void RoomAction()
    {
        Debug.Log("Doing RoomAction");
        return;
    }
}

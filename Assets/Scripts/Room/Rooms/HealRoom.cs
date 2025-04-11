using System.Collections;
using UnityEngine;

public class HealRoom : RoomSystem, IRoomAction
{
    bool _canHeal = true;
    Coroutine _healCo;
    [SerializeField] float _healTime;

    protected override void Init()
    {
        base.Init();
        RoomManager.Instance.Rooms.Add(this);
    }
    public void RoomAction()
    {
        if (_canHeal && CrewsInRoom.Count > 0)
        {
            _canHeal = false;
            _healCo = StartCoroutine(HealCoroutine());
        }
        
    }

    IEnumerator HealCoroutine()
    {
        foreach (Crew crew in CrewsInRoom)
        {
            Debug.Log("Ä¡·á Áß");
            crew.Heal();
        }
        yield return new WaitForSeconds(_healTime);
        _canHeal = true;
    }

    public void CrewLevelUp()
    {
        foreach(Crew crew in CrewsInRoom)
        {
            if (!crew.CheckFullHealth())
            {
                crew.UpdateAdditionalStats(2);
            }
        }
    }
}

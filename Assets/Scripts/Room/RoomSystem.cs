using System.Collections.Generic;
using UnityEngine;

public class RoomSystem : MonoBehaviour
{
    protected List<Crew> CrewsInRoom { get; private set; }
    protected bool _isDamaged;

    void Start()
    {
        CrewsInRoom = new List<Crew>();
        Init();
    }

    protected virtual void Init()
    {
        
    }

    public void AddCrew(Crew crew)
    {
        CrewsInRoom.Add(crew);
    }

    public void RemoveCrew(Crew crew)
    {
        CrewsInRoom.Remove(crew);
    }
}

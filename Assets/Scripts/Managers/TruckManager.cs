using UnityEngine;

public class TruckManager
{
    float _avoidance;
    public float Avoidance => _avoidance;
    public void Init()
    {

    }

    public void SetMissChance(float avoidChance)
    {
        _avoidance = avoidChance;
    }
}

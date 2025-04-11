using UnityEngine;

public class TruckManager
{
    int Fuel;
    float _avoidance;
    public float Avoidance => _avoidance;
    public void Init()
    {

    }

    public void SetMissChance(float avoidChance)
    {
        _avoidance = avoidChance;
    }

    public void RemoveFuel()
    {
        Fuel--;
    }
}

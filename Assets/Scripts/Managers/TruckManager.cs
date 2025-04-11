using UnityEngine;

public class TruckManager
{
    [SerializeField] float _maxHP;
    float _currHP;
    public void Init()
    {
        _currHP = _maxHP;
    }
    public void GetDamage(int _damage)
    {
        _currHP -= _damage;
    }
}

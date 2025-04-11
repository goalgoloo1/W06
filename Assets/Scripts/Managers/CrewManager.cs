using System.Collections.Generic;
using UnityEngine;

public class CrewManager
{
    List<int> _CrewIDClassA;
    List<int> _CrewIDClassB;
    List<int> _CrewIDClassC;
    List<int> _CrewListTruck;

    int _CrewPoolSizeClassA = 2;
    int _CrewPoolSizeClassB = 4;
    int _CrewPoolSizeClassC = 10;
    public void Init()
    {
        Start();
    }
    void Start()
    {
        List<int> _CrewIDClassA = new List<int>();
        List<int> _CrewIDClassB = new List<int>();
        List<int> _CrewIDClassC = new List<int>();
        List<int> _CrewListTruck = new List<int>();

        CrewListReset();

    }
    public int 
    void CrewListReset()
    {
        _CrewIDClassA.Clear();
        _CrewIDClassB.Clear();
        _CrewIDClassC.Clear();
        _CrewListTruck.Clear();

        for (int i = 1 + 0; i <= _CrewPoolSizeClassA; i++)
        {
            _CrewIDClassA.Add(i);
        }
        for (int i = 1 + _CrewPoolSizeClassA; i <= _CrewPoolSizeClassA + _CrewPoolSizeClassB; i++)
        {
            _CrewIDClassB.Add(i);
        }
        for (int i = 1 + _CrewPoolSizeClassA + _CrewPoolSizeClassB; i <= _CrewPoolSizeClassA + _CrewPoolSizeClassB + _CrewPoolSizeClassC; i++)
        {
            _CrewIDClassC.Add(i);
        }
    }
    int ChoiceClass()
    {
        float _rand = Random.Range(0f, 100f); // 0 이상 100 미만의 난수 생성
        int _class;

        if (_rand < 10f)
        {
            _class = 0;
        }
        else if (_rand < 35f)
        {
            _class = 1;
        }
        else
        {
            _class = 2;
        }

        switch (_class)
        {
            case 0:
                if (_CrewIDClassA.Count == 0) { return ChoiceClass(); }
                return ChoiceCrew(_CrewIDClassA);
            case 1:
                if (_CrewIDClassB.Count == 0) { return ChoiceClass(); }
                return ChoiceCrew(_CrewIDClassB);
            case 2:
                if (_CrewIDClassC.Count == 0) { return ChoiceClass(); }
                return ChoiceCrew(_CrewIDClassC);
            default:
                throw new System.Exception("Invalid crew class selected.");
        }
    }
    int ChoiceCrew(List<int> _class) 
    {
        return Random.Range(0, _class.Count);
    }
    public void ExileCrew()
    {

    }
    public void ChangeCrew()
    {

    }

}

using System.Collections.Generic;
using UnityEngine;

public class CrewManager
{
    [SerializeField] int maxCrewCount = 6;

    List<CrewSO> _CrewClassAPool;
    List<CrewSO> _CrewClassBPool;
    List<CrewSO> _CrewClassCPool;

    List<CrewSO> _CrewListTruck;
    public void Init()
    {
        Start();
    }
    void Start()
    {
        _CrewClassAPool = new List<CrewSO>();
        _CrewClassBPool = new List<CrewSO>();
        _CrewClassCPool = new List<CrewSO>();
        _CrewListTruck = new List<CrewSO>();
        CrewListReset();
    }
    void CrewListReset()
    {
        _CrewClassAPool.Clear();
        _CrewClassBPool.Clear();
        _CrewClassCPool.Clear();
        _CrewListTruck.Clear();
        _CrewClassAPool = GameManager.Data.GetAllCrewInfoByRank(CrewRank.A);
        _CrewClassBPool = GameManager.Data.GetAllCrewInfoByRank(CrewRank.B);
        _CrewClassCPool = GameManager.Data.GetAllCrewInfoByRank(CrewRank.C);
    }
    public CrewSO ShowCrew() //���� ũ�� �����ֱ�
    {
        return ChoiceClass();
    }
    public bool TakeCrew(CrewSO _takeCrew) // ũ�� ����
    {
        if (_CrewListTruck.Count >= maxCrewCount) return false;
        _CrewListTruck.Add(_takeCrew);
        return true;
    }
    CrewSO ChoiceClass()
    {
        float _rand = Random.Range(0f, 100f); // 0 �̻� 100 �̸��� ���� ����
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
                if (_CrewClassAPool.Count == 0) { return ChoiceClass(); }
                return ChoiceCrew(_CrewClassAPool);
            case 1:
                if (_CrewClassBPool.Count == 0) { return ChoiceClass(); }
                return ChoiceCrew(_CrewClassBPool);
            case 2:
                if (_CrewClassCPool.Count == 0) { return ChoiceClass(); }
                return ChoiceCrew(_CrewClassCPool);
            default:
                throw new System.Exception("Invalid crew class selected.");
        }
    }
    CrewSO ChoiceCrew(List<CrewSO> _class)
    {
        return _class[Random.Range(0, _class.Count)];
    }

    public void ExileCrew(CrewSO _exileCrew) // ũ�� ����
    {
        _CrewListTruck.Remove(_exileCrew);
        AddCrewInClassList(_exileCrew);
        Debug.LogError("ExileCrew(CrewSO) -> not Contain TruckList");
    }
    void AddCrewInClassList(CrewSO _crew)
    {
        switch (_crew.Rank)
        {
            case CrewRank.A:
                _CrewClassAPool.Add(_crew);
                break;
            case CrewRank.B:
                _CrewClassBPool.Add(_crew);
                break;
            case CrewRank.C:
                _CrewClassCPool.Add(_crew);
                break;
        }
    }
    /// <summary>
    /// _takeCrew���� ShowCrew()���� ������ ���� �Ҵ��� ��
    /// </summary>
    /// <param name="_takeCrew"></param>
    /// <param name="_exileCrew"></param>
    public void ChangeCrew(CrewSO _takeCrew, CrewSO _exileCrew) // ũ�� ��ü
    {
        ExileCrew(_exileCrew);
        _CrewListTruck.Add(_takeCrew);
    }
    public void DeadCrew(CrewSO _deadCrew) // ũ�� ���
    {
        if (!_CrewListTruck.Contains(_deadCrew))
        {
            Debug.LogError("DeadCrew(CrewSO) -> not Contain TruckList");
        }
        _CrewListTruck.Remove(_deadCrew);
    }
}

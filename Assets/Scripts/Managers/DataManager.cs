using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public Dictionary<string, CrewSO> crewData = new Dictionary<string, CrewSO>();
    public Dictionary<string, bool> crewIsAlive = new Dictionary<string, bool>();

    public void Init()
    {
        LoadAllCrewData();
    }

    private void LoadAllCrewData()
    {
        var crewSOArray = Resources.LoadAll<CrewSO>("Crew");

        foreach (var crew in crewSOArray)
        {
            var key = crew.name; // ���� �̸� �״�� key ���
            if (!crewData.ContainsKey(key))
            {
                crewData.Add(key, crew);
                crewIsAlive.Add(key, true);
            }
        }
        Debug.Log($"�� {crewData.Count}���� ũ�� �����͸� �ҷ��Խ��ϴ�.");
    }

    public CrewSO GetCrewInfo(string crewCode)
    {
        if (crewData.TryGetValue(crewCode, out var crew))
        {
            if (!crewIsAlive[crewCode])
            {
                Debug.Log("�� ũ��� �̹� ���� ���Դϴ�...");
                return null;
            }
            return crew;
        }
        else
        {
            Debug.LogWarning($"[{crewCode}]�� �ش��ϴ� ũ�� �����͸� ã�� �� �����ϴ�.");
            return null;
        }
    }
}

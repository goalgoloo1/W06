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
            var key = crew.name; // 파일 이름 그대로 key 사용
            if (!crewData.ContainsKey(key))
            {
                crewData.Add(key, crew);
                crewIsAlive.Add(key, true);
            }
        }
        Debug.Log($"총 {crewData.Count}개의 크루 데이터를 불러왔습니다.");
    }

    public CrewSO GetCrewInfo(string crewCode)
    {
        if (crewData.TryGetValue(crewCode, out var crew))
        {
            if (!crewIsAlive[crewCode])
            {
                Debug.Log("그 크루는 이미 죽은 자입니다...");
                return null;
            }
            return crew;
        }
        else
        {
            Debug.LogWarning($"[{crewCode}]에 해당하는 크루 데이터를 찾을 수 없습니다.");
            return null;
        }
    }
}

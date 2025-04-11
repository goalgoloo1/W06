using UnityEngine;
using UnityEngine.UI;


public class MapManager
{
    private GameObject _canvas;
    public void Init()
    {
        _canvas = GameObject.Find("Canvas");
    }

    public void ExecuteGameEvents()
    {
        string[] events = { "전투이벤트 실행!", "수리이벤트 실행", "연료이벤트 실행!" };
        int randomIndex = Random.Range(0, events.Length);
        Debug.Log(events[randomIndex]);
        _canvas.SetActive(false);
    }
}

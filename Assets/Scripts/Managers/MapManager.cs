using UnityEngine;


//HS: TEMP Mono, I'll remove this later
public class MapManager : MonoBehaviour  
{
    [SerializeField] private GameObject canvasGameObject; 

    public void Init()
    {
    }

    void Update()
    {
        //HS: TEMP Click, I'll remove this later and use action handler

        if (Input.GetMouseButtonDown(0)) // 0 is for left mouse button
        {
            if (canvasGameObject != null)
            {
                canvasGameObject.SetActive(false); // Deactivate the Canvas GameObject
            }
            else
            {
                Debug.LogWarning("Canvas GameObject is not assigned in the MapManager.");
            }
        }
    }
}

using UnityEngine;

public class EventTester : MonoBehaviour
{
    public FuelEvent fuelEvent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fuelEvent = gameObject.GetComponent<FuelEvent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            fuelEvent.ShowEventCanvas();
        }
    }
}

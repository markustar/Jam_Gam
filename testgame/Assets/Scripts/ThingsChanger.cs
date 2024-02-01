using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingsChanger : MonoBehaviour
{
    public static ThingsChanger Instance { get; private set; }
    public List<GameObject> things;
    private int currenThingIndex = 0;
    public bool candleIsActive = false;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        SwitchThing(currenThingIndex);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchThing(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchThing(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchThing(2);
        }
    }

    void SwitchThing(int newIndex)
    {
        if(things[newIndex].gameObject.CompareTag("Candle"))
        {
            candleIsActive = true;
        }

        else
        {
            candleIsActive = false;
        }
        
        things[currenThingIndex].SetActive(false);

        things[newIndex].SetActive(true);

        currenThingIndex = newIndex;
    }
}

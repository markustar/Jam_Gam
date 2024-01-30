using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingsChanger : MonoBehaviour
{
    public List<GameObject> things;
    private int currenThingIndex = 0;

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
    }

    void SwitchThing(int newIndex)
    {
        
        things[currenThingIndex].SetActive(false);

        things[newIndex].SetActive(true);

        currenThingIndex = newIndex;
    }
}

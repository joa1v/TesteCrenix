using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearsManager : MonoBehaviour
{
    public GameObject[] gears;
    public int gearsPlacedCount;

    private void Update()
    {
        if (gearsPlacedCount == gears.Length)
        {
            Spin();
            GetComponent<NuggetText>().TaskCompletedTXT();
        }
        else if (gearsPlacedCount != gears.Length)
        {
            StopSpin();
            GetComponent<NuggetText>().DefaulTXT();

        }
    }

    public void ResetPos()
    {
        for (int i = 0; i < gears.Length; i++)
        {
            gears[i].GetComponent<GearScript>().ResetPos();
        }
    }
    public void Spin()
    {
        for (int i = 0; i < gears.Length; i++)
        {
            gears[i].GetComponent<GearScript>().StartSpin();

        }
    }

    public void StopSpin()
    {
        for (int i = 0; i < gears.Length; i++)
        {
            gears[i].GetComponent<GearScript>().StopSpin();
        }
    }
}

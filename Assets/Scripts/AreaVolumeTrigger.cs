using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaVolumeTrigger : MonoBehaviour
{
    public int areaId;


    private void OnTriggerEnter(Collider other)
    {
        var beings = FindObjectsOfType<MusicalBeing>();
        foreach (var being in beings)
        {
            if (being.areaId == areaId)
            {
                being.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var beings = FindObjectsOfType<MusicalBeing>();
        foreach (var being in beings)
        {
            if (being.areaId == areaId)
            {
                being.enabled = false;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AreaVolumeTrigger : MonoBehaviour
{
    public int areaId;

    public UnityEvent OnEnter;
    public UnityEvent OnExit;


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
        OnEnter.Invoke();
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
        OnExit.Invoke();
    }
}

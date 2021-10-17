using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Use physics layers to limit collisions and manage what goes into the inTrigger list.
/// </summary>
public class PlayerInteractionTrigger : MonoBehaviour
{
    public string objectNameFilter = "";
    public List<GameObject> inTrigger = new List<GameObject>();

    private Hud hud;

    public void SetObjectNameFilter(string gameObjectName)
    {
        objectNameFilter = gameObjectName;
    }

    private void Start()
    {
        hud = FindObjectOfType<Hud>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (string.IsNullOrEmpty(objectNameFilter) || objectNameFilter == other.gameObject.name )
            inTrigger.Add(other.gameObject);

        UpdateHud();
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger.Remove(other.gameObject);
        UpdateHud();
    }

    public void UpdateHud()
    {
        if (inTrigger.Count > 0)
        {
            hud.ShowInteractionText(inTrigger[0].name);
        }
        else
        {
            hud.ShowInteractionText("");
        }
    }

    public void RemoveFromTrigger(GameObject gameObject)
    {
        inTrigger.Remove(gameObject);
        UpdateHud();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Use physics layers to limit collisions and manage what goes into the inTrigger list.
/// </summary>
public class PlayerInteractionTrigger : MonoBehaviour
{
    public List<GameObject> inTrigger = new List<GameObject>();

    private Hud hud;

    private void Start()
    {
        hud = FindObjectOfType<Hud>();
    }

    private void OnTriggerEnter(Collider other)
    {
        inTrigger.Add(other.gameObject);

        hud.ShowInteractionText(inTrigger[0].name);
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger.Remove(other.gameObject);
        if (inTrigger.Count > 0)
        {
            hud.ShowInteractionText(inTrigger[0].name);
        }
        else
        {
            hud.ShowInteractionText("");
        }
    }
}

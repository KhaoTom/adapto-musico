using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Use physics layers to limit collisions and manage what goes into the inTrigger list.
/// </summary>
public class PlayerInteractionTrigger : MonoBehaviour
{
    public List<GameObject> inTrigger = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        inTrigger.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger.Remove(other.gameObject);
    }
}

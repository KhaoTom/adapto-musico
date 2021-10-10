using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoInfluencer : MonoBehaviour
{
    public List<Transform> inTrigger = new List<Transform>();

    public int Bpm = 90;
    public float influence = 0f;

    private SphereCollider triggerCollider;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ADD"); 

        inTrigger.Add(other.transform);
        influence = CalculateInfluence(other.transform.position);
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger.Remove(other.transform);
        if (inTrigger.Count == 0)
            influence = 0f;
    }

    private void Start()
    {
        triggerCollider = GetComponentInChildren<SphereCollider>();
    }

    private void Update()
    {
        if (inTrigger.Count == 0)
        {
            return;
        }

        influence = CalculateInfluence(inTrigger[0].position);
    }

    private float CalculateInfluence(Vector3 otherPosition)
    {
        return (triggerCollider.radius - Vector3.Distance(transform.position, otherPosition)) / triggerCollider.radius;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupItemInteractable : MonoBehaviour
{
    public string pickupName;
    public bool changeGameObjectName = false;

    public UnityEvent onPickup;


    private void Start()
    {
        if (changeGameObjectName)
            gameObject.name = pickupName;
    }


    public void DoInteraction()
    {
        onPickup.Invoke();
    }
}

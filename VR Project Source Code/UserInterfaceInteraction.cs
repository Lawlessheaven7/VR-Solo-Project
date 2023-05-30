using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UserInterfaceInteraction : MonoBehaviour
{
    public UnityEvent onHitByRaycast;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("start");
        onHitByRaycast.Invoke();
    }
}


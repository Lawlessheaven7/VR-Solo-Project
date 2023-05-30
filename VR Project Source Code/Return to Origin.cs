using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ReturntoOrigin : MonoBehaviour
{
    private Pose originPose;
    private XRGrabInteractable grabInteractable;
    // Start is called before the first frame update

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        originPose.position = transform.position;
        originPose.rotation = transform.rotation;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        grabInteractable.selectExited.AddListener(WeaponReleased);
    }

    private void OnDisable()
    {
        grabInteractable.selectExited.RemoveListener(WeaponReleased);
    }

    private void WeaponReleased(SelectExitEventArgs arg0)
    {
        transform.position = originPose.position;
        transform.rotation = originPose.rotation;
    }
}

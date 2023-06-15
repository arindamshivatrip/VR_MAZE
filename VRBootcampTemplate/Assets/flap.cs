using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class flap : MonoBehaviour
{
    Rigidbody rb;

    public GameObject leftController;
    Vector3 lastLeftPosition;
    public GameObject rightController;
    Vector3 lastRightPosition;
    public GameObject cam;

    float totalLDiff;
    float lDiff;
    float totalRDiff;
    float rDiff;

    bool isFlappingL;
    bool isFlappingR;
    const float threshold = 0.04f;

    private List<UnityEngine.XR.InputDevice> controllers;
    const float groundHeight = 0.0f;
    const float hoverHeight = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controllers = new List<UnityEngine.XR.InputDevice>();
        controllers.Add(UnityEngine.XR.InputDevices.GetDeviceAtXRNode(UnityEngine.XR.XRNode.LeftHand));
        controllers.Add(UnityEngine.XR.InputDevices.GetDeviceAtXRNode(UnityEngine.XR.XRNode.RightHand));
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var controller in controllers)
        {
            if (controller.isValid && controller.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out bool isPressed))
            {
                if (!isPressed)
                {
                    transform.position = new Vector3(transform.position.x, groundHeight, transform.position.z);
                    isFlappingL = false;
                    isFlappingR = false;
                    totalLDiff = 0;
                    totalRDiff = 0;
                    return;
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, hoverHeight, transform.position.z);
                }
            }
        }

        lDiff = leftController.transform.localPosition.y - lastLeftPosition.y;
        rDiff = rightController.transform.localPosition.y - lastRightPosition.y;

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 120);
        if (isFlappingL && isFlappingR)
        {
            if (lDiff > 0 && rDiff > 0 && Mathf.Abs(totalLDiff) > threshold && Mathf.Abs(totalRDiff) > threshold)
            {
                Vector3 line = (leftController.transform.position - rightController.transform.position).normalized;
                Vector3 force = new Vector3(-line.z, 0, line.x);
      
                rb.AddForce(force * -4000);
                isFlappingL = false;
                isFlappingR = false;
                totalLDiff = 0;
                totalRDiff = 0;
            }
            else if (lDiff < 0 && rDiff < 0)
            {
                totalLDiff += lDiff;
                totalRDiff += rDiff;
            }
        }
        else if (lDiff < 0)
            {
                isFlappingL = true;
            isFlappingR = true;
            totalLDiff += lDiff;
            totalRDiff += rDiff;
        }

        lastLeftPosition = leftController.transform.localPosition;
        lastRightPosition = rightController.transform.localPosition;
    }

}

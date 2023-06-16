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
                    isFlappingL = false;
                    isFlappingR = false;
                    totalLDiff = 0;
                    totalRDiff = 0;
                    return;
                }
            }
        }

        lDiff = leftController.transform.localPosition.y - lastLeftPosition.y;
        rDiff = rightController.transform.localPosition.y - lastRightPosition.y;

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 60);
        if (isFlappingL && isFlappingR)
        {
            if (lDiff > 0 && rDiff > 0 && Mathf.Abs(totalLDiff) > threshold && Mathf.Abs(totalRDiff) > threshold)
            {
                //Vector3 line = (leftController.transform.position - rightController.transform.position);
                //Vector3 force = new Vector3(-line.z, 0, line.x).normalized;
                Vector3 force = cam.transform.forward;

                rb.AddForce(force * 2000);
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
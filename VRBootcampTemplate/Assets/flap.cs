using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class flap : MonoBehaviour
{
    Rigidbody rb;
    public GameObject cam;
    public GameObject leftController;
    Vector3 lastLeftPosition;
    public GameObject rightController;
    Vector3 lastRightPosition;

    float totalLDiff;
    float lDiff;
    float totalRDiff;
    float rDiff;

    bool isFlappingL;
    bool isFlappingR;
    const float threshold = 0.04f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isFlappingL = true;
        isFlappingR = true;
        totalLDiff = 0;
        totalRDiff = 0;

        lDiff = leftController.transform.localPosition.y - lastLeftPosition.y;
        rDiff = rightController.transform.localPosition.y - lastRightPosition.y;

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 30);
        if (isFlappingL && isFlappingR)
        {
            Debug.Log(lDiff + " " + rDiff);
            if (lDiff > 0 && rDiff > 0)
            {
                rb.AddForce(cam.transform.forward * 500);
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

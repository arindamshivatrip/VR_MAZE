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

    float totalDiff;


    bool isFlapping;
    float threshold;

    float timeElapsed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if isFlapping = true
            // if diff +ve && totalDiff > threshold
                // move forward
                // isFlapping = false
                // totalDiff = 0
            // else if diff -ve
                // totalDiff += diff
        // else isFlapping = false
            // if diff -ve
                // isFlapping = true
                // totalDiff += diff

        float diff = leftController.transform.localPosition.y - lastLeftPosition.y;
        
        if(isFlapping)
        {
            if(diff > 0 && totalDiff > threshold)
            {

            }
        }

        lastLeftPosition = leftController.transform.localPosition;
    }
}

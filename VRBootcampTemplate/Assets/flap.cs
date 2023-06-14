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

    float timeElapsed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    

    // Update is called once per frame
    void Update()
    {

        lDiff = leftController.transform.localPosition.y - lastLeftPosition.y;
        rDiff = rightController.transform.localPosition.y - lastRightPosition.y;



        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 120);
        if (isFlappingL && isFlappingR)
        {
            if (lDiff > 0 && rDiff > 0 && Mathf.Abs(totalLDiff) > threshold && Mathf.Abs(totalRDiff) > threshold)
            {
                Vector3 line = (leftController.transform.position - rightController.transform.position).normalized;
                Vector3 force = new Vector3(-1 * line.z, 0, line.x);
      
                rb.AddForce(force * -400);
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

    private void OnGUI()
    {
        GUILayout.Button(lDiff.ToString());
        GUILayout.Button(totalLDiff.ToString());
    }
}

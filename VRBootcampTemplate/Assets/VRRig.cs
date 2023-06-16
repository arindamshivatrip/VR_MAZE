using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VRMap
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPosOffset;
    public Vector3 trackingRotOffset;

    public void map()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPosOffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotOffset);
    }
}

public class VRRig : MonoBehaviour
{
    public Transform headConstraint;
    private Vector3 headBodyOffset;

    // public Transform leftTarget;
    // public Transform rightTarget;

    public VRMap head;
    // public VRMap leftHand;
    // public VRMap rightHand;

    // Start is called before the first frame update
    void Start()
    {
        headBodyOffset = transform.position - headConstraint.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = headConstraint.position + headBodyOffset;
        // transform.forward = - Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized;
       
        // Vector3 line = leftTarget.position - rightTarget.position;
        // transform.forward = new Vector3(-line.z, 0, line.x).normalized;

        head.map();
        // leftHand.map();
        // rightHand.map();
    }
}

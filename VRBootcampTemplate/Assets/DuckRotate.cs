using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckRotate : MonoBehaviour
{
    public GameObject cam;
    

    // Update is called once per frame
    void Update()
    {
        transform.rotation = cam.transform.rotation;
    }
}

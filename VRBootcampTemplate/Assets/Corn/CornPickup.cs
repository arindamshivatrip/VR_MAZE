using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornPickup : MonoBehaviour
{
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Destroy(gameObject);
    }
}

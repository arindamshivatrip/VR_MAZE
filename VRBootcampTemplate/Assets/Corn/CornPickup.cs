using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CornPickup : MonoBehaviour
{

    AudioSource audioData;
    private void Start()
    {
        audioData = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        
        audioData.Play(0);
        Destroy(gameObject);
    }
}

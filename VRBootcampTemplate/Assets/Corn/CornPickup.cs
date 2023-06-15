using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.XR.PXR;


[RequireComponent(typeof(AudioSource))]
public class CornPickup : MonoBehaviour
{
    public PlayerStats stats;
    AudioSource audioData;
    
    public int vibrationDuration = 1000;
    public float vibrationIntensity = 1.0f;

    private void Start()
    {
        audioData = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        stats.cornsCollected++;
        audioData.Play();
        PXR_Input.SendHapticImpulse(PXR_Input.VibrateType.BothController,
            vibrationIntensity, vibrationDuration);
        Destroy(other.gameObject);
    }
}

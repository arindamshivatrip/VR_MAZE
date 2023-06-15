using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(AudioSource))]
public class CornPickup : MonoBehaviour
{
    public PlayerStats stats;
    AudioSource audioData;
    private void Start()
    {
        audioData = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        stats.cornsCollected++;
        audioData.Play();
        Destroy(other.gameObject);
    }
}

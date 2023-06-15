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
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        stats.cornsCollected++;
        audioData.Play(0);
        Destroy(gameObject);
    }
}

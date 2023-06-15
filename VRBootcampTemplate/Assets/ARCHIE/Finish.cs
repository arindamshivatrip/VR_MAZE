using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    AudioSource audioData;
    public UnityEngine.UI.Text timer;
    float timeElapsed = 0f;
    bool won = false;
    public int vibrationDuration = 10000;
    public float vibrationIntensity = 1.0f;
    private void Start()
    {
        audioData = GetComponent<AudioSource>();
    }
    private void Update()
    {
        timer.text = "You took " + timeElapsed.ToString() + " seconds!";
        if(!won)
        {

            timeElapsed += Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Unity.XR.PXR.PXR_Input.SendHapticImpulse(Unity.XR.PXR.PXR_Input.VibrateType.BothController,
                vibrationIntensity, vibrationDuration);
        won = true;
        audioData.Play();
    }
}

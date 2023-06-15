using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    AudioSource audioData;
    public UnityEngine.UI.Text timer;
    float timeElapsed = -5f;
    bool won = false;
    private void Start()
    {
        audioData = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(won)
        {

            timer.text = "You took " + timeElapsed.ToString() + " seconds!";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        timeElapsed += Time.deltaTime;
        won = true;
        audioData.Play();
    }
}

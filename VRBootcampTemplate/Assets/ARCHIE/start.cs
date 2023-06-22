using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    public PlayerStats stats;
    private void OnTriggerExit(Collider other)
    {
        stats.timeElapsed = 0;
    }
}

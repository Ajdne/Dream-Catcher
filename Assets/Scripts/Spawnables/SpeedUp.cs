using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DoubleSpeed());
        }
    }
    IEnumerator DoubleSpeed()
    {
        Time.timeScale += 1;
        yield return new WaitForSecondsRealtime(5);
        Time.timeScale -= 1;
    }
}

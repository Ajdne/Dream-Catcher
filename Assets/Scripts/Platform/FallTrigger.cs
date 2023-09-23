using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventManager.StartCamera();
            int rand = Random.Range(1, 7);
            EventManager.StartEnvironmentTransformEvent(rand);
        }
    }
}

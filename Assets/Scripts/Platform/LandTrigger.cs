using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventManager.StartCamera();
            EventManager.StartTransformPlayer(LevelGenerator.GameEnvironment);
        }
    }
}

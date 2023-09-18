using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LevelGenerator.gameSpeed += 3;
            ObjectPoolManager.ReturnObject(gameObject);
        }
    }
}

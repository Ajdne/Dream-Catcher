using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public static int MultiplierCounter = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && MultiplierCounter < 3)
        {
            LevelGenerator.gameSpeed *= 1.3f;
            MultiplierCounter++;
        }
        Player.Instance.Score += 2;
        ObjectPoolManager.ReturnObject(gameObject);
    }
}

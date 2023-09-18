using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Player.Instance.Health <= 2)
            {
                Player.Instance.Health += 1;
            }
            ObjectPoolManager.ReturnObject(gameObject);
        }
    }
}

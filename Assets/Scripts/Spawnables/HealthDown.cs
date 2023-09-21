using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDown : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Player.Instance.Health >= 1)
            {
                CameraMotor.Instance.CameraShake();
                Player.Instance.Health -= 1;
            }
            ObjectPoolManager.ReturnObject(gameObject);
        }
    }
}

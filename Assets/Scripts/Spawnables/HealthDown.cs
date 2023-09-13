using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDown : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Player.Instance.Health -= 1;
            gameObject.SetActive(false);
        }
    }
}

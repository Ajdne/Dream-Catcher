using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Player.Instance.Score += 1;
            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private EnvironmentMover environmentMover;
    private void Awake()
    {
        environmentMover = GetComponent<EnvironmentMover>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // startuje event transformers prosledjuje tip environmenta
            // ako je od 1 do 6 startuje mover'
            // ako je 7 nista
        }
    }
}

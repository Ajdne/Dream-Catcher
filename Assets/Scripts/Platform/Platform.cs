using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Kada player pipne triger
        if (other.CompareTag("Player"))
        {
            // ako nije nebo promeni u nebo
            if(LevelGenerator.GameEnvironment != 7)
            {
                // startuje event transformers prosledjuje tip environmenta
                EventManager.StartEnvironmentTransformEvent(7);
                //gameObject.SetActive(false);

            }
            else//ako je nebo promeni u random pod
            {
                // startuje event transformers prosledjuje tip environmenta
                int rand = Random.Range(1, 7);
                EventManager.StartEnvironmentTransformEvent(rand);
            }
        }
    }
}

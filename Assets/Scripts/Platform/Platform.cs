using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private EnvironmentMover environmentMover;
    private EnvironmentMoverUp environmentMoverUp;
    private void Awake()
    {
        environmentMover = GetComponent<EnvironmentMover>();
        environmentMoverUp = GetComponent<EnvironmentMoverUp>();
    }
    private void Start()
    {
        if(ChangeEnviroment.GameEnviroment == 7)
        {
            environmentMoverUp.enabled = true;
            environmentMover.enabled = false;
        }
        else
        {
            environmentMoverUp.enabled = false;
            environmentMover.enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        //Kada player pipne triger
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigerovano");
            // ako nije nebo promeni u nebo
            if(ChangeEnviroment.GameEnviroment != 7)
            {
                // startuje event transformers prosledjuje tip environmenta
                EventManager.StartEnvironmentTransformEvent(7);
                //gameObject.SetActive(false);
                environmentMover.enabled = true;
                environmentMoverUp.enabled = false;

            }
            else//ako je nebo promeni u random pod
            {
                // startuje event transformers prosledjuje tip environmenta
                int rand = Random.Range(1, 7);
                EventManager.StartEnvironmentTransformEvent(rand);
                environmentMoverUp.enabled = true;
                environmentMover.enabled = false;
            }
        }
    }
}

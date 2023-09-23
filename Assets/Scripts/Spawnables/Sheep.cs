using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    [SerializeField]
    private bool HealthUp;
    [SerializeField]
    private bool SpeedUp;
    [SerializeField]
    private bool ScoreUp;
    private int Id;
    // Start is called before the first frame update
    private void Start()
    {
        if (ScoreUp) Id = 1;
        if (HealthUp) Id = 2;
        if (SpeedUp) Id = 3;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventManager.StartSheep(Id);
            ObjectPoolManager.ReturnObject(gameObject);
        }
    }
}

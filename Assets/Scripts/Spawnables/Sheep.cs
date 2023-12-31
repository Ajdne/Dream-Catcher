using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    [SerializeField]
    private GameObject Smoke;
    [SerializeField]
    private GameObject Land;
    [SerializeField]
    private GameObject Water;
    [SerializeField]
    private GameObject Sky;
    [SerializeField]
    private bool HealthUp;
    [SerializeField]
    private bool SpeedUp;
    [SerializeField]
    private bool ScoreUp;
    private int Id;
    // Start is called before the first frame update
    private void OnEnable()
    {
        TransformSheep();
    }
    private void OnDisable()
    {
        ClearSheep();
    }
    private void TransformSheep()
    {
        switch (LevelGenerator.GameEnvironment)
        {
            case 4:
                Water.SetActive(true);
                break;
            case 5:
                Sky.SetActive(true);
                break;
            default:
                Land.SetActive(true);
                break;
        }
    }
    private void ClearSheep()
    {
        Water.SetActive(false);
        Sky.SetActive(false);
        Land.SetActive(false);
    }
    private void Start()
    {
        if (ScoreUp)
        {
            Id = 1;
        }
        else if (HealthUp)
        {
            Id = 2;
        }
        else if (SpeedUp)
        {
            Id = 3;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ClearSheep();
            Smoke.SetActive(true);
            EventManager.StartSheep(Id);
            StartCoroutine(Return());
        }
    }
    IEnumerator Return()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        ObjectPoolManager.ReturnObject(gameObject);
    }
}

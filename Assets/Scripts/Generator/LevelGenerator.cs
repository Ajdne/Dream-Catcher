using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance;
    [SerializeField]
    private List<GameObject> spawnableObjects = new List<GameObject>();
    [SerializeField]
    private List<Vector3> spawnPositions = new List<Vector3>();

    public static float gameSpeed;
    public ObjectPooler theObjectPool;
    public bool spawn;
    public bool IsAlive;
    private Vector3 startPos = new(0f, -0.5f, 450f);

    public static int EnvironmentCounter;

    IEnumerator EnvironmentGenerator()
    {
        // stvara platforme, kad dobije znak stvara na platformi transition objekat
        // znak za transition objekat je broj na sa countera,
        // counter moze da bude broj koji ce da se povecava nakon svake platforme ili samo time brojac
        // transition objekat poziva funkciju koja ima dve opcije
        // 
        while (IsAlive)
        {
            yield return null;
            if (spawn)
            {
                GameObject spawnedObject = theObjectPool.GetPooledObject();

                spawnedObject.transform.position = startPos;
                spawnedObject.transform.rotation = Quaternion.identity;
                spawnedObject.SetActive(true);
                spawn = false;
                EnvironmentCounter++;
            }
        }
    }


    IEnumerator SpawnablesGenerator()
    {
        while(IsAlive)
        {
            int rand2;
            if (ChangeEnviroment.GameEnviroment == 1)
            {
                rand2 = Random.Range(0, 3);
            }
            else
            {
                rand2 = Random.Range(3, spawnPositions.Count);
            }
            int rand = Random.Range(0, spawnableObjects.Count);
            Instantiate(spawnableObjects[rand], spawnPositions[rand2], Quaternion.Euler(0,180f,0));
            yield return new WaitForSecondsRealtime(3);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Environment"))
        {
            spawn = true;
        }
    }
    private void Awake()
    {
        Instance = this;
        gameSpeed = 7f;
        spawn = false;
        IsAlive = false;
    }
    public void StartGame()
    {
        IsAlive = true;
        StartCoroutine(EnvironmentGenerator());
        StartCoroutine(SpawnablesGenerator());
        StartCoroutine(GameSpeedUpdate());
        StartCoroutine(ChangeEnviroment.Instance.EnvironmentController());
    }
    IEnumerator GameSpeedUpdate()
    {
        while(IsAlive)
        {
            yield return new WaitForSecondsRealtime(2);
            gameSpeed += 0.5f;
        }
    }
}

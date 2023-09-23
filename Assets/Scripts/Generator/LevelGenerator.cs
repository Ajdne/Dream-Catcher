using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance;
    [SerializeField]
    private List<GameObject> spawnableObjects = new();
    [SerializeField]
    private List<GameObject> EnvironmentPlatforms = new();

    public static float gameSpeed;
    public static int GameEnvironment;
    public bool spawn;
    public bool spawnSpawnable;
    public bool IsAlive;

    public List<float> spawnProbabilities; // Probabilities corresponding to each prefab
    public GameObject SkyBlock;

    public GameObject SelectSpawnable()
    {
        if (spawnableObjects == null || spawnProbabilities == null ||
            spawnableObjects.Count != spawnProbabilities.Count || spawnProbabilities.Count == 0)
        {
            throw new System.Exception("Invalid input for SelectSpawnable function.");
        }

        float randomValue = Random.value;
        float cumulativeProbability = 0f;

        for (int i = 0; i < spawnableObjects.Count; i++)
        {
            cumulativeProbability += spawnProbabilities[i];

            if (randomValue <= cumulativeProbability)
            {
                return spawnableObjects[i];
            }
        }

        throw new System.Exception("No spawnable object selected. Check probabilities.");
    }
    private int GetEnvironment()
   {
        return GameEnvironment switch
        {
            6 => Random.Range(0, 3),//town (jos uvek nije implementiran)
            5 => Random.Range(12, 15),//shroom
            4 => Random.Range(9, 12),//sea
            3 => Random.Range(6, 9),//polar
            2 => Random.Range(3, 6),//desert
            _ => Random.Range(0, 3),//countryside
        };
    }
    private void Awake()
    {
        Instance = this;
    }
    public static int EnvironmentCounter;
    private Vector3 startPos = new(0f, -0.2f, 450f);
    private void Start()
    {
        Time.timeScale = 1.0f;
        IsAlive = true;
        spawn = false;
        gameSpeed = 15;
        EventManager.StartEnvironmentTransformEvent(1);
        StartCoroutine(GameSpeedUpdate());
    }
    private int EnvironmentCounterLimit;
    private void Update()
    {
        // stvara platforme
        // znak za transition objekat je broj sa countera
            if (spawn)
            {
                EnvironmentCounter++;
                int rand = GetEnvironment();
                GameObject platform = ObjectPoolManager.SpawnObject(EnvironmentPlatforms[rand], startPos, Quaternion.identity);
                //platform.GetComponent<EnvironmentMoverUp>().enabled = false;
                platform.GetComponent<EnvironmentMover>().enabled = true;
                platform.GetComponent<BoxCollider>().enabled = true;
                if (EnvironmentCounter == EnvironmentCounterLimit) //ukljucuje capsule colider na platformi i gasi corutinu
                {
                    EnvironmentCounter = Random.Range(3,7);
                    platform.transform.Find("Trigger2").gameObject.SetActive(true);
                    platform.GetComponent<BoxCollider>().enabled = false;
                }
                spawn = false;
            }
    }
    private void SpawnStartPlatform()
    {
        Vector3[] pozicije = new Vector3[4];
        pozicije[0] = new(0, -200, 0);
        pozicije[1] = new(0, -200, 150);
        pozicije[2] = new(0, -200, 450);
        pozicije[3] = new(0, -200, 300);
        for (int i = 0; i < pozicije.Length; i++)
        {
            int rand = GetEnvironment();
            GameObject platform = ObjectPoolManager.SpawnObject(EnvironmentPlatforms[rand], pozicije[i], Quaternion.identity);
            platform.GetComponent<EnvironmentMoverUp>().enabled = true;
            if (i == 0)
            {
                platform.transform.Find("Trigger1").gameObject.SetActive(true);
            }
        }
        ObjectPoolManager.SpawnObject(SkyBlock, new Vector3(0, -165, 0), Quaternion.identity);
    }
    private void PlayerDeath()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        IsAlive = false;
        spawn = false;
        gameSpeed = 0f;
    }
    
    private void OnEnable()
    {
        EventManager.EnvironmentTransformEvent += EnvironemntListener;
        EventManager.PlayerDeath += PlayerDeath;
    }
    private void OnDisable()
    {
        EventManager.EnvironmentTransformEvent -= EnvironemntListener;
        EventManager.PlayerDeath -= PlayerDeath;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Environment"))
        {
            spawn = true;
        }
    }
    // slusa transformers event
    private void EnvironemntListener(int Id)
    {
        GameEnvironment = Id;
        SpawnStartPlatform();
    }
    IEnumerator GameSpeedUpdate()
    {
        while(IsAlive)
        {
            yield return new WaitForSecondsRealtime(1);
            if (gameSpeed < 100)
            {
                gameSpeed += 0.25f;
            }
        }
    }
}

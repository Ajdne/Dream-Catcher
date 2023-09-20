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

    [SerializeField]
    private List<Vector3> spawnPositions = new();
    public List<float> spawnProbabilities; // Probabilities corresponding to each prefab

    public GameObject SelectSpawnable()
    {
        if (spawnableObjects.Count != spawnProbabilities.Count || spawnProbabilities.Count == 0)
        {
            Debug.LogError("Prefab array length doesn't match spawn probabilities array length, or probabilities array is empty.");
            return null;
        }

        float randomValue = Random.value; // Generate a random value between 0 and 1
        float cumulativeProbability = 0f;

        for (int i = 0; i < spawnableObjects.Count; i++)
        {
            cumulativeProbability += spawnProbabilities[i];

            if (randomValue <= cumulativeProbability)
            {
                // Instantiate the selected prefab
                //return spawnable
                return spawnableObjects[i];
            }
        }
        return null;
    }
    IEnumerator SpawnablesGenerator()
    {
        while (IsAlive)
        {
            int rand2;
            if (GameEnvironment != 7)
            {
                rand2 = Random.Range(0, 3);
            }
            else
            {
                rand2 = Random.Range(3, spawnPositions.Count);
            }
            int rand = Random.Range(0, spawnableObjects.Count);
            ObjectPoolManager.SpawnObject(spawnableObjects[rand], spawnPositions[rand2], Quaternion.Euler(0, 180f, 0));
            yield return new WaitForSeconds(2);
        }
    }
   private int GetEnvironment()
   {
        int rand;
        switch (GameEnvironment)
        {
            case 7:
                //vazduh (bira za platforme dole)
                return rand = Random.Range(0,3);
            case 6:
                //town (jos uvek nije implementiran)
                return rand = Random.Range(0, 3);
            case 5:
                //shroom
                return rand = Random.Range(12, 15);
            case 4:
                //sea
                return rand = Random.Range(9, 12);
            case 3:
                //polar
                return rand = Random.Range(6, 9);
            case 2:
                //desert
                return rand = Random.Range(3, 6);
            default:
                //countryside
                return rand = Random.Range(0, 3);
        }
   }
    private void Awake()
    {
        Instance = this;
        spawn = false;
    }
    public static int EnvironmentCounter;
    public bool GeneratorOn;
    private Vector3 startPos = new(0f, -0.2f, 450f);
    private void Start()
    {
        gameSpeed = 15;
        IsAlive = true;
        EventManager.StartEnvironmentTransformEvent(7);
        StartCoroutine(SpawnablesGenerator());
        StartCoroutine(GameSpeedUpdate());
    }
    private void Update()
    {
        // stvara platforme
        // znak za transition objekat je broj sa countera
        if (GeneratorOn)
        {
            if (spawn)
            {
                EnvironmentCounter++;
                Debug.Log("Stvaranje broj " + EnvironmentCounter);
                int rand = GetEnvironment();
                GameObject platform = ObjectPoolManager.SpawnObject(EnvironmentPlatforms[rand], startPos, Quaternion.identity);
                //platform.GetComponent<EnvironmentMoverUp>().enabled = false;
                platform.GetComponent<EnvironmentMover>().enabled = true;
                platform.GetComponent<BoxCollider>().enabled = true;
                if (EnvironmentCounter == 4) //ukljucuje capsule colider na platformi i gasi corutinu
                {
                    EnvironmentCounter = 0;
                    platform.transform.Find("Trigger2").gameObject.SetActive(true);
                    platform.GetComponent<BoxCollider>().enabled = false;
                    GeneratorOn = false;
                }

                spawn = false;
                Debug.Log("Spawn false");
            }
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
    }
    private void PlayerDeath()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        GeneratorOn = false;
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
            Debug.Log("Spawn true");
            spawn = true;
        }
    }
    // slusa transformers event
    private void EnvironemntListener(int Id)
    {
        GameEnvironment = Id;
        // proverava koji je tip environmenta
        // od 1 do 6 ukljucuje generator
        if (Id != 7)
        {
            GeneratorOn = true;
            Debug.Log("Startuj envi gen");
            return;
        }
        else // ako je 7 iskljucuje generator i stvara veliku platformu dole
        {
            GeneratorOn = false;
            Debug.Log("Iskljuci envi gen");
            SpawnStartPlatform();
        }
    }
    IEnumerator GameSpeedUpdate()
    {
        while(IsAlive)
        {

            yield return new WaitForSecondsRealtime(1);
            if (gameSpeed < 150)
            {
                gameSpeed += 0.5f;
            }
        }
    }
}

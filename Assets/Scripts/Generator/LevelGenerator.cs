using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance;
    [SerializeField]
    private List<GameObject> spawnableObjects = new();
    [SerializeField]
    public List<GameObject> EnvironmentPlatforms = new();

    public static float gameSpeed;

    public bool spawn;
    public bool IsAlive;

    [SerializeField]
    private List<Vector3> spawnPositions = new();
    IEnumerator SpawnablesGenerator()
    {
        while(IsAlive)
        {
            int rand2;
            if (ChangeEnviroment.GameEnviroment != 7)
            {
                rand2 = Random.Range(0, 3);
            }
            else
            {
                rand2 = Random.Range(3, spawnPositions.Count);
            }
            int rand = Random.Range(0, spawnableObjects.Count);
            Instantiate(spawnableObjects[rand], spawnPositions[rand2], Quaternion.Euler(0,180f,0));
            yield return new WaitForSecondsRealtime(2);
        }
    }

    private void Awake()
    {
        Instance = this;
        gameSpeed = 25f;
        spawn = false;
        IsAlive = false;
    }
    public static int EnvironmentCounter = 0;
    public bool GeneratorOn;
    private Vector3 startPos = new(0f, -0.2f, 450f);
    private void Update()
    {
        // stvara platforme
        // znak za transition objekat je broj sa countera
        if (GeneratorOn)
        {
            if (spawn)
            {
                Debug.Log("Stvaranje broj " + EnvironmentCounter);
                GameObject platform = ObjectPoolManager.SpawnObject(EnvironmentPlatforms[0], startPos, Quaternion.identity);
                platform.GetComponent<EnvironmentMoverUp>().enabled = false;
                platform.GetComponent<EnvironmentMover>().enabled = true;

                if (EnvironmentCounter == 4) //ukljucuje capsule colider na platformi i gasi corutinu
                {
                    EnvironmentCounter = 0;
                    platform.transform.Find("Trigger2").gameObject.SetActive(true);

                    GeneratorOn = false;
                }

                spawn = false;
                Debug.Log("spawn false");
            }
        }
    }
    private void SpawnStartPlatform()
    {
        Vector3[] pozicije = new Vector3[4];
        pozicije[0] = new(0, -150, 0);
        pozicije[1] = new(0, -150, 150);
        pozicije[2] = new(0, -150, 450);
        pozicije[3] = new(0, -150, 300);
        for (int i = 0; i < pozicije.Length; i++)
        {
            GameObject platform = ObjectPoolManager.SpawnObject(EnvironmentPlatforms[0], pozicije[i], Quaternion.identity);
            platform.GetComponent<EnvironmentMoverUp>().enabled = true;
            platform.GetComponent<EnvironmentMover>().enabled = false;
            if (i == 0)
            {
                platform.transform.Find("Trigger1").gameObject.SetActive(true);
            }
        }
    }
    private void OnEnable()
    {
        EventManager.EnvironmentTransformEvent += EnvironemntListener;
    }
    private void OnDisable()
    {
        EventManager.EnvironmentTransformEvent -= EnvironemntListener;
    }
    public void StartGame()
    {
        IsAlive = true;
        StartCoroutine(SpawnablesGenerator());
        StartCoroutine(GameSpeedUpdate());
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Environment"))
        {
            Debug.Log("On trigger exit spawn true");
            spawn = true;
            EnvironmentCounter++;
        }
    }
    // slusa transformers event
    private void EnvironemntListener(int Id)
    {
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
            yield return new WaitForSecondsRealtime(2);
            gameSpeed += 0.5f;
        }
    }
}

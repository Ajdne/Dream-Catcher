using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance;
    [SerializeField]
    private List<GameObject> spawnableObjects = new();


    public static float gameSpeed;
    public ObjectPooler theObjectPool;
    public bool spawn;
    public bool IsAlive;
    private Vector3 startPos = new(0f, -0.2f, 450f);

    // slusa transformers event
    private void EnvironemntListener(int Id)
    {
        // proverava koji je tip environmenta
        // od 1 do 6 ukljucuje generator
        if (Id != 7)
        {
            StartCoroutine(EnvironmentGenerator());
            return;
        }
        else // ako je 7 iskljucuje generator i stvara veliku platformu dole
        {
            StopCoroutine(EnvironmentGenerator());
            SpawnStartPlatform();
        }
    }
    private void SpawnStartPlatform()
    {
        Vector3[] pozicije = new Vector3[4];  
        pozicije[0] = new(0, -150, 0);
        pozicije[1] = new(0, -150, 150);
        pozicije[2] = new(0, -150, 450);
        pozicije[3] = new(0, -150, 300);
        for(int i = 0; i<4; i++)
        {
            GameObject spawnedObject = theObjectPool.GetPooledObject();
            spawnedObject.transform.SetPositionAndRotation(pozicije[i], Quaternion.identity);
            spawnedObject.GetComponent<EnvironmentMoverUp>().enabled = true;
            spawnedObject.GetComponent<EnvironmentMover>().enabled = false;
            if (i == 0)
            {
                spawnedObject.GetComponent<SphereCollider>().enabled = true;
            }
            spawnedObject.SetActive(true);
        }
        EnvironmentCounter = 0;
    }
    public static int EnvironmentCounter = 0;
    IEnumerator EnvironmentGenerator()
    {
        // stvara platforme
        // znak za transition objekat je broj sa countera
        while (IsAlive)
        {
            yield return null;
            if (spawn)
            {

                GameObject spawnedObject = theObjectPool.GetPooledObject();
                spawnedObject.transform.SetPositionAndRotation(startPos, Quaternion.identity);
                spawnedObject.SetActive(true);

                if (EnvironmentCounter >= 4) //ukljucuje capsule colider na platformi i gasi corutinu
                {
                    spawnedObject.GetComponent<CapsuleCollider>().enabled = true;
                    spawnedObject.GetComponent<BoxCollider>().enabled = false;
                    spawn = false;
                    StopCoroutine(EnvironmentGenerator());
                }
                EnvironmentCounter++;
                spawn = false;
            }
        }
    }

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
        gameSpeed = 25f;
        spawn = false;
        IsAlive = false;
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
        //StartCoroutine(EnvironmentGenerator());
        StartCoroutine(SpawnablesGenerator());
        StartCoroutine(GameSpeedUpdate());
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

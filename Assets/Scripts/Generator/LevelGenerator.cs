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

    IEnumerator EnvironmentGenerator()
    {
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
                numb++;
            }
        }
    }

    private int numb;
    public bool isVertical;

    IEnumerator EnvironmentController()
    {
        while (IsAlive)
        {
            if (numb >= 5) 
            {
                numb = 0;
                if (isVertical)
                {
                    ChangeEnviroment.Instance.ChangeEnvironmentFunction(7);
                    isVertical = false;
                }
                else
                {
                    int rand = Random.Range(1, 7);
                    ChangeEnviroment.Instance.ChangeEnvironmentFunction(rand);
                    isVertical = true;
                }
            }
            yield return null;
        }
        // promeni se jedan horizontalan
        // promeni na novi envi (numb)
        // 5 ciklusa spawna se ceka
        // promeni se u nebo
        // promeni na novi envi (numb)
        // neki time u nebu

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
            other.GetComponent<BoxCollider>().enabled = false;
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
        StartCoroutine(EnvironmentController());
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

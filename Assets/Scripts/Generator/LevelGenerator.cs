using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance;
    [SerializeField]
    private List<GameObject> spawnableObjects = new List<GameObject>();
    [SerializeField]
    private List<GameObject> environmentObjects = new List<GameObject>();
    [SerializeField]
    private List<Vector3> spawnPositions = new List<Vector3>();

    public static float gameSpeed;
    public ObjectPooler theObjectPool;
    public bool spawn;
    private Vector3 startPos = new(0f, -0.5f, 450f);
    IEnumerator Generator()
    {
        while (true)
        {
            yield return null;
            if (spawn)
            {
                GameObject spawnedObject = theObjectPool.GetPooledObject();

                spawnedObject.transform.position = startPos;
                spawnedObject.transform.rotation = Quaternion.identity;
                spawnedObject.SetActive(true);
                spawn = false;
            }
            /*int rand2;
            if (ChangeEnviroment.GameEnviroment == 1)
            {
                rand2 = Random.Range(0, 3);
            }
            else
            {
                rand2 = Random.Range(3, spawnPositions.Count);
            }
            int rand = Random.Range(0, spawnableObjects.Count);*/

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
    }
    private void Start()
    {
        StartCoroutine(Generator());
        StartCoroutine(GameSpeedUpdate());
    }
    IEnumerator GameSpeedUpdate()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(2);
            gameSpeed += 0.5f;
        }
    }
}

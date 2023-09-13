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

    IEnumerator Generator()
    {
        while (true)
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
            yield return new WaitForSeconds(3);
            GameObject spawnedObject = Instantiate(spawnableObjects[rand], spawnPositions[rand2], Quaternion.Euler(0f, 180f, 0f));
        }
    }
    private void Awake()
    {
        Instance = this;
        gameSpeed = 5f;
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
    private void Update()
    {
        /*
        if (gameSpeed > 10f && gameSpeed < 20f && ChangeEnviroment.GameEnviroment != 2)
        {
            ChangeEnviroment.Instance.ChangeEnvironmentFunction(2);
        }
        if (gameSpeed > 20f && gameSpeed < 30f && ChangeEnviroment.GameEnviroment != 1)
        {
            ChangeEnviroment.Instance.ChangeEnvironmentFunction(1);
        }
        */
    }
}

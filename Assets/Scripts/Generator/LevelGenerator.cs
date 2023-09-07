using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectList = new List<GameObject>();
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
            int rand = Random.Range(0, objectList.Count);
            yield return new WaitForSecondsRealtime(2);
            GameObject spawnedObject = Instantiate(objectList[rand], spawnPositions[rand2], Quaternion.identity);
        }
    }
    private void Awake()
    {
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

}

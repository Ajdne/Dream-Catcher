using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CloudSpawner : MonoBehaviour
{
    public List<GameObject> cloudPrefabs = new List<GameObject>();
    public float spawnInterval = 5f;
    public float moveSpeed = 2f;
    public float spawnWidth = 20f; // Width of the spawn area
    public float spawnHeight = 5f; // Fixed Y position for spawning
    public float despawnTime = 10f; // Time before clouds despawn

    private float nextSpawnTime;
    private List<GameObject> spawnedClouds = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnCloudsOverTime());
    }

    void Update()
    {
        MoveClouds();
    }

    IEnumerator SpawnCloudsOverTime()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, cloudPrefabs.Count);
            GameObject selectedCloudPrefab = cloudPrefabs[randomIndex];

            float randomX = Random.Range(-spawnWidth / 2f, spawnWidth / 2f) + transform.position.x;

            Vector3 spawnPosition = new Vector3(randomX, spawnHeight, transform.position.z);

            GameObject newCloud = Instantiate(selectedCloudPrefab, spawnPosition, Quaternion.identity);
            spawnedClouds.Add(newCloud);

            // Despawn timer
            StartCoroutine(DespawnCloud(newCloud));

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void MoveClouds()
    {
        List<GameObject> cloudsToRemove = new List<GameObject>();

        foreach (GameObject cloud in spawnedClouds)
        {
            cloud.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
    }

    IEnumerator DespawnCloud(GameObject cloud)
    {
        yield return new WaitForSeconds(despawnTime);

        if (spawnedClouds.Contains(cloud))
        {
            spawnedClouds.Remove(cloud);
            Destroy(cloud);
        }
    }
}
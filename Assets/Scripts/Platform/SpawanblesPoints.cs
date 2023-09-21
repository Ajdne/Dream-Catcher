using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawanblesPoints : MonoBehaviour
{
    public GameObject Points;

    private void OnEnable()
    {
        // Get a reference to the parent GameObject's Transform component
        Transform parentTransform = Points.transform; // 'transform' refers to the Transform of the script's GameObject

        // Loop through all the children of the parent GameObject
        for (int i = 0; i < parentTransform.childCount; i++)
        {
            // Get a reference to each child Transform
            Transform childTransform = parentTransform.GetChild(i);
            GameObject objectToSpawn = (GameObject)LevelGenerator.Instance.SelectSpawnable();
            GameObject spawnedObject = ObjectPoolManager.SpawnObject(objectToSpawn, childTransform.position, Quaternion.Euler(0, 180, 0));
            spawnedObject.transform.SetParent(transform);
        }
    }
}

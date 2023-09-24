using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawanblesPoints : MonoBehaviour
{
    public GameObject Points;
    private Transform pointsTransform;
    private Vector3 rotationEuler = new(0, 180, 0);

    private void OnEnable()
    {
        // Get a reference to the parent GameObject's Transform component
        pointsTransform = Points.transform;

        foreach (Transform pointTransform in pointsTransform)
        {
            GameObject objectToSpawn = (GameObject)LevelGenerator.Instance.SelectSpawnable();
            GameObject spawnedObject = ObjectPoolManager.SpawnObject(objectToSpawn, pointTransform.position, Quaternion.Euler(rotationEuler));
            spawnedObject.transform.SetParent(pointTransform);
        }
    }
    private void OnDisable()
    {
        foreach (Transform pointTransform in pointsTransform)
        {
            if (pointTransform.childCount > 0)
            {
                ObjectPoolManager.ReturnObject(pointTransform.GetChild(0).gameObject);
            }
        }
    }
}

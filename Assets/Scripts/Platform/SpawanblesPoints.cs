using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawanblesPoints : MonoBehaviour
{
    public GameObject Points;
    private Transform pointsTransform;
    private Vector3 rotationEuler = new(0, 180, 0);

    private void OnEnable()
    {

        if (Points == null)
        {
            Debug.LogError("Points reference is not set in SpawnablesPoints script.");
            return;
        }
        // Get a reference to the parent GameObject's Transform component
        pointsTransform = Points.transform;
        FillPoints();
    }
    private void FillPoints()
    {
        foreach (Transform pointTransform in pointsTransform)
        {
            GameObject objectToSpawn = LevelGenerator.Instance.SelectSpawnable();
            if (!objectToSpawn.CompareTag("Empty"))
            {
                GameObject spawnedObject = ObjectPoolManager.SpawnObject(objectToSpawn, pointTransform.position, Quaternion.Euler(rotationEuler));
                spawnedObject.transform.SetParent(pointTransform);
            }
        }
    }
    private void ClearPoints()
    {
        foreach (Transform pointTransform in pointsTransform)
        {
            if (pointTransform.childCount > 0 && pointTransform.GetChild(0).gameObject.activeSelf)
            {
                ObjectPoolManager.ReturnObject(pointTransform.GetChild(0).gameObject);
            }
        }
    }
    private void OnDisable()
    {
        ClearPoints();
    }
}

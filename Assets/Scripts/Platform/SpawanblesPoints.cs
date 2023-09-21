using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawanblesPoints : MonoBehaviour
{
    public GameObject Points;

    void Start()
    {
        // Get a reference to the parent GameObject's Transform component
        Transform parentTransform = Points.transform; // 'transform' refers to the Transform of the script's GameObject

        // Loop through all the children of the parent GameObject
        for (int i = 0; i < parentTransform.childCount; i++)
        {
            // Get a reference to each child Transform
            Transform childTransform = parentTransform.GetChild(i);
            GameObject objectToSpawn = (GameObject)LevelGenerator.Instance.SelectSpawnable();
            GameObject spawnedObject = ObjectPoolManager.SpawnObject(objectToSpawn, childTransform.position, Quaternion.Euler(0,180,0));
            spawnedObject.transform.SetParent(transform);
            Debug.Log("SKripta stvorila: "+objectToSpawn.name);




            // Now you can access properties and methods of the child Transform or GameObject
            //GameObject childGameObject = childTransform.gameObject;
            //string childName = childGameObject.name;

            // Do something with the child GameObject or Transform
            //Debug.Log("Child Name: " + childName);
        }
    }
}

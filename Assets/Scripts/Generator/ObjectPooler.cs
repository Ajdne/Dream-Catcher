using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;
    //public GameObject pooledObject;
    public List<GameObject> pooledObjects;
    /*
    1 - countryside
    2 - town
    3 - dessert
    4 - snow
    5 - shrooms
    6 - sea
    7 - sky
    */
    public int pooledAmount;

    Dictionary<int, GameObject> pooledEnvironments;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        pooledEnvironments = new Dictionary<int, GameObject>();
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            GameObject Object = (GameObject)Instantiate(pooledObjects[i]);
            Object.SetActive(false);
            pooledEnvironments.Add(i, Object);
        }
    }
    public GameObject GetPooledObject()
    {
        switch(ChangeEnviroment.GameEnviroment)
        {
            case 1:
                for (int i = 0; i < 30; i++)
                {
                    if (!pooledEnvironments[i].activeInHierarchy)
                    {
                        return pooledEnvironments[i];
                    }
                }
                return null;
            case 2:
                for (int i = 5; i < 30; i++)
                {
                    if (!pooledEnvironments[i].activeInHierarchy)
                    {
                        return pooledEnvironments[i];
                    }
                }
                return null;
            case 3:
                for (int i = 10; i < 30; i++)
                {
                    if (!pooledEnvironments[i].activeInHierarchy)
                    {
                        return pooledEnvironments[i];
                    }
                }
                return null;
            case 4:
                for (int i = 15; i < 30; i++)
                {
                    if (!pooledEnvironments[i].activeInHierarchy)
                    {
                        return pooledEnvironments[i];
                    }
                }
                return null;
            case 5:
                for (int i = 20; i < 30; i++)
                {
                    if (!pooledEnvironments[i].activeInHierarchy)
                    {
                        return pooledEnvironments[i];
                    }
                }
                return null;
            case 6:
                for (int i = 25; i < 30; i++)
                {
                    if (!pooledEnvironments[i].activeInHierarchy)
                    {
                        return pooledEnvironments[i];
                    }
                }
                return null;
            case 7:
                for (int i = 30; i < 35; i++)
                {
                    if (!pooledEnvironments[i].activeInHierarchy)
                    {
                        return pooledEnvironments[i];
                    }
                }

                return null;
            default:
                return pooledEnvironments[1];
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleManager : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> okolinaList;
    private bool spawn = false;
    private void Update()
    {
        if (spawn)
        {
            int rand = Random.Range(0, okolinaList.Count);
            Instantiate(okolinaList[rand],new Vector3(0f, -0.52f, 450f), Quaternion.identity);
            spawn = false;
        }
    }
    private void OnTriggerExit(Collider EnvironmentPrefab)
    {
        if (EnvironmentPrefab.CompareTag("Environment")){
            spawn = true;
        }
    }
}

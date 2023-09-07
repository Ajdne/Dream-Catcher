using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnviroment : MonoBehaviour
{
    public static int GameEnviroment;
    [SerializeField]
    private Camera _Camera;
    private void Start()
    {
        ChangeEnv(2);
    }
    public void ChangeEnv(int gameEnv)
    {
        GameEnviroment = gameEnv;
        if (gameEnv == 1)
        {
            _Camera.transform.position = new Vector3(0, 4.3f, -8.24f);
        }
        else if (gameEnv == 2)
        {
            _Camera.transform.position = new Vector3(0, -3.6f, -8.24f);
        }
        else if (gameEnv == 3)
        {
            _Camera.transform.position = new Vector3(0, 4.3f, -8.24f);
        }
    }
}

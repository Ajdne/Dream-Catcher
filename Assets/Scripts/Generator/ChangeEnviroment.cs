using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ChangeEnviroment : MonoBehaviour
{
    public static ChangeEnviroment Instance;
    public static int GameEnviroment;
    [SerializeField]
    private Camera _Camera;
    private void Awake()
    {
        GameEnviroment = 1;
        Instance = this;
    }
    private void Start()
    {
        //ChangeCamera();
    }
    public void ChangeEnvironmentFunction(int numb)
    {
        GameEnviroment = numb;
        ChangeCamera();
    }
    private void ChangeCamera()
    {
        if (GameEnviroment == 1)
        {
            _Camera.transform.DOMove(new Vector3(0, 4.1f, -8.5f), 1f);
            _Camera.transform.DORotate(new Vector3(5.02f, 0, 0), 1f);
        }
        else if (GameEnviroment == 2)
        {
            _Camera.transform.DOMove(new Vector3(0, -1.9f, -10.13f), 1f);
            _Camera.transform.DORotate(new Vector3(17.13f, 0, 0), 1f);
        }
        else if (GameEnviroment == 3)
        {
            _Camera.transform.DOMove(new Vector3(0, 4.1f, -8.5f), 1f);
            _Camera.transform.DORotate(new Vector3(5.02f, 0, 0), 1f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ChangeEnviroment : MonoBehaviour
{
    /*
     1 - countryside
     2 - town
     3 - dessert
     4 - snow
     5 - shrooms
     6 - sea
     7 - sky
     */
    public static ChangeEnviroment Instance;
    public static int GameEnviroment;

    private void Awake()
    {
        GameEnviroment = 1;
        Instance = this;
    }
    private void Start()
    {
        EventManager.EnvironmentTransformEvent += ChangeEnvironmentFunction;
    }
    private void OnDisable()
    {
        EventManager.EnvironmentTransformEvent -= ChangeEnvironmentFunction;
    }
    public void ChangeEnvironmentFunction(int numb)
    {
        GameEnviroment = numb;
        ChangeCamera();
    }
    private void ChangeCamera()
    {
        if (GameEnviroment != 7)
        {
            CameraMotor.Instance.offset = new(0, 5f, -10f);
        }
        else if (GameEnviroment == 7)
        {
            CameraMotor.Instance.offset = new (0, -3f, -10f);
        }
    }
}

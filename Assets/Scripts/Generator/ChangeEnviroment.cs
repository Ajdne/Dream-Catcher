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
        //ChangeCamera();
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

    public int numb;
    public bool isVertical;

    public IEnumerator EnvironmentController()
    {
        while (LevelGenerator.Instance.IsAlive)
        {
            if (numb >= 10)
            {
                numb = 0;
                if (isVertical)
                {
                    ObjectPooler.Instance.TurnOffEnvironment();
                    ChangeEnviroment.Instance.ChangeEnvironmentFunction(7);
                    isVertical = false;
                }
                else
                {
                    int rand = Random.Range(1, 7);
                    ChangeEnviroment.Instance.ChangeEnvironmentFunction(rand);
                }
            }
            yield return null;
        }
        // promeni se jedan horizontalan
        // promeni na novi envi (numb)
        // 5 ciklusa spawna se ceka
        // promeni se u nebo
        // promeni na novi envi (numb)
        // neki time u nebu
    }
}

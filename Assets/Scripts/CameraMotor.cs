using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt; // object we are looking at
    public Vector3 offset = new (0, 5f, -10f);
    public Vector3 offset2 = new (0, -3f, -10f);

    private void Start()
    {
        transform.position = lookAt.position + offset;
    }
    private void Update()
    {
        Vector3 desiredPosition;
        if (LevelGenerator.Instance.isVertical)
        {
            desiredPosition = lookAt.position + offset2;
        }
        else
        {
            desiredPosition = lookAt.position + offset;
        }

        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime*3);
    }
}

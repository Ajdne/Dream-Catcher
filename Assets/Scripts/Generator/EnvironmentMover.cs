using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class EnvironmentMover : MonoBehaviour
{
    private Transform Transform;
    private void Awake()
    {
        Transform = transform;
    }
    private void Start()
    {
        /*
        float step = LevelGenerator.gameSpeed;
        Transform.DOMove(new Vector3(0f, -0.52f, -150f), step);
        if(Transform.position == new Vector3(0f, -0.52f, -150f))
        {
            Destroy(gameObject);
        }
        */
    }
}

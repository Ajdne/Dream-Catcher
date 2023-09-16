using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;
using System.Net;

public class EnvironmentMover : MonoBehaviour
{
    private Transform Transform;
    private Vector3 endPos = new(0f, -0.5f, -150f);
    private float step;
    private void Awake()
    {
        Transform = transform;
    }
    private void Start()
    {
        // start check environment if not 7 idi na levo ako je 7 idi na gore
    }
    private void FixedUpdate()
    {
        step = LevelGenerator.gameSpeed * Time.fixedDeltaTime * 2;
        Transform.position = Vector3.MoveTowards(Transform.position, endPos, step);
        if (Transform.position == endPos)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
            gameObject.SetActive(false);
        }
    }
}


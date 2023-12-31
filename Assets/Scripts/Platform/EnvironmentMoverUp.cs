using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMoverUp : MonoBehaviour
{
    private EnvironmentMover environmentMover;
    private Transform Transform;
    private Vector3 endPos;

    private float step;
    private void Awake()
    {
        Transform = GetComponent<Transform>();
        environmentMover = GetComponent<EnvironmentMover>();
    }
    private void OnEnable()
    {
        endPos = new(0, -0.2f, transform.position.z);
    }
    private void Update()
    {
        step = LevelGenerator.gameSpeed * Time.deltaTime *0.5f;
        Transform.position = Vector3.MoveTowards(Transform.position, endPos, step);
        if (Transform.position == endPos)
        {
            environmentMover.enabled = true;
            enabled = false;
        }
    }
}

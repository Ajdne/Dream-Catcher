using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    private Vector3 endPos;
    private float step;
    private Transform _transform;
    private void Awake()
    {
        _transform = GetComponent<Transform>();

    }
    void Start()
    {
        if (ChangeEnviroment.GameEnviroment != 7)
        {
            endPos = new(_transform.position.x, 0, -10);
        }
        else
        {
            endPos = new(_transform.position.x, 10, 0);
        }
        step = LevelGenerator.gameSpeed*Time.deltaTime;
    }
    private void Update()
    {
        step = LevelGenerator.gameSpeed * Time.deltaTime;
        _transform.position = Vector3.MoveTowards(_transform.position, endPos, step);
        if(_transform.position == endPos)
        {
            Destroy(gameObject);
        }
    }
}

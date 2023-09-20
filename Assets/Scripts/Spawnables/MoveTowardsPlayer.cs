using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    private Vector3 endPos;
    private float step;
    private float speed;
    private Transform _transform;
    private void Awake()
    {
        _transform = GetComponent<Transform>();

    }
    private void OnEnable()
    {
        EventManager.EnvironmentTransformEvent += ChangeListener;
        if (LevelGenerator.GameEnvironment != 7)
        {
            speed = 1f;
            endPos = new(_transform.position.x, 0, -10);
        }
        else
        {
            speed = 0.33f;
            endPos = new(_transform.position.x, 10, 0);
        }        
    }
    private void Update()
    {
        step = LevelGenerator.gameSpeed * Time.deltaTime * speed;
        _transform.position = Vector3.MoveTowards(_transform.position, endPos, step);
        if(_transform.position == endPos)
        {
            ObjectPoolManager.ReturnObject(gameObject);
        }
    }
    private void OnDisable()
    {
        EventManager.EnvironmentTransformEvent -= ChangeListener;
    }
    private void ChangeListener(int Id)
    {
        ObjectPoolManager.ReturnObject(gameObject);
    }
}

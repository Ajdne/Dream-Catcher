using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;
using System.Net;

public class EnvironmentMover : MonoBehaviour
{
    private Transform Transform;
    private Vector3 endPos;

    private float step;
    private void Awake()
    {
        Transform = GetComponent<Transform>();
    }
    private void OnEnable()
    {
        endPos = new(0f, -0.2f, -140f);
    }
    private void Update()
    {
        step = LevelGenerator.gameSpeed * Time.deltaTime;
        Transform.position = Vector3.MoveTowards(Transform.position, endPos, step);
        //kad dodjes na krajnju poziciju
        if(Transform.position == endPos )
        {
            Debug.Log("Vrati u pool");
            gameObject.transform.Find("Trigger1").gameObject.SetActive(false);
            gameObject.transform.Find("Trigger2").gameObject.SetActive(false);
            ObjectPoolManager.ReturnObject(gameObject);
        }
    }
}


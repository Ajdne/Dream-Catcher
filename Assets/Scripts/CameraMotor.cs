using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMotor : MonoBehaviour
{
    public static CameraMotor Instance;
    private Camera _Camera;

    [SerializeField] private Vector3 _positionStrenght;
    [SerializeField] private Vector3 _rotationStrenght;
    // object we are looking at
    [SerializeField] private Transform lookAt; 
    private Vector3 offset;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _Camera = GetComponent<Camera>();
        _Camera.transform.rotation = Quaternion.Euler(5, 0, 0);
        offset = new(0, 4f, -7f);
        transform.position = lookAt.position + offset;
    }
    private void Update()
    {
        Vector3 desiredPosition = lookAt.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime*3);
    }
    public void EnvironmentListener(int Id)
    {
        if (Id != 7)
        {
            _Camera.DOComplete();
            _Camera.DOShakePosition(0.5f, _positionStrenght);
            _Camera.DOShakeRotation(0.5f, _rotationStrenght);
            _Camera.transform.rotation = Quaternion.Euler(5, 0, 0);
            offset = new(0, 4f, -7f);
        }
        else if (Id == 7)
        {
            _Camera.DOComplete();
            _Camera.DOShakePosition(0.5f, _positionStrenght);
            _Camera.DOShakeRotation(0.5f, _rotationStrenght);
            _Camera.transform.rotation = Quaternion.Euler(42, 0, 0);
            offset = new(0, 4f, -10f);
        }
    }
    private void OnEnable()
    {
        EventManager.EnvironmentTransformEvent += EnvironmentListener;
    }
    private void OnDisable()
    {
        EventManager.EnvironmentTransformEvent -= EnvironmentListener;
    }
}

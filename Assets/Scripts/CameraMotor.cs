using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMotor : MonoBehaviour
{
    public static CameraMotor Instance;
    private Camera _Camera;

    [SerializeField] private Vector3 _FallpositionStrenght;
    [SerializeField] private Vector3 _FallrotationStrenght;
    [SerializeField] private Vector3 _LandpositionStrenght;
    [SerializeField] private Vector3 _LandrotationStrenght;
    [SerializeField] private Vector3 _HitpositionStrenght;
    [SerializeField] private Vector3 _HitrotationStrenght;
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
    public void FallCameraShake()
    {
        _Camera.DOComplete();
        _Camera.DOShakePosition(0.3f, _FallpositionStrenght);
        _Camera.DOShakeRotation(0.3f, _FallrotationStrenght);
    }
    public void LandCameraShake()
    {
        _Camera.DOComplete();
        _Camera.DOShakePosition(0.3f, _LandpositionStrenght);
        _Camera.DOShakeRotation(0.3f, _LandrotationStrenght);
    }
    public void HitCameraShake()
    {
        _Camera.DOComplete();
        _Camera.DOShakePosition(0.3f, _HitpositionStrenght);
        _Camera.DOShakeRotation(0.3f, _HitrotationStrenght);
    }
    public void EnvironmentListener(int Id)
    {
        if (Id != 7)
        {
            LandCameraShake();
            _Camera.transform.rotation = Quaternion.Euler(5, 0, 0);
            offset = new(0, 6f, -10f);
        }
        else if (Id == 7)
        {
            FallCameraShake();
            _Camera.transform.rotation = Quaternion.Euler(35, 0, 0);
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

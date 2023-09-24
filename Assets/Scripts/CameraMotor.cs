using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMotor : MonoBehaviour
{
    public static CameraMotor Instance;
    private Camera _Camera;
    // fall
    [SerializeField] private Vector3 _FallpositionStrenght;
    [SerializeField] private Vector3 _FallrotationStrenght;
    // land
    [SerializeField] private Vector3 _LandpositionStrenght;
    [SerializeField] private Vector3 _LandrotationStrenght;
    // hit
    [SerializeField] private Vector3 _HitpositionStrenght;
    [SerializeField] private Vector3 _HitrotationStrenght;
    // object we are looking at
    [SerializeField] private Transform lookAt; 
    private Vector3 offset;
    private void Awake()
    {
        Instance = this;
        _Camera = GetComponent<Camera>();
    }
    private void Start()
    {
        _Camera.transform.rotation = Quaternion.Euler(35, 0, 0);
        offset = new(0, 5f, -10f);
        transform.position = lookAt.position + offset;
    }
    private void Update()
    {
        Vector3 targetPosition = lookAt.position + offset;
        float lerpSpeed = 3f; // Adjust this value to control the speed of the interpolation

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * lerpSpeed);
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
    public bool CameraUp = true;
    public void CameraController()
    {
        if (CameraUp)
        {
            LandCameraShake();
            _Camera.transform.rotation = Quaternion.Euler(7f, 0, 0);
            offset = new(0f, 5f, -9f);
            CameraUp = false;
        }
        else
        {
            FallCameraShake();
            _Camera.transform.rotation = Quaternion.Euler(42f, 0, 0);
            offset = new(0f, 6f, -10f);
            CameraUp = true;
        }
    }
    private void OnEnable()
    {
        EventManager.Camera += CameraController;
        EventManager.ObstacleHit += HitCameraShake;
    }
    private void OnDisable()
    {
        EventManager.Camera -= CameraController;
        EventManager.ObstacleHit -= HitCameraShake;
    }
}

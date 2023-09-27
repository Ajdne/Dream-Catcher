using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public int ObstaclesHit;
    public int Health;
    public int Score;
    public int MultiplierCounter;
    
    [SerializeField] private GameObject krevet;
    [SerializeField] private GameObject krevetPadobran;
    [SerializeField] private GameObject krevetBrod;
    [SerializeField] private GameObject krevetPesak;
    [SerializeField] private GameObject krevetSkije;

    [SerializeField] private ParticleSystem Leaves;
    [SerializeField] private ParticleSystem Snow;
    [SerializeField] private ParticleSystem Skulls;
    [SerializeField] private ParticleSystem Smoke;
    private void Awake()
    {
        Instance = this;

    }
    private void OnEnable()
    {
        EventManager.ObstacleHit += ObstacleHit;
        EventManager.Sheep += SheepCollect;
        EventManager.TransformPlayer += TransformPlayer;
    }
    private void OnDisable()
    {
        EventManager.ObstacleHit -= ObstacleHit;
        EventManager.Sheep -= SheepCollect;
        EventManager.TransformPlayer -= TransformPlayer;
    }
    private void ObstacleHit()
    {
        EventManager.StartSFXEvent("Hit");
        Skulls.gameObject.SetActive(true);
        if(Health >= 1)
        {
            Health -= 1;
            ObstaclesHit += 1;
            if (Health == 0)
                EventManager.StartPlayerDeath();
        }
        EventManager.StartUpdateGUI();
    }
    private void SheepCollect(int Id)
    {
        EventManager.StartSFXEvent("Sheep");
        if (Id == 1) // White sheep
        {
            Score++;
        }
        else if (Id == 2) // Pink sheep
        {
            if (Health <= 2)
            {
                EventManager.StartSFXEvent("HealthUp");
                Health++;
            }
            Score++;
        }
        else if (Id == 3) // Black sheep
        {
            Score++;
            if (MultiplierCounter <= 2)
            {
                EventManager.StartSFXEvent("SpeedUp");
                LevelGenerator.gameSpeed *= 1.3f;
                MultiplierCounter++;
            }
            Score++;
        }
        EventManager.StartUpdateGUI();
    }
    private void Start()
    {
        ObstaclesHit = 0;
        Health = 3;
        MultiplierCounter = 0;
    }
    private void TransformPlayer(int Id)
    {
        EventManager.StartSFXEvent("Transform");
        // Deactivate all objects first
        krevet.SetActive(false);
        krevetBrod.SetActive(false);
        krevetPesak.SetActive(false);
        krevetSkije.SetActive(false);
        krevetPadobran.SetActive(false);

        Leaves.gameObject.SetActive(false);
        Snow.gameObject.SetActive(false);
        Smoke.gameObject.SetActive(true);
        // Activate the appropriate object based on the transformationId
        switch (Id)
        {
            case 7: // Padobran
                krevetPadobran.SetActive(true);
                break;
            case 4: // Brod
                krevetBrod.SetActive(true);
                Leaves.gameObject.SetActive(true);
                break;
            case 3: // Skije
                krevetSkije.SetActive(true);
                Snow.gameObject.SetActive(true);
                break;
            case 2: // Pustinja
                krevetPesak.SetActive(true);
                Snow.gameObject.SetActive(true);
                break;
            default: // Obican
                krevet.SetActive(true);
                Leaves.gameObject.SetActive(true);
                break;
        }
    }
}

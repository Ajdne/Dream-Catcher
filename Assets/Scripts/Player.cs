using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public int Health;
    public int Score;
    public int MultiplierCounter;
    [SerializeField] private GameObject krevet;
    [SerializeField] private GameObject krevetPadobran;
    [SerializeField] private GameObject krevetBrod;
    [SerializeField] private GameObject krevetPesak;
    [SerializeField] private GameObject krevetSkije;
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
        if(Health >= 1)
        {
            Health -= 1;
            if (Health == 0)
                EventManager.StartPlayerDeath();
        }
        EventManager.StartUpdateGUI();
    }
    private void SheepCollect(int Id)
    {
        if(Id == 1)//white sheep
        {
            Score++;
        }
        if(Id == 2)// pink sheep
        {
            if(Health <= 2)
            {
                Health++;
            }
            Score++;
        }
        if(Id == 3)//black sheep
        {
            Score++;
            if (MultiplierCounter <= 2)
            {
                LevelGenerator.gameSpeed *= 1.3f;
                MultiplierCounter++;
            }
        }
        EventManager.StartUpdateGUI();
    }
    private void Start()
    {
        Health = 3;
        MultiplierCounter = 0;
    }
    private void TransformPlayer(int Id)
    {
        switch (Id)
        {
            case 7: //padobran
                krevet.SetActive(false);
                krevetBrod.SetActive(false);
                krevetPesak.SetActive(false);
                krevetSkije.SetActive(false);
                krevetPadobran.SetActive(true);
                break;
            case 4: //brod
                krevet.SetActive(false);
                krevetBrod.SetActive(true);
                krevetPesak.SetActive(false);
                krevetSkije.SetActive(false);
                krevetPadobran.SetActive(false);
                break;
            case 3: //skije
                krevet.SetActive(false);
                krevetBrod.SetActive(false);
                krevetPesak.SetActive(false);
                krevetSkije.SetActive(true);
                krevetPadobran.SetActive(false);
                break;
            case 2: //pustinja
                krevet.SetActive(false);
                krevetBrod.SetActive(false);
                krevetPesak.SetActive(true);
                krevetSkije.SetActive(false);
                krevetPadobran.SetActive(false);
                break;
            default: //obican
                krevet.SetActive(true);
                krevetBrod.SetActive(false);
                krevetPesak.SetActive(false);
                krevetSkije.SetActive(false);
                krevetPadobran.SetActive(false);
                break;
        }
    }
}

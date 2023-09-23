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
    private void Awake()
    {
        Instance = this;

    }
    private void OnEnable()
    {
        EventManager.ObstacleHit += ObstacleHit;
        EventManager.Sheep += SheepCollect;
    }
    private void OnDisable()
    {
        EventManager.ObstacleHit -= ObstacleHit;
        EventManager.Sheep -= SheepCollect;
    }
    private void ObstacleHit()
    {
        if(Health >= 1)
        {
            Health -= 1;
            if (Health == 0)
                EventManager.StartPlayerDeath();
        }
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
    }
    private void Start()
    {
        Health = 3;
        MultiplierCounter = 0;
    }
}

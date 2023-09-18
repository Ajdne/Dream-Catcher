using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public int Health;
    public int Score;
    private void Awake()
    {
        Instance = this;

    }
    private void Start()
    {
        Health = 3;
    }
    private void Update()
    {
        if(Health < 1)
        {
            EventManager.StartPlayerDeath();
        }
    }
}

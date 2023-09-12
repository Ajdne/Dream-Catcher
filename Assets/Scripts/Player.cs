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
        Health = 3;
    }
}

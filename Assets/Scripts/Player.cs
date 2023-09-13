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
    public IEnumerator DoubleSpeed()
    {
        Time.timeScale += 1;
        yield return new WaitForSecondsRealtime(5);
        Time.timeScale -= 1;
    }
}

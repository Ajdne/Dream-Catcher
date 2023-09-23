using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action<int> EnvironmentTransformEvent;
    public static event Action PlayerDeath;
    public static event Action ObstacleHit;
    public static event Action<int> Sheep;
    public static event Action Camera;
    public static event Action UpdateGUI;
    public static event Action<int> TransformPlayer;
    public static void StartTransformPlayer(int Id)
    {
        TransformPlayer?.Invoke(Id);
    }
    public static void StartUpdateGUI()
    {
        UpdateGUI?.Invoke();
    }
    public static void StartCamera()
    {
        Camera?.Invoke();
    }
    public static void StartSheep(int Id)
    {
        Sheep?.Invoke(Id);
    }
    public static void StartObstacleHit()
    {
        ObstacleHit?.Invoke();
    }
    public static void StartEnvironmentTransformEvent(int eventID)
    {
        Debug.Log("Enviroment ID: " + eventID);
        EnvironmentTransformEvent?.Invoke(eventID);
    }
    public static void StartPlayerDeath()
    {
        PlayerDeath?.Invoke();
    }
}

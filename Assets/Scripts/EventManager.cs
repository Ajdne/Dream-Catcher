using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action<int> EnvironmentTransformEvent;
    public static void StartEnvironmentTransformEvent(int eventID)
    {
        Debug.Log("Enviroment ID: " + eventID);
        EnvironmentTransformEvent?.Invoke(eventID);
    }
}
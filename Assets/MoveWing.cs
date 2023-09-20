using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveWing : MonoBehaviour
{
    public GameObject LeftWing;
    public GameObject RightWing;
    [SerializeField] private bool isClosed;
    public void MoveWings()
    {
        if (isClosed)
        {
            LeftWing.transform.DOMoveZ(transform.position.z - 0.77f, 3); //-10.12 -> 10.99
            LeftWing.transform.DOMoveZ(transform.position.z + 1.12f, 3); //-9.12 -> -8.24
            isClosed = false;
        }
        else 
        {
            LeftWing.transform.DOMoveZ(-10.12f, 3); //-10.99 -> 10.12
            LeftWing.transform.DOMoveZ(-9.12f, 3); //-8.24 -> -9.12
            isClosed = true;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float duration;
    public void LookAt(Transform target)
    {
        //pozicije i rotacija kamere je cutom namestena na osnovu pozicije panela
        //ako se mrda panel mora se menjati ovo
        if (target.CompareTag("Settings"))
        {
            transform.DOMove(new Vector3(3.261f, 2.06f, -9.595f), duration); 
            transform.DORotate(new Vector3(0,-90,0), duration);
        }
        else if (target.CompareTag("Shop"))
        {
            transform.DOMove(new Vector3(3.26f, 2.06f, -5.96f), duration); 
            transform.DORotate(new Vector3(0, -90, 0), duration);
        }
        if (target.CompareTag("MainMenu"))
        {
            transform.DOMove(new Vector3(6.945f, 2.043f, -6.309f), duration); 
            transform.DORotate(new Vector3(10, -60, 0), duration);           
        }
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class TapInput : MonoBehaviour
{
    //https://www.youtube.com/watch?v=C9qoYdslLcg
    public static TapInput Instance;
    public static float LANE_DISTANCE = 2.0f;
    [SerializeField] private GameObject _Player;
    private int desiredLane = 1; //0 = left, 1 = middle, 2= right
    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {

        // calculate where we should be in the future
        Vector3 targetPosition = Vector3.zero;
        if(desiredLane == 0)
            targetPosition += Vector3.left * LANE_DISTANCE;
        else if(desiredLane == 2)
            targetPosition += Vector3.right * LANE_DISTANCE;

        // calculate move delta
        float moveVector = LevelGenerator.gameSpeed * Time.deltaTime * 0.5f;
        _Player.transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveVector);
    }
    private void MoveLane(bool goingRight)
    {
        //gather the inputs on which lane we should be
        desiredLane += (goingRight) ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);
    }

    public void MoveLaneLeft()
    {
        MoveLane(false);
    }
    public void MoveLaneRight()
    {
        MoveLane(true);
    }

}

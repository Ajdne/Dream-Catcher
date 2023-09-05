using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class TapInput : MonoBehaviour
{
    private const float LANE_DISTANCE = 2f;
    private CharacterController characterController;
    private int desiredLane = 1; //0 = left, 1 = middle, 2= right
    private float speed = 5f;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        //gather the inputs on which lane we should be
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLane(false);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        { 
            MoveLane(true);
        }
        // calculate where we should be in the future
        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * LANE_DISTANCE;
        }else if(desiredLane == 2)
        {
            targetPosition += Vector3.right * LANE_DISTANCE;
        }
        // calculate move delta
        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).normalized.x * speed;
        moveVector.y = 0;
        moveVector.z = 0;
        //move player
        characterController.Move(moveVector * Time.deltaTime);
    }
    private void MoveLane(bool goingRight)
    {
        desiredLane += (goingRight) ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);
    }
}

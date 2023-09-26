using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveInput : MonoBehaviour
{
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    public float MoveFactorX => _moveFactorX;
    private void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
                _lastFrameFingerPositionX = Input.mousePosition.x;
        }else if (Input.GetMouseButton(0))
        {
            _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }else if(Input.GetMouseButtonUp(0))
        {
            _moveFactorX = 0f;
        }*/
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _lastFrameFingerPositionX = Input.mousePosition.x;
                    break;
                case TouchPhase.Moved:
                    _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
                    _lastFrameFingerPositionX = Input.mousePosition.x;
                    break;

                case TouchPhase.Ended:
                    _moveFactorX = 0f;
                    break;
            }
        }
    }
}

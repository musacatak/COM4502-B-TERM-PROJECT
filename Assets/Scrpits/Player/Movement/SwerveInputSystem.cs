using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveInputSystem : MonoBehaviour
{

    private float _lastFrameFingerPositionX;
    private float _moveFactorX = 0f;

    public float MoveFactorX => _moveFactorX;

    bool isActive = false;

    private void Update()
    {
        if (isActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _lastFrameFingerPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButton(0))
            {
                _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
                _lastFrameFingerPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _moveFactorX = 0f;
            }
        }
    }

    public void DisableSwerveInput()
    {
        isActive = false;
    }
    public void EnableSwerveInput()
    {
        isActive = true;
    }
}

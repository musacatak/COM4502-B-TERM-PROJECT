using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    public SwerveInputSystem swerveInputSystem;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 1f;

    public GameObject player;
    public GameObject cameraT;
    public float maxX;
    public float minX;

    public float speed = 1f;

    bool isActive = false;

    private void Update()
    {
        if (isActive)
        {
            float swerveAmount = Time.deltaTime * swerveSpeed * swerveInputSystem.MoveFactorX;
            swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);

            cameraT.transform.Translate(0, 0, speed * Time.deltaTime);
            player.transform.Translate(swerveAmount, 0, speed * Time.deltaTime);

            if (player.transform.position.x >= maxX)
            {
                player.transform.position = new Vector3(maxX, player.transform.position.y, player.transform.position.z);
            }
            else if (player.transform.position.x <= minX)
            {
                player.transform.position = new Vector3(minX, player.transform.position.y, player.transform.position.z);
            }
        }

    }

    public void DisableSwerveMove()
    {
        isActive = false;
    }

    public void EnableSwerveMove()
    {
        isActive = true;
    }

}

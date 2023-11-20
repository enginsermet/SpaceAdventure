using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float speed;
    float acceleration;
    float maxSpeed;

    bool motion = true;

    // Start is called before the first frame update
    void Start()
    {
        if (Preferences.GetEasyValue() == 1)
        {
            speed = 0.5f;
            acceleration = 0.05f;
            maxSpeed = 1.5f;
        }

        if (Preferences.GetMediumValue() == 1)
        {
            speed = 0.7f;
            acceleration = 0.07f;
            maxSpeed = 2.0f;
        }

        if (Preferences.GetHardValue() == 1)
        {
            speed = 0.9f;
            acceleration = 0.09f;
            maxSpeed = 2.5f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (motion)
        {
            MoveCamera();
        }
    }

    void MoveCamera()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        speed += acceleration * Time.deltaTime;
        if(speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }
}

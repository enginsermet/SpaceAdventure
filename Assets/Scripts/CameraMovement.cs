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
        speed = 0.5f;
        acceleration = 0.05f;
        maxSpeed = 2.0f;
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

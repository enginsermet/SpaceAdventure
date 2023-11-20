using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl : MonoBehaviour
{
    float backgroundPosition;
    float distance = 10.24f;

    // Start is called before the first frame update
    void Start()
    {
        backgroundPosition = transform.position.y;
        FindObjectOfType<Planets>().SpawnPlanet(backgroundPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (backgroundPosition + distance < Camera.main.transform.position.y)
        {
            MoveBackground();
        }
    }

    void MoveBackground()
    {
        backgroundPosition += (distance * 2);
        FindObjectOfType<Planets>().SpawnPlanet(backgroundPosition);
        Vector2 newPosition = new Vector2(0, backgroundPosition);
        transform.position = newPosition;
    }
}

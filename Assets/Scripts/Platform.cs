using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    PolygonCollider2D polygonCollider2D;

    float randomSpeed;
    bool move = true;
    float initPos;

    public bool Move
    {
        get
        {
            return move;
        }
        set
        {
            move = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        randomSpeed = Random.Range(0.5f, 1.0f);
        initPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            float pingPongX = Mathf.PingPong(Time.time * randomSpeed, 3.0f);
            Vector2 pingPong = new Vector2(initPos + pingPongX, transform.position.y);
            transform.position = pingPong;
        }
    }
}

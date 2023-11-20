using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    PolygonCollider2D polygonCollider2D;

    float randomSpeed;
    bool move;
    float initPos;

    float min, max;

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

        if (Preferences.GetEasyValue() == 1)
        {
            randomSpeed = Random.Range(0.2f, 0.8f);
        }

        if (Preferences.GetMediumValue() == 1)
        {
            randomSpeed = Random.Range(0.5f, 1.0f);
        }

        if (Preferences.GetHardValue() == 1)
        {
            randomSpeed = Random.Range(0.8f, 1.5f);
        }





        initPos = transform.position.x;

        float objectWidth = polygonCollider2D.bounds.size.x / 2;
        //if (transform.position.x > 0)
        //{
        //    min = objectWidth;
        //    max = ScreenCalculator.instance.Width - initPos;
        //}
        //else
        //{
        //    min = initPos;
        //    max = -objectWidth;
        //}
        if (transform.position.x > 0)
        {
            min = objectWidth;
            max = ScreenCalculator.instance.Width - objectWidth;
        }
        else
        {
            min = -ScreenCalculator.instance.Width + objectWidth;
            max = -objectWidth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            float pingPongX = Mathf.PingPong(Time.time * randomSpeed, max - min) + min;
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y);
            transform.position = pingPong;
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Legs")
        {
            GameObject.FindGameObjectWithTag("Player").transform.parent = transform;
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerControl>().ResetJump();
        }

    }
}

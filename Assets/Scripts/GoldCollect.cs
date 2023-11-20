using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Legs")
        {
            GetComponentInParent<Gold>().GoldOff();
            FindObjectOfType<Score>().CollectGold();
        }
    }

}

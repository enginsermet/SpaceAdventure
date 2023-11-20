using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField]
    GameObject gold = default;


    public void GoldOn()
    {
        gold.SetActive(true);
    }

    public void GoldOff()
    {
        gold.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    [SerializeField]
    GameObject platformPrefab = default;

    [SerializeField]
    GameObject deadlyPlatformPrefab = default;

    [SerializeField]
    GameObject playerPrefab = default;

    List<GameObject> platforms = new List<GameObject>();

    Vector2 platformPosition;
    Vector2 playerPosition;
    [SerializeField]
    float DistanceBtwnPlatforms = default;

    // Start is called before the first frame update
    void Start()
    {
        CreatePlatform();
    }

    // Update is called once per frame
    void Update()
    {
        if (platforms[platforms.Count - 1].transform.position.y < 
            Camera.main.transform.position.y + ScreenCalculator.instance.Height)
        {
            MovePlatform();
        }
    }

    void MovePlatform()
    {

        for (int i = 0; i < 5; i++)
        {
            GameObject temp;
            temp = platforms[i + 5];
            platforms[i + 5] = platforms[i];
            platforms[i] = temp;
            platforms[i + 5].transform.position = platformPosition;
            if(platforms[i + 5].gameObject.tag == "Platform")
            {
                platforms[i + 5].GetComponent<Gold>().GoldOff();
                float randomGold = Random.Range(0.0f, 1.0f);
                if(randomGold > 0.5f)
                {
                    platforms[i + 5].GetComponent<Gold>().GoldOn();
                }
            }
            NextPlatformPosition(DistanceBtwnPlatforms);

        }
    }

    void CreatePlatform()
    {
        playerPosition = new Vector2(0, 0.5f);
        platformPosition = new Vector2(0, 0);

        GameObject player = Instantiate(playerPrefab, playerPosition, Quaternion.identity);
        GameObject basePlatform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);
        player.transform.parent = basePlatform.transform;
        platforms.Add(basePlatform);
        NextPlatformPosition(DistanceBtwnPlatforms);
        basePlatform.GetComponent<Platform>().Move = true;


        for (int i = 0; i < 8; i++)
        {
            GameObject platform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);
            platform.GetComponent<Gold>().GoldOff();
            platforms.Add(platform);
            platform.GetComponent<Platform>().Move = true;
            if(i % 2 == 0)
            {
                platform.GetComponent<Gold>().GoldOn();
            };
            NextPlatformPosition(DistanceBtwnPlatforms);
        }

        NextPlatformPosition(-1.5f);
        GameObject deadlyPlatform = Instantiate(deadlyPlatformPrefab, platformPosition, Quaternion.identity);
        deadlyPlatform.GetComponent<DeadlyPlatform>().Move = true;
        platforms.Add(deadlyPlatform);
        NextPlatformPosition(1.5f);
    }

    void NextPlatformPosition(float DistanceBtwnPlatforms)
    {
        platformPosition.y += DistanceBtwnPlatforms;
        float random = Random.Range(0.0f, 1.0f);
        if (random < 0.5f)
        {
            platformPosition.x = ScreenCalculator.instance.Width / 2;
        }
        else
        {
            platformPosition.x = -ScreenCalculator.instance.Width / 2;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour
{
    List<GameObject> planets = new List<GameObject>();
    List<GameObject> activePlanets = new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
        Object[] sprites = Resources.LoadAll("Planets");

        for (int i = 1; i < 17; i++)
        {
            GameObject planet = new GameObject();
            SpriteRenderer spriteRenderer = planet.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = (Sprite)sprites[i];
            Color spriteColor = spriteRenderer.color;
            spriteColor.a = 0.7f;
            planet.name = sprites[i].name;
            spriteRenderer.sortingLayerName = "Planet";
            Vector2 position = planet.transform.position;
            position.x = -10;
            planet.transform.position = position;
            planets.Add(planet);
        }
    }

    public void SpawnPlanet(float refY)
    {
        float height = ScreenCalculator.instance.Height;
        float width = ScreenCalculator.instance.Width;

        //Area 1
        float x1 = Random.Range(0.0f, width);
        float y1 = Random.Range(refY, refY + height);
        GameObject planet1 = RandomPlanet();
        planet1.transform.position = new Vector2(x1, y1);
        //Area 2
        float x2 = Random.Range(-width, 0.0f);
        float y2 = Random.Range(refY, refY + height);
        GameObject planet2 = RandomPlanet();
        planet2.transform.position = new Vector2(x2, y2);
        //Area 3
        float x3 = Random.Range(-width, 0.0f);
        float y3 = Random.Range(refY - height, refY);
        GameObject planet3 = RandomPlanet();
        planet3.transform.position = new Vector2(x3, y3);
        //Area 4
        float x4 = Random.Range(0.0f, width);
        float y4 = Random.Range(refY - height, refY);
        GameObject planet4 = RandomPlanet();
        planet4.transform.position = new Vector2(x4, y4);
    }

    GameObject RandomPlanet()
    {
        if (planets.Count > 0)
        {
            int random;
            if (planets.Count == 1)
            {
                random = 0;
            }
            else
            {
                random = Random.Range(0, planets.Count - 1);
            }

            GameObject planet = planets[random];
            planets.Remove(planet);
            activePlanets.Add(planet);
            return planet;
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                planets.Add(activePlanets[i]);
            }
            activePlanets.RemoveRange(0, 8);
            int random = Random.Range(0, 8);
            GameObject planet = planets[random];
            planets.Remove(planet);
            activePlanets.Add(planet);
            return planet;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGeneration : MonoBehaviour
{
    void Start()
    {
        int seed = UnityEngine.Random.Range(0, 1000000);

        for (float x = -31.5f; x <= 31.5f; x++)
        {
            for (float y = -17.5f; y <= 17.5f; y++)
            {
                float k = Mathf.PerlinNoise((x + seed) / 10f, (y + seed) / 10f);

                if (k > 0.5f)
                {
                    GameObject l = Resources.Load<GameObject>("Prefabs/Red Square") as GameObject;
                    GameObject o = GameObject.Instantiate(l) as GameObject;
                    o.transform.position = new Vector3(x, y, 0f);
                }
            }
        }
    }

    void Update()
    {
        
    }
}
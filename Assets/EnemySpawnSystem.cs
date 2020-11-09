using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.Tilemaps;
using Pathfinding;
using System;

public class EnemySpawnSystem : MonoBehaviour
{
    private GameObject enemy;
    public Transform target;
    public Tilemap tilemap;

    void Start()
    {
        enemy = Resources.Load<GameObject>("Prefabs/Enemy") as GameObject;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            float x = (Input.mousePosition.x / 60f - 16f);
            float y = (Input.mousePosition.y / 60f - 9f);

            Vector3 mousePos = new Vector3(x, y);

            double roundedX = Math.Ceiling(x) - 1;
            double roundedY = Math.Ceiling(y) - 1;

            if (x < 0) {
                roundedX = Math.Floor(x);
            }

            if(y < 0)
            {
                roundedY = Math.Floor(y);
            }

            Vector3Int mousePosInt = new Vector3Int((int) roundedX, (int) roundedY, 0);
            Debug.Log((int) roundedX + ", " + (int) roundedX);

            if (!tilemap.HasTile(mousePosInt))
            {
                GameObject e = GameObject.Instantiate(enemy) as GameObject;
                e.transform.position = mousePos;
                Vector3 v = target.position - mousePos;

                e.transform.up = Vector3.LerpUnclamped(transform.up, target.position, 1);
                e.GetComponent<AIDestinationSetter>().target = target;
            }
        }
    }
}

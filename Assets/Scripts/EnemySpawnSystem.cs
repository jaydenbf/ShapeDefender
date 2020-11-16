using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.Tilemaps;
using Pathfinding;
using System;

public class EnemySpawnSystem : MonoBehaviour
{
    private GameObject eGreenTriange;
    public Tilemap tilemap;

    public float gameTime = 430f;
    public float startTime = 15f;
    private bool startGame = false;

    private float waveElasped = 0f;
    private float waveTimer = 60f;
    private float timeElasped = 0f;

    public float greenTriangleElasped = 4f;
    private float greenTriangleSpawnTime = 4f;

    public GameObject mainBase; 
    void Start()
    {
        eGreenTriange = Resources.Load<GameObject>("Prefabs/Enemy") as GameObject;
    }

    void Update()
    {
        countdownTimer();
        if (gameTime <= 0f)
        {
            // End the game

        }

        // Spawn Enemies when there is more than 10 secs left in the game
        if (startGame && gameTime >= 10f)
        {
            spawnEnemies();
        }
    }

    // Gives player time before the game starts
    private void countdownTimer()
    {
        startTime -= Time.smoothDeltaTime;

        if(startTime <= 0f)
        {
            startGame = true;
        }
    }

    private void spawnEnemies()
    {
        timeElasped = Time.smoothDeltaTime;
        gameTime -= timeElasped;

        greenTriangleElasped -= timeElasped;

        // Spawn Green Enemy Timer
        if(greenTriangleElasped <= 0f)
        {
            spawnGreenEnemy();
            greenTriangleElasped = greenTriangleSpawnTime;
        }

        changeWaveSettings(timeElasped);

        timeElasped = 0f;
    }

    #region EnemySpawn 
    private void spawnGreenEnemy()
    {
        // 15 x 8 cord pos
        GameObject e = GameObject.Instantiate(eGreenTriange) as GameObject;
        mainBase = GameObject.Find("MainBuilding");
        float x = generateValue(10f, 15f);
        float y = generateValue(0f, 9f);


        Vector3 randomSpawnPos = new Vector3(x,y,0); 
        // Random Position
        e.transform.position = randomSpawnPos;

        // Target Position
        Vector3 v = mainBase.transform.position - randomSpawnPos;

        e.transform.up = Vector3.LerpUnclamped(transform.up, mainBase.transform.position, 1);
        e.GetComponent<AIDestinationSetter>().target = mainBase.transform;
    }

    private float generateValue(float min, float max)
    {
        float f = UnityEngine.Random.Range(min, max);
        float n = UnityEngine.Random.Range(-1f, 1f);
        if(n <= 0)
        {
            f *=-1f; 
        }
        return f;
    }

    private void spawnRedEnemy()
    {

    }

    private void spawnBlueEnemy()
    {

    }

    #endregion

    #region Wave Changing
    private void changeWaveSettings(float timeElasped)
    {
        waveElasped += timeElasped;

        if(waveElasped > waveTimer)
        {
            waveTimer += 20f;
            waveElasped = 0f;
            greenTriangleSpawnTime -= .5f;
        }
    }

    #endregion


    #region Spawn System Example
    private void code()
    {
            /*
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
 */
    }
    #endregion
}


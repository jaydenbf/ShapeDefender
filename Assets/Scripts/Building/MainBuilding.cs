﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainBuilding : Building
{
    #region Abstract Global Variables
    private float health;
    private Color defaultColor;
    private float resourceAmount; 

    // Add resource type
    #endregion

    #region Main Base Variables
    // Variables to change later
    private float attackRadius = 10f;
    private float attackDamage = 5f;
    private float attackSpeed = 1f;

    private float maxAttackRadius = 20f;
    private float maxAttackDamage = 20f;
    private float maxAttackSpeed = 5f;

    #endregion

    #region Resource Total
    /*
    * [0] = redCircle, [1] = greenCircle, [2] = blueCircle,
    * [3] = redSquare, [4] = greenSquare, [5] = blueSquare,
    * [6] = redStar, [7] = greenStar, [8] = blueStar
    */
    private float[] allResourceTotal;

    #endregion

    #region Base Connection and Resources
    private GameObject[] connectedBase;
    private float sendingRate = 1f;
    private int healthAmount = 50; 
    #endregion

    #region Projectile variables
    public ProjectileSpawnSystem mProjectileSpawnSystem;
    #endregion

    #region Enemy Spawn List
    public GameObject enemyMain;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        // Eight bases / road connected at one time
        connectedBase = new GameObject[8];
    }

    // Update is called once per frame
    void Update()
    {
        if(healthAmount < 0)
        {
            SceneManager.LoadScene("Loss Screen");
        }
        attackEnemy();
    }


    #region Abstract Methods
    public override void connectBuilding(GameObject build) 
    {
        for (int i = 0; i < connectedBase.Length; i++)
        {
            // Change gameObject.name to enemies name
            if (connectedBase[i].gameObject == null)
            {
                connectedBase[i] = build;
                return;
            }
        }
    }

    public override void disconnectBuilding(GameObject build)
    {
        for (int i = 0; i < connectedBase.Length; i++)
        {
            // Change gameObject.name to enemies name
            if (connectedBase[i].gameObject.name == build.name)
            {
                connectedBase[i] = null;
                return;
            }
        }
    }

    public override void takeDamage(float damage)
    {
        health -= damage;
    }

    public override float getHealth()
    {
        return health;
    }

    public override void receiveResource(float[] recievedResources)
    {
        for (int i = 0; i < 9; i++)
        {
            allResourceTotal[i] += (float)recievedResources[i];
        }
    }

    public override void sendResource()
    {

    }

    public override void resourceHander()
    {

    }

    public override float[] resourceTotal()
    {
        return allResourceTotal;
    }
    #endregion

    #region Attacking Enemy
    private void attackEnemy()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRadius);
        if (enemyMain == null)
        {
            for (int i = 0; i < hitColliders.Length; i++)
            {
                // Change gameObject.name to enemies name
                if (hitColliders[i].gameObject.name == "Triangle")
                {
                    enemyMain = hitColliders[i].gameObject;
                    break;
                }
            }
        }

        if(enemyMain != null)
        {
            damageEnemy(enemyMain.gameObject);
        }

    }

    private void damageEnemy(GameObject enemy)
    {
        if (mProjectileSpawnSystem.CanSpawn())
        {
            mProjectileSpawnSystem.SpawnAnEgg(transform.position, enemy.transform.position);

        }
    }

    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        UnityEngine.Debug.Log(collision.name);
        if (collision.name == "EnemyPro(Clone)")
        {
            healthAmount--;
        }
    }
    #region Update Health Bar



    #endregion
}

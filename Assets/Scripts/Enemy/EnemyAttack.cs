﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private static bool rangeAttack = true; 
    public int hitPoint = 4;
    public float attackRadius = 50f;
    private bool destory = false;
    // Start is called before the first frame update

    #region Projectile Variables
    private GameObject mProjectile = null;
    private float mProjectileInterval = 1f;
    private float mSpawnProjectileAt = 0f;

    #endregion
    void Start()
    {
        mProjectile = Resources.Load<GameObject>("Prefabs/EnemyPro") as GameObject;
        mSpawnProjectileAt = Time.realtimeSinceStartup - mProjectileInterval; // assume one was shot
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("o"))
        {
            rangeAttack = !rangeAttack;
        }

        if (destory)
        {
            Destroy(transform.parent.gameObject);
            return;
        }

        isAlive();
        attack();
    }

    private void attack()
    {
        Vector3 targetPos = GameObject.Find("MainBuilding").transform.position;

        if (rangeAttack)
        {
            if ((targetPos - gameObject.transform.position).magnitude < attackRadius)
            {
                if (CanSpawn())
                {
                    SpawnAnEgg(transform.position, transform.up);
                }
            }
        }
    }

    private void isAlive()
    {
        if(hitPoint <= 0)
        {
            destory = true;
        }
    }

    #region Spawning support
    public bool CanSpawn()
    {
        return TimeTillNext() <= 0f;
    }

    public float TimeTillNext()
    {
        float sinceLastProjectile = Time.realtimeSinceStartup - mSpawnProjectileAt;
        return mProjectileInterval - sinceLastProjectile;
    }

    public void SpawnAnEgg(Vector3 p, Vector3 dir)
    {
        Debug.Assert(CanSpawn());

        GameObject e = GameObject.Instantiate(mProjectile) as GameObject;
        e.transform.position = p;
        e.transform.up = dir;
        mSpawnProjectileAt = Time.realtimeSinceStartup;
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Egg(Clone)")
        {
            hitPoint--;
        }
    }
}

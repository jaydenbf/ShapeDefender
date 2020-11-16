using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public bool rangeAttack; 
    int hitPoint = 4;
    private bool destory = false;
    // Start is called before the first frame update

    #region Projectile Variables
    private GameObject mProjectile = null;
    private float mProjectileInterval = 0.2f;
    private float mSpawnProjectileAt = 0f;

    #endregion
    void Start()
    {
        mProjectile = Resources.Load<GameObject>("Prefabs/Egg") as GameObject;
        mSpawnProjectileAt = Time.realtimeSinceStartup - mProjectileInterval; // assume one was shot
    }

    // Update is called once per frame
    void Update()
    {
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
        if ((targetPos - gameObject.transform.position).magnitude < 10000f)
        {
            if (CanSpawn())
            {
                SpawnAnEgg(transform.position, targetPos);
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

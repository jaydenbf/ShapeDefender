using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnSystem : MonoBehaviour
{
    private GameObject mProjectile = null;
    private float mProjectileInterval = 0.2f;
    private float mSpawnProjectileAt = 0f;
    // Start is called before the first frame update
    void Start()
    {
        mProjectile = Resources.Load<GameObject>("Prefabs/Egg") as GameObject;

        mSpawnProjectileAt = Time.realtimeSinceStartup - mProjectileInterval; // assume one was shot
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Spawning support
    public bool CanSpawn()
    {
        return TimeTillNext() <= 0f;
    }

    public float TimeTillNext()
    {
        float sinceLastProjectile= Time.realtimeSinceStartup - mSpawnProjectileAt;
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
}

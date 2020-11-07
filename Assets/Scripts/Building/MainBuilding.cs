﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private float attackRadius = 200f;
    private float attackDamage = 5f;
    private float attackSpeed = 1f;

    private float maxAttackRadius = 100f;
    private float maxAttackDamage = 20f;
    private float maxAttackSpeed = 5f;

    #endregion

    #region Resource Ammounts
 

    #endregion
    #region Base Connection and Resources
    private GameObject[] connectedBase;

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

    public override void receiveResource()
    {

    }

    public override void sendResource()
    {

    }
    #endregion

    #region Attacking Enemy
    private void attackEnemy()
    {
        // https://docs.unity3d.com/ScriptReference/Physics.OverlapSphere.html
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRadius);
        for(int i = 0; i < hitColliders.Length; i++)
        {
            // Change gameObject.name to enemies name
            if (hitColliders[i].gameObject.name == gameObject.name)
            {
                // Attack Enenmy 
                GameObject enemy = hitColliders[i].gameObject;
                damageEnemy(enemy);
                return;
            }
        }


    }

    private void damageEnemy(GameObject enemy)
    {

    }

    #endregion

    #region Update Health Bar



    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvesterBuilding : Building
{
    #region Abstract Global Variables
    private float health;
    private Color defaultColor;
    // Add resource type
    #endregion

    #region Harvesting Output
    private float rate = 1f;

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
        harvestResource();
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


    #region Harvesting Output Methods
    public void harvestResource()
    {

    }


    #endregion
}

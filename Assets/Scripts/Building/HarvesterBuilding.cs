using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvesterBuilding : Building
{
    #region Abstract Global Variables
    private float health;
    private Color defaultColor;
    int counter;
    // Add resource type
    #endregion

    #region Harvesting Output
    private float miningRate = 1f;
    private float sendingRate = 1f;

    #endregion

    #region ResourceTotal
     /*
     * [0] = redCircle, [1] = greenCircle, [2] = blueCircle,
     * [3] = redSquare, [4] = greenSquare, [5] = blueSquare,
     * [6] = redStar, [7] = greenStar, [8] = blueStar
     */
    private float[] allResourceTotal;
    #endregion


    #region Base Connection and Resources
    private GameObject[] connectedBase;
    private int totalBaseConnectionLimit = 8;
    private Shop shopConnection;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Eight bases / road connected at one time
        connectedBase = new GameObject[totalBaseConnectionLimit];
        shopConnection = GameObject.FindObjectOfType<Shop>();
        
    }

    // Update is called once per frame
    void Update()
    {
        harvestResource();
        checkConnections();
        resourceHander();
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
        if(health < 0f)
        {
            // Send all resources to different building

            // delete this game object
        }
    }

    public override float getHealth()
    {
        return health;
    }

    public override void receiveResource(float [] recievedResources)
    {
        for(int i = 0; i < 9; i++)
        {
            allResourceTotal[i] += (float)recievedResources[i];
        }
    }

    public override void sendResource()
    {
        /*  Connecting building path and send resources to it at a certain rate\
         *  Send to Building System and it will send it to them
         */

        // Evenly Split 

        for(int i = 0; i < totalBaseConnectionLimit; i++)
        {
            if(connectedBase[i] != null)
            {
                // Get the base type

                // Send to game manager

                //
            }
        }

    }

    public override void resourceHander()
    {
        for(int i = 0; i < totalBaseConnectionLimit; i++)
        {
            if(connectedBase[i] != null)
            {
                sendResource();
            }
        }
    }

    public override float[] resourceTotal()
    {
        return allResourceTotal;
    }
    #endregion

    public void checkConnections()
    {
        for(int i = 0; i < totalBaseConnectionLimit; i++)
        {
            if(connectedBase[i] != null && !connectedBase[i].scene.IsValid())
            {
                connectedBase[i] = null;
            }
        }
    }

    #region Harvesting Output Methods
    public void harvestResource()
    {
        if (defaultColor == Color.red)
        {
            counter++;
            if (counter > 1000)
            {
                shopConnection.addRedCircle();
                counter = 0;
            }
        }
        else if (defaultColor == Color.blue)
        {
            counter++;
            if (counter > 1000)
            {
                shopConnection.addBlueCircle();
                counter = 0;
            }
        }
        if (defaultColor == Color.green)
        {
            counter++;
            if (counter > 1000)
            {
                shopConnection.addGreenCircle();
                counter = 0;
            }
        }
    }
    #endregion
}

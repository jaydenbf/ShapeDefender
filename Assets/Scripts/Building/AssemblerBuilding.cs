using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblerBuilding : Building
{
    #region Abstract Global Variables
    private float health;
    private Color defaultColor;
    // Add resource type
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

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        connectedBase = new GameObject[8];
        allResourceTotal = new float[9];
    }

    // Update is called once per frame
    void Update()
    {

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
            allResourceTotal[i] += (float) recievedResources[i];
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
}


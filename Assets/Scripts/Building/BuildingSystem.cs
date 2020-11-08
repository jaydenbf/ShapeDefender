using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuildingSystem : MonoBehaviour
{
    private static MainBuilding mMainBuilding;

    private HarvesterBuilding[] mHarvesterBuilding;
    private int harvesterBuildingTotal = 0;

    private AssemblerBuilding[] mAssemblerBuilding;
    private int assemblerBuildingTotal = 0;

    #region ResourceTotal
    /*
    * [0] = redCircle, [1] = greenCircle, [2] = blueCircle,
    * [3] = redSquare, [4] = greenSquare, [5] = blueSquare,
    * [6] = redStar, [7] = greenStar, [8] = blueStar
    */
    private float[] allResourceTotal;
    #endregion

    // Start is called before the first frame update
    void Awake()
    {
        mHarvesterBuilding = new HarvesterBuilding[100];
        mAssemblerBuilding = new AssemblerBuilding[100];
    }

    // Update is called once per frame
    void Update()
    {
        getResourceTotal();
    }

    private void getResourceTotal()
    {
        float[] newResourceCount = new float[9];

    }

    public void createHarvesterBuilding(Vector3 position)
    {
        harvesterBuildingTotal++;

        // Create object at Vector3

        // Add it to the array
    }

    public void createAssemblerBuilding(Vector3 position)
    {
        assemblerBuildingTotal++;

        // Create object at Vector3

        // Add it to the array
    }

    /*
     * int 0 = main building
     * int 1 = assembler building
     * int 2 = harvester building
     */ 
    public void sendResource(GameObject building, int type)
    {

    }
}

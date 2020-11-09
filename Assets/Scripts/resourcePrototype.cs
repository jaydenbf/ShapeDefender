using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class resourcePrototype : MonoBehaviour
{
    public Tilemap foreground;
    public Text mGameStateEcho = null;
    private Tile[] buildingTiles;
    int red, green, blue;

    // Start is called before the first frame update
    void Start()
    {
        buildingTiles = new Tile[9];
        buildingTiles[0] = (Tile)Resources.Load("Tilesets/Objects/SciFi_Warehouse_D_10");
        buildingTiles[1] = (Tile)Resources.Load("Tilesets/Objects/SciFi_Warehouse_D_11");
        buildingTiles[2] = (Tile)Resources.Load("Tilesets/Objects/SciFi_Warehouse_D_12");
        buildingTiles[3] = (Tile)Resources.Load("Tilesets/Objects/SciFi_Warehouse_D_26");
        buildingTiles[4] = (Tile)Resources.Load("Tilesets/Objects/SciFi_Warehouse_D_27");
        buildingTiles[5] = (Tile)Resources.Load("Tilesets/Objects/SciFi_Warehouse_D_28");
        buildingTiles[6] = (Tile)Resources.Load("Tilesets/Objects/SciFi_Warehouse_A2_60");
        buildingTiles[7] = (Tile)Resources.Load("Tilesets/Objects/SciFi_Warehouse_A2_10");
        buildingTiles[8] = (Tile)Resources.Load("Tilesets/Objects/SciFi_Warehouse_A2_6");
    }

    // Update is called once per frame
    void Update()
    {
        // get mouse's location on the tilemap
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int mouseTile = foreground.WorldToCell(mouseWorldPos);
        TileBase thisTile = foreground.GetTile(mouseTile);

        if (Input.GetKeyDown(KeyCode.B)) // the user wants to place a building
        {
            if (mouseTile.x < -15 || mouseTile.x > 14
                || mouseTile.y > 7 || mouseTile.y < -9)
                return; // the user is trying to place a building outside the bounds

            if (thisTile == null
                && foreground.GetTile(mouseTile + new Vector3Int(1, 0, 0)) == null
                && foreground.GetTile(mouseTile + new Vector3Int(-1, 0, 0)) == null
                && foreground.GetTile(mouseTile + new Vector3Int(1, 1, 0)) == null
                && foreground.GetTile(mouseTile + new Vector3Int(0, 1, 0)) == null
                && foreground.GetTile(mouseTile + new Vector3Int(-1, 1, 0)) == null
                ) // there isn't currently a building or path in the way
            {
                // place them in the correct spots
                foreground.SetTile(mouseTile, buildingTiles[4]);
                foreground.SetTile(mouseTile + new Vector3Int(1, 0, 0), buildingTiles[5]);
                foreground.SetTile(mouseTile + new Vector3Int(-1, 0, 0), buildingTiles[3]);
                foreground.SetTile(mouseTile + new Vector3Int(1, 1, 0), buildingTiles[2]);
                foreground.SetTile(mouseTile + new Vector3Int(0, 1, 0), buildingTiles[1]);
                foreground.SetTile(mouseTile + new Vector3Int(-1, 1, 0), buildingTiles[0]);

                // create new building object
                var building = gameObject.AddComponent<Building>();

                // set location of building
                building.SetLocation(mouseTile);

                // check for nearby resources
                if (foreground.GetTile(mouseTile + new Vector3Int(-2, 2, 0)) == buildingTiles[6]
                    || foreground.GetTile(mouseTile + new Vector3Int(-1, 2, 0)) == buildingTiles[6]
                    || foreground.GetTile(mouseTile + new Vector3Int(0, 2, 0)) == buildingTiles[6]
                    || foreground.GetTile(mouseTile + new Vector3Int(1, 2, 0)) == buildingTiles[6]
                    || foreground.GetTile(mouseTile + new Vector3Int(2, 2, 0)) == buildingTiles[6]
                    || foreground.GetTile(mouseTile + new Vector3Int(-2, 1, 0)) == buildingTiles[6]
                    || foreground.GetTile(mouseTile + new Vector3Int(2, 1, 0)) == buildingTiles[6]
                    || foreground.GetTile(mouseTile + new Vector3Int(-2, 0, 0)) == buildingTiles[6]
                    || foreground.GetTile(mouseTile + new Vector3Int(2, 0, 0)) == buildingTiles[6]
                    || foreground.GetTile(mouseTile + new Vector3Int(-2, -1, 0)) == buildingTiles[6]
                    || foreground.GetTile(mouseTile + new Vector3Int(-1, -1, 0)) == buildingTiles[6]
                    || foreground.GetTile(mouseTile + new Vector3Int(0, -1, 0)) == buildingTiles[6]
                    || foreground.GetTile(mouseTile + new Vector3Int(1, -1, 0)) == buildingTiles[6]
                    || foreground.GetTile(mouseTile + new Vector3Int(2, -1, 0)) == buildingTiles[6])
                {
                    building.SetColor("red");
                }

                if (foreground.GetTile(mouseTile + new Vector3Int(-2, 2, 0)) == buildingTiles[7]
                    || foreground.GetTile(mouseTile + new Vector3Int(-1, 2, 0)) == buildingTiles[7]
                    || foreground.GetTile(mouseTile + new Vector3Int(0, 2, 0)) == buildingTiles[7]
                    || foreground.GetTile(mouseTile + new Vector3Int(1, 2, 0)) == buildingTiles[7]
                    || foreground.GetTile(mouseTile + new Vector3Int(2, 2, 0)) == buildingTiles[7]
                    || foreground.GetTile(mouseTile + new Vector3Int(-2, 1, 0)) == buildingTiles[7]
                    || foreground.GetTile(mouseTile + new Vector3Int(2, 1, 0)) == buildingTiles[7]
                    || foreground.GetTile(mouseTile + new Vector3Int(-2, 0, 0)) == buildingTiles[7]
                    || foreground.GetTile(mouseTile + new Vector3Int(2, 0, 0)) == buildingTiles[7]
                    || foreground.GetTile(mouseTile + new Vector3Int(-2, -1, 0)) == buildingTiles[7]
                    || foreground.GetTile(mouseTile + new Vector3Int(-1, -1, 0)) == buildingTiles[7]
                    || foreground.GetTile(mouseTile + new Vector3Int(0, -1, 0)) == buildingTiles[7]
                    || foreground.GetTile(mouseTile + new Vector3Int(1, -1, 0)) == buildingTiles[7]
                    || foreground.GetTile(mouseTile + new Vector3Int(2, -1, 0)) == buildingTiles[7])
                {
                    building.SetColor("green");
                }

                if (foreground.GetTile(mouseTile + new Vector3Int(-2, 2, 0)) == buildingTiles[8]
                    || foreground.GetTile(mouseTile + new Vector3Int(-1, 2, 0)) == buildingTiles[8]
                    || foreground.GetTile(mouseTile + new Vector3Int(0, 2, 0)) == buildingTiles[8]
                    || foreground.GetTile(mouseTile + new Vector3Int(1, 2, 0)) == buildingTiles[8]
                    || foreground.GetTile(mouseTile + new Vector3Int(2, 2, 0)) == buildingTiles[8]
                    || foreground.GetTile(mouseTile + new Vector3Int(-2, 1, 0)) == buildingTiles[8]
                    || foreground.GetTile(mouseTile + new Vector3Int(2, 1, 0)) == buildingTiles[8]
                    || foreground.GetTile(mouseTile + new Vector3Int(-2, 0, 0)) == buildingTiles[8]
                    || foreground.GetTile(mouseTile + new Vector3Int(2, 0, 0)) == buildingTiles[8]
                    || foreground.GetTile(mouseTile + new Vector3Int(-2, -1, 0)) == buildingTiles[8]
                    || foreground.GetTile(mouseTile + new Vector3Int(-1, -1, 0)) == buildingTiles[8]
                    || foreground.GetTile(mouseTile + new Vector3Int(0, -1, 0)) == buildingTiles[8]
                    || foreground.GetTile(mouseTile + new Vector3Int(1, -1, 0)) == buildingTiles[8]
                    || foreground.GetTile(mouseTile + new Vector3Int(2, -1, 0)) == buildingTiles[8])
                {
                    building.SetColor("blue");
                }
            }
        }
        // update on-screen resources
        mGameStateEcho.text = "Green: " + green + " Red: " + red + " Blue: " + blue;
    }
    public void addBlue()
    {
        blue++;
    }

    public void addRed()
    {
        red++;
    }
    public void addGreen()
    {
        green++;
    }
}

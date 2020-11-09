using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Controller : MonoBehaviour
{
    public Tilemap background;
    public Tilemap foreground;

    private ArrayList curPath;
    private Vector3Int recentPos;

    private Tile[] buildingTiles;
    private Tile[] pathTiles;

    private ArrayList finishedPath;

    private int startSection; // 1=topleft 2=topmid 3=topright 4=bottomleft 5=bottommid 6=bottomright

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Assert(background != null);
        Debug.Assert(foreground != null);

        curPath = new ArrayList();
        finishedPath = new ArrayList();
        recentPos = new Vector3Int(int.MaxValue, int.MaxValue, int.MaxValue);

        // get the correct tiles
        buildingTiles = new Tile[6];
        buildingTiles[0] = (Tile)Resources.Load("Tilesets/Objects/SciFi_Warehouse_D_10");
        buildingTiles[1] = (Tile)Resources.Load("Tilesets/Objects/SciFi_Warehouse_D_11");
        buildingTiles[2] = (Tile)Resources.Load("Tilesets/Objects/SciFi_Warehouse_D_12");
        buildingTiles[3] = (Tile)Resources.Load("Tilesets/Objects/SciFi_Warehouse_D_26");
        buildingTiles[4] = (Tile)Resources.Load("Tilesets/Objects/SciFi_Warehouse_D_27");
        buildingTiles[5] = (Tile)Resources.Load("Tilesets/Objects/SciFi_Warehouse_D_28");

        pathTiles = new Tile[6];
        pathTiles[0] = (Tile)Resources.Load("Tilesets/Objects/path_corner_1");
        pathTiles[1] = (Tile)Resources.Load("Tilesets/Objects/path_corner_2");
        pathTiles[2] = (Tile)Resources.Load("Tilesets/Objects/path_corner_3");
        pathTiles[3] = (Tile)Resources.Load("Tilesets/Objects/path_corner_4");
        pathTiles[4] = (Tile)Resources.Load("Tilesets/Objects/path_corner_5");
        pathTiles[5] = (Tile)Resources.Load("Tilesets/Objects/path_corner_6");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            foreground.ClearAllTiles();
            return;
        }

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
            }
        }
        else if (Input.GetMouseButton(0)) // the user wants to make a path
        {
            if (recentPos == mouseTile)
                return;
            foreach (Vector3Int pos in curPath)
            {
                if (pos == mouseTile)
                {
                    EndPath();
                    return;
                }
            }
            if (curPath.Count == 0) // this is the start
            {
                if (thisTile == null || thisTile.name == "SciFi_Warehouse_A5_94")
                    return;
                curPath.Add(mouseTile);
                recentPos = mouseTile;

                if (thisTile == buildingTiles[0])
                    startSection = 1;
                else if (thisTile == buildingTiles[1])
                    startSection = 2;
                else if (thisTile == buildingTiles[2])
                    startSection = 3;
                else if (thisTile == buildingTiles[3])
                    startSection = 4;
                else if (thisTile == buildingTiles[4])
                    startSection = 5;
                else
                    startSection = 6;

                foreground.SetTile(mouseTile, pathTiles[startSection - 1]);
                return;
            }
            else
            {
                if (recentPos.y == 7) 
                {
                    Debug.Log("TOT");
                }
                if (!(recentPos.x == int.MaxValue || foreground.GetTile(recentPos).name == "SciFi_Warehouse_A5_94"))
                {
                    int section = -1;
                    for (int i = 0; i < buildingTiles.Length; i++)
                    {
                        if (foreground.GetTile(recentPos) == buildingTiles[i] || foreground.GetTile(recentPos) == pathTiles[i])
                            section = i + 1;
                    }

                    TileBase temp = foreground.GetTile(mouseTile);
                    curPath.Add(mouseTile);                    
                    switch (section)
                    {
                        case 1:
                            if (!(mouseTile == recentPos + new Vector3Int(-1, 0, 0) ||
                                mouseTile == recentPos + new Vector3Int(-1, 1, 0) ||
                                mouseTile == recentPos + new Vector3Int(0, 1, 0)))
                            {
                                EndPath();
                                foreground.SetTile(mouseTile, temp);
                                return;
                            }
                            break;

                        case 2:
                            if (!(mouseTile == recentPos + new Vector3Int(0, 1, 0)))
                            {
                                EndPath();
                                foreground.SetTile(mouseTile, temp);
                                return;
                            }
                            break;

                        case 3:
                            if (!(mouseTile == recentPos + new Vector3Int(1, 0, 0) ||
                                mouseTile == recentPos + new Vector3Int(1, 1, 0) ||
                                mouseTile == recentPos + new Vector3Int(0, 1, 0)))
                            {
                                EndPath();
                                foreground.SetTile(mouseTile, temp);
                                return;
                            }
                            break;

                        case 4:
                            if (!(mouseTile == recentPos + new Vector3Int(-1, 0, 0) ||
                                mouseTile == recentPos + new Vector3Int(-1, -1, 0) ||
                                mouseTile == recentPos + new Vector3Int(0, -1, 0)))
                            {
                                EndPath();
                                foreground.SetTile(mouseTile, temp);
                                return;
                            }
                            break;

                        case 5:
                            if (!(mouseTile == recentPos + new Vector3Int(0, -1, 0)))
                            {
                                EndPath();
                                foreground.SetTile(mouseTile, temp);
                                return;
                            }
                            break;

                        case 6:
                            if (!(mouseTile == recentPos + new Vector3Int(1, 0, 0) ||
                                mouseTile == recentPos + new Vector3Int(1, -1, 0) ||
                                mouseTile == recentPos + new Vector3Int(0, -1, 0)))
                            {
                                EndPath();
                                foreground.SetTile(mouseTile, temp);
                                return;
                            }
                            break;
                    }
                }

                // if the target is empty space
                if (thisTile == null)
                {
                    curPath.Add(mouseTile);
                    foreground.SetTile(mouseTile, (Tile)Resources.Load("Tilesets/Backgrounds/SciFi_Warehouse_A5_94"));
                    recentPos = mouseTile;
                    return;
                }

                // if the target is a path
                if (thisTile.name == "SciFi_Warehouse_A5_94")
                {
                    EndPath();
                    return;
                }

                for (int i = 0; i < pathTiles.Length; i++)
                {
                    if (pathTiles[i] == thisTile)
                    {
                        foreground.SetTile(mouseTile, buildingTiles[i]);
                        EndPath();
                        return;
                    }
                    if (buildingTiles[i] == thisTile)
                    {
                        foreground.SetTile(mouseTile, buildingTiles[i]);
                        curPath.Add(mouseTile);
                        foreach (Vector3Int coords in curPath)
                            finishedPath.Add(coords);
                        curPath = new ArrayList();
                        recentPos = new Vector3Int(int.MaxValue, int.MaxValue, int.MaxValue);
                        EndPath();
                        return;
                    }
                }
            }
        }
        else // mouse is let go of
            EndPath();
    }

    private void EndPath()
    {
        if (curPath.Count > 0)
        {
            if (!finishedPath.Contains((Vector3Int)curPath[0]))
                foreground.SetTile((Vector3Int)curPath[0], buildingTiles[startSection - 1]);
            curPath.RemoveAt(0);
        }
        foreach (Vector3Int pos in curPath)
        {
            if (!finishedPath.Contains(pos))
                foreground.SetTile(pos, null);
        }
        curPath = new ArrayList();
    }
}
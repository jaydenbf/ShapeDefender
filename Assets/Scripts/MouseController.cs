﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseController : MonoBehaviour
{
    public Tilemap tilemap;
    private Vector3Int lastClickedTile, thisClickedTile;

    // Start is called before the first frame update
    void Start()
    {

    }
    public Vector3Int getmousePosition()
    {
        return tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    public void firstClickTile()
    {
        // left mouse button is clicked

        // get tile info from mouse location
        thisClickedTile = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        // SELECT THE BUILDING AT CURRENT MOUSE LOCATION thisClickedTile   TODO(GUI)
        Debug.Log("Tile selected at location: (" + thisClickedTile.x + ", " + thisClickedTile.y + ", " + thisClickedTile.z + ")");

        lastClickedTile = thisClickedTile;
    }

    public void secondClickTile()
    {
        thisClickedTile = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (thisClickedTile != lastClickedTile)
        {
            // drag and drop from lastClickedTile to thisClickedTile TODO
            Debug.Log("Drag and drop from (" + lastClickedTile.x + ", " + lastClickedTile.y + ", " + lastClickedTile.z + ")" + " to (" + thisClickedTile.x + ", " + thisClickedTile.y + ", " + thisClickedTile.z + ")");

            lastClickedTile.Set(0, 0, 0);
        }
    }
}
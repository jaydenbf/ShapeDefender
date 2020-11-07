using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameZone : MonoBehaviour
{
    public Tilemap tilemap;

    private Tile[] circles = {null, null, null};

    private const int wsize = 32;
    private const int hsize = 18;
    private const int totalSize = 576;

    // Start is called before the first frame update
    void Start()
    {
        circles[0] = (Tile)Resources.Load("Tilesets/Objects/red_circle", typeof(Tile));
        circles[1] = (Tile)Resources.Load("Tilesets/Objects/green_circle", typeof(Tile));
        circles[2] = (Tile)Resources.Load("Tilesets/Objects/blue_circle", typeof(Tile));

        var baseLevel = tilemap;

        var localTilesPositions = new List<Vector3Int>(totalSize);
        foreach (var pos in baseLevel.cellBounds.allPositionsWithin)
        {
            localTilesPositions.Add(new Vector3Int(pos.x, pos.y, pos.z));
        }

        for (int i = 0; i < 3; i++)
        {
            int toRemove = Random.Range(0, localTilesPositions.Count - 1);
            baseLevel.SetTile(localTilesPositions[toRemove], circles[i]);
            localTilesPositions.RemoveAt(toRemove);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InfiniteTiles : MonoBehaviour
{
    // Start is called before the first frame update

    public int size = 500;

    public Tilemap tilemap;
    public Tile[] tiles;
    public GameObject Player;

    public Tile[] StartTiles;

    void Start()
    {

        for(int x = -size; x < size; x++)
        {
            for(int y = -size; y < size; y++)
            {
                //int randomNumber = Random.Range(0, 3);
                int randomNumber = 0;

                tilemap.SetTile(new Vector3Int(x, y, 0), tiles[randomNumber]);

                randomNumber++;

                if(randomNumber == tiles.Count())
                {
                    randomNumber = 0;
                }
            }
        }

        PutStartTiles();

    }



    void Update()
    {
       
    }

    public void PutStartTiles()
    {
        tilemap.SetTile(new Vector3Int(0, 0, 0), StartTiles[0]);
        tilemap.SetTile(new Vector3Int(-1, 0, 0), StartTiles[0]);
        tilemap.SetTile(new Vector3Int(0, -1, 0), StartTiles[0]);
        tilemap.SetTile(new Vector3Int(-1, -1, 0), StartTiles[0]);

        tilemap.SetTile(new Vector3Int(-2, 1, 0), StartTiles[1]);

        tilemap.SetTile(new Vector3Int(-1, 1, 0), StartTiles[2]);
        tilemap.SetTile(new Vector3Int(0, 1, 0), StartTiles[2]);

        tilemap.SetTile(new Vector3Int(1, 1, 0), StartTiles[3]);

        tilemap.SetTile(new Vector3Int(1, 0, 0), StartTiles[4]);
        tilemap.SetTile(new Vector3Int(1, -1, 0), StartTiles[4]);

        tilemap.SetTile(new Vector3Int(1, -2, 0), StartTiles[5]);

        tilemap.SetTile(new Vector3Int(0, -2, 0), StartTiles[6]);
        tilemap.SetTile(new Vector3Int(-1, -2, 0), StartTiles[6]);

        tilemap.SetTile(new Vector3Int(-2, -2, 0), StartTiles[8]);

        tilemap.SetTile(new Vector3Int(-2, 0, 0), StartTiles[7]); // sukeiciau vietom netycia
        tilemap.SetTile(new Vector3Int(-2, -1, 0), StartTiles[7]);

    }



   
}


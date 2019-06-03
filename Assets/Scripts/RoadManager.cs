using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject RoadTile;
    public float TileLength = 32f;

    private float zOffset;
    private GameObject _player;

    private int _countTiles = 3;

    void Start()
    {
        zOffset = 0f;
        _player = GameObject.FindGameObjectWithTag("Player");

        for (int i = 0; i < _countTiles; i++)
        {
            SpawnRoadTile();
        }
    }
    
    void Update()
    {
        if (_player.transform.position.z > (zOffset - _countTiles * TileLength))
        {
            SpawnRoadTile();
        }
    }

    private void SpawnRoadTile()
    {
        GameObject roadTile = Instantiate(RoadTile) as GameObject;
        roadTile.transform.SetParent(transform);
        roadTile.transform.position = Vector3.forward * zOffset;
        zOffset += TileLength;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

    [SerializeField] private int _width, _height;
 
    [SerializeField] private Tile _tilePrefab;
 
    [SerializeField] private Transform _cam;
 
    public Dictionary<Vector2, Tile> _tiles;
 
    void Start() {
        GenerateGrid();
        //Test();
    }
    [ContextMenu("Generate Grid")]
    void GenerateGrid() {
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++) {
            for (int y = 0; y < _height; y++) {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.transform.SetParent(transform, false);
                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);
 
 
                _tiles[new Vector2(x, y)] = spawnedTile;
                spawnedTile.x = x;
                spawnedTile.y = y;
            }
        }
        _cam.transform.position = new Vector3((float)_width/2 -0.5f, (float)_height / 2 - 0.5f , -10);
    }
    public Tile GetTile(Vector2 pos) {
        
        if (_tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }
    public Tile GetTile(int x, int y){
        return GetTile(new Vector2(x, y));
    }
    public float GetRealDistance(int x0, int y0, int x1, int y1)
    {
        return Vector2.Distance(new Vector2(x0, y0), new Vector2(x1, y1));
    }

    public void Test()
    {
    }
}
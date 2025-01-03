using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChessManager : MonoSingleton<ChessManager>
{

    [SerializeField]
    GridManager _grid;
    
    List<Chess> chessList = new List<Chess>();

    [SerializeField]
    List<GameObject> chessPrefabs;
    

    public GameObject chessPrefab;

    public bool isSettleMode = false;
    
    public void PutChess(GameObject chessGo,int x,int y)
    {
        var chess = chessGo.GetComponent<Chess>();
        _grid.GetTile(x, y).PutChess(chessGo);
        chessList.Add(chess);
        chess.SetPos(x,y);
    }

    public void PutChess(Chess chess, int x,int y)
    {
        PutChess(chess.gameObject, x, y);
    }
    public void PutChessByWorldPos(GameObject chessGo, Vector2 worldPos)
    {
        var tile = GetTileByWorldPos(worldPos);
        tile.PutChess(chessGo);
    }
    public void PutChessByWorldPos(Chess chess, Vector2 worldPos)
    {
        PutChessByWorldPos(chess.gameObject, worldPos);
    }
    //移动棋子
    public void MoveChessTo(Chess chess, int x, int y)
    {
        RemoveChess(chess.x, chess.y);
        var tile = GetTile(x, y);
        tile.PutChess(chess.gameObject); 
    }
        //删除棋子
    public void RemoveChess(int x, int y)
    {
        var tile = GetTile(x, y);
        var chess = tile.GetChess().GetComponent<Chess>();
        tile.RemoveChess();
        chessList.Remove(chess);
        chess.Die();
    }


    public Tile GetTileByWorldPos(Vector3 wolrdPos)
    {
        var hit = Physics2D.OverlapCircle(wolrdPos,0.1f);
        if(hit == null) return null;
        if(hit.TryGetComponent<Tile>(out var tile))
        {
            Debug.Log(tile.name);
            return tile;
        }
        return null;
    }

    public Tile GetTile(int x,int y)
    {
        return _grid.GetTile(x, y);
    }



    
    void Update()
    {
        //Test Only
        if(Input.GetMouseButtonDown(0))
        {
            var tile = GetTileByWorldPos(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if(tile.canPutChess)
            {   
                var chess = Instantiate(chessPrefab);
                PutChess(chess, tile.x, tile.y);
            }
            
        }
    }
}

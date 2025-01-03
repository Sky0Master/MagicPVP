using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Tile : MonoBehaviour {
    GameObject chessGo;
    public int x, y;

    public bool canPutChess{
        get{ return chessGo == null;}
    }
    public void PutChess(GameObject go)
    {
        chessGo = go;
        chessGo.transform.position = transform.position;
        //chessGo.transform.parent = transform;
    }
    public Chess GetChess()
    {
        return chessGo.GetComponent<Chess>();
    }
    public GameObject GetChessGameObject()
    {
        return chessGo;
    }
    public void RemoveChess()
    {
        chessGo = null;
    }

    #region Visual
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;

    public void Init(bool isOffset) {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
        _highlight.SetActive(false);
    }
    
    void OnMouseEnter() {
        _highlight.SetActive(true);
    }
 
    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
    #endregion
}
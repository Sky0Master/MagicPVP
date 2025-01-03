using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour
{
    public int x{get;private set;}
    public int y{ get; private set;}
    public float moveSpeed = 5f;
    Coroutine moveCoroutine;
    public bool isMoving{get; private set;}

    IEnumerator MoveChess(Vector3 fromPos, Vector3 toPos)
    {
        isMoving = true;
        float t = 0;
        var duration = Vector3.Distance(fromPos, toPos) / moveSpeed;
        while(t < duration)
        {
            t += Time.deltaTime;
            yield return null;
        }
        isMoving = false;
        //MoveEnd Event
    }

    public void MoveTo(Vector3 targetPos)
    {   
        moveCoroutine = StartCoroutine(MoveChess(transform.position, targetPos));
    }
    public void Die()
    {
        ChessManager.Instance.RemoveChess(x, y);
    }
    public void SetPos(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

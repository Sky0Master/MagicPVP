using System;
using UnityEngine;
using VinoUtility;
using Mirror;
public class NetSpawner : NetworkBehaviour
{
    public GameObject[] prefabs;
    
    public float interval = 1f;
    public bool isRandom;
    
    public bool isRunning;
    
    public bool asSon = true;
    float _lastGenerateTime;

    [Header("Position")]
    public bool randomOffset;
    public Vector2 range;

    #if UNITY_EDITOR
    private void OnDrawGizmos() {
        if(randomOffset)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireCube(transform.position, range);
        }
    }
    #endif


    int _index = 0;
    
    public Action<GameObject> onGenerate;
    public void StartGenerate()
    {
        isRunning = true;
    }
    public void StopGenerate()
    {
        isRunning = false;
    }
    public void Generate()
    {
        if(isRandom)
        {
            _index = UnityEngine.Random.Range(0, prefabs.Length);
        }
        GameObject obj = NetGameObjectManager.Instance.Create(prefabs[_index]);
        obj.transform.position = transform.position;
        if(asSon)
            obj.transform.SetParent(transform);
    
        if(randomOffset)
        {
            obj.transform.position += new Vector3(
                UnityEngine.Random.Range(-range.x, range.x),
                UnityEngine.Random.Range(-range.y, range.y),
                0);
        }

        _index = (_index + 1) % prefabs.Length;
        onGenerate?.Invoke(obj);

    }
    void Update()
    {
        if(!isRunning)
            return;
        if(Time.time - _lastGenerateTime >= interval)
        {
            Generate();
            _lastGenerateTime = Time.time;
        }
    }
    //DIY
    private void Start() {
        onGenerate += (obj) => {
            //GetComponent<RotateSon2D>().MakeUniform(transform.GetActiveChildren());
        };
    }
}

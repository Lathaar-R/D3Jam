using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public int maxSpawnTime;
    public int minSpawnTime;
    public GameObject clientPrefab;

    public List<GameObject> spawnAreas;

    public List<Vector3> clientPos;

    void Start()
    {
        
    }


    void Update()
    {

    }

    public void StartSpawning()
    {
        InvokeRepeating(nameof(Spawn), Random.Range(minSpawnTime, maxSpawnTime) ,Random.Range(minSpawnTime, maxSpawnTime));
    }

    void Spawn()
    {
        int place = Random.Range(1, 5) * 2;
        Vector3 pos = Vector3.zero;
        // do
        // {
        pos = Vector3.Lerp(spawnAreas[place].transform.position, spawnAreas[place - 1].transform.position, Random.value);
        
        //pos = Vector3Int.RoundToInt(pos);
        Debug.Log(pos);
        // }while(!clientPos.Contains(pos));
        Instantiate<GameObject>(clientPrefab, pos, Quaternion.identity);

        clientPos.Add(pos);
    }

    public void Served()
    {
        
    }
}

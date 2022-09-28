using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject clientPrefab;

    public List<GameObject> spawnAreas;

    public List<GameObject> clients;
    public List<Vector3> clientPos;

    Vector3[] direction = {Vector3.down, Vector3.right, Vector3.up, Vector3.left};

    void Start()
    {
        
    }


    void Update()
    {

    }

    public void StartSpawning()
    {
        InvokeRepeating(nameof(Spawn), DataManager.instance.LevelInfo.timeToSpawnFirstClient , DataManager.instance.LevelInfo.timeToSpawnClients);


    }

    public void StopSpawning()
    {
        CancelInvoke();
    }

    void Spawn()
    {
        Vector3 pos;
        int place;
        do
        {
            place = Random.Range(0, 4) * 2;
            pos = spawnAreas[place].transform.position;
            Vector3 dist = spawnAreas[place + 1].transform.position - spawnAreas[place].transform.position;
            
            pos += dist * Random.value;
            pos = Vector3Int.RoundToInt(pos);
            
        }while(clientPos.Contains(pos));

        var c = Instantiate<GameObject>(clientPrefab, pos, Quaternion.identity);
        c.GetComponent<Client>().dir = direction[place / 2];
        clients.Add(c);

        clientPos.Add(pos);

        if(clients.Count >= DataManager.instance.LevelInfo.numberOfClients)
        {
            StopSpawning();
        }
    }

    public void Served()
    {
        
    }

    public void ResetClients()
    {
        clientPos.Clear();
        clients.Clear();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    PlayerHealth player;
    int _served = 0;
    public GameObject clientPrefab;

    public List<GameObject> spawnAreas;

    public List<GameObject> clients;
    public List<Vector3> clientPos;

    Vector3[] direction = {Vector3.down, Vector3.right, Vector3.up, Vector3.left};



    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    }


    void Update()
    {

    }

    public void StartSpawning()
    {
        Invoke(nameof(Spawn), DataManager.instance.LevelInfo.time[0]);


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
        c.GetComponent<Client>().item = DataManager.instance.LevelInfo.clientOrderItemList[clients.Count];
        
        clients.Add(c);

        if(clients.Count < DataManager.instance.LevelInfo.clients)
            Invoke(nameof(Spawn), DataManager.instance.LevelInfo.time[clients.Count]);

        clientPos.Add(pos);

        if(clients.Count >= DataManager.instance.LevelInfo.clients)
        {
            StopSpawning();
        }
    }

    public void Served(Client client)
    {
        DataManager.instance.AddCoin(client.GetResultCoins());

        clientPos.Remove(client.gameObject.transform.position);
        clients.Remove(client.gameObject);

        _served++;

        if(_served >= DataManager.instance.LevelInfo.clients)
        {
            GameManagerScript.instance.ChangeGameState("finishedLevel");
        }
    }

    public void WrongServed(Client client)
    {
        clientPos.Remove(client.gameObject.transform.position);
        clients.Remove(client.gameObject);

        _served++;

        player.DecreaseHealth();
    }

    public void ResetClients()
    {
        clientPos.Clear();
        clients.Clear();
    }

    
}

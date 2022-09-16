using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public int clientNumber;

    void Start()
    {
        InvokeRepeating("SpawnTimer", 5, 5);
    }


    void Update()
    {

    }
    void SpawnTimer()
    {
        if (clientNumber > 0)
        {
            clientNumber--;
            //Instantiate<Client> (new Client(), new Vector3(-7, 2, 0));
        }
    }
}

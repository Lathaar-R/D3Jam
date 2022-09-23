using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public int clientNumber;
    public GameObject clientDemo;

    void Start()
    {
        InvokeRepeating("SpawnTimer", 1, 5);
    }


    void Update()
    {

    }
    void SpawnTimer()
    {
        if (clientNumber == 0)
        {
            clientNumber++;
            Instantiate<GameObject>(clientDemo, new(-7, 0, 0), Quaternion.identity);
        }
    }

    public void Served()
    {
        clientNumber = 0;
    }
}

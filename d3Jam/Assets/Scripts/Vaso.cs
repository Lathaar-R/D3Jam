using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaso : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3Int.FloorToInt(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

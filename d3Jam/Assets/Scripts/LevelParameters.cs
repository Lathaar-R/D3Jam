using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level Parameters")]
public class LevelParameters : ScriptableObject
{
    public int numberOfClients;
    
    public int timeToSpawnClients;
    public int timeToSpawnFirstClient;

}

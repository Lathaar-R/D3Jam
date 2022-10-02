using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level Parameters")]
public class LevelParameters : ScriptableObject
{
    public int clients;
    public List<int> time;
    public List<Item>  clientOrderItemList;
    public List<Item>  seedsOfLevel;

    
}

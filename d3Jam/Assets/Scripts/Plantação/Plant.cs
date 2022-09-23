using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "d3Jam/Plant", menuName = "Plant")]
public class Plant : ScriptableObject 
{
    public string plantName;

    public Item finishItem;

    public Sprite [] plantSprites;

    //public PlantType plantType;
    
    public List<string> needsToGrow;

    public float growTime;
    public int maxStage;

}

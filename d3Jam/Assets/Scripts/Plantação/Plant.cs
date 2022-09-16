using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "d3Jam/Plant", menuName = "Plant")]
public class Plant : ScriptableObject 
{
    public 
    Sprite [] plantSprites;

    public PlantType plantType;
    
    //public List<EquippableItens> needsToGrow;

    public float growTime;
    public int stage = 0;
    public int maxStage;

}

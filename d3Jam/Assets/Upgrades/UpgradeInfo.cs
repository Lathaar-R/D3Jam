using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeInfo")]
public class UpgradeInfo : ScriptableObject 
{
    public Sprite Upicon; 
    public string upgradeName;
    public int price;
    [TextArea(10, 20)]public string upgradeDescription;

}

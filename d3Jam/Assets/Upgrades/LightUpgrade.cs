using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpgrade : UpgradeSlot
{
    public float newRadius; 

    public override void Upgrade()
    {
        DataManager.instance.lightR += newRadius;
    }
}
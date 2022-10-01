using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilUpgrade : UpgradeSlot
{
    public float soilMult;
    public override void Upgrade()
    {
        if(available)
        {
            available = false;
            DataManager.instance.soilMultiplyer += soilMult;

            Instantiate<GameObject>(visualFeedback);
        }
    }

}
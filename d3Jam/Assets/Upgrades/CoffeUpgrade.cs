using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeUpgrade : UpgradeSlot
{
    public float speedPercent;

    public override void Upgrade()
    {
        DataManager.instance.playerSpeedMulti += speedPercent / 100.0f;
    }
}

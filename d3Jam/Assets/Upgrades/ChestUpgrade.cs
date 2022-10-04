using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestUpgrade : UpgradeSlot
{
    float fasterCoolDown;
    public override void Upgrade()
    {
        DataManager.instance.chestBonus -= fasterCoolDown / 100;
    }
    
}

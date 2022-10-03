using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellUpgrade : UpgradeSlot
{
    public float pegarAguaPorcentagem; 

    public override void Upgrade()
    {
        DataManager.instance.pocoVel -= pegarAguaPorcentagem / 100;
    }
}
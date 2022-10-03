using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncensoUpgrade : UpgradeSlot
{
    public float pacienciaPorcentagem; 

    public override void Upgrade()
    {
        DataManager.instance.paciencia -= pacienciaPorcentagem / 100.0f;
    }
}

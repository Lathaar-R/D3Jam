using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VasosUpgrade : UpgradeSlot
{
    public override void Upgrade()
    {
        GameManagerScript.instance.vasosPos.AddRange(GameManagerScript.instance.extraVasosPos);
    }
}
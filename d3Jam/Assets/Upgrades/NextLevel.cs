using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : UpgradeSlot
{
    public override void Upgrade()
    {
        GameManagerScript.instance.ChangeGameState("play");
    }

}
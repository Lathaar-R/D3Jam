using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradeSlot : MonoBehaviour
{
    public GameObject visualFeedback;
    public bool available = true;
    public ScriptableObject upgradeInfo;
    public abstract void Upgrade();

    private void Start() {
        
    }
}

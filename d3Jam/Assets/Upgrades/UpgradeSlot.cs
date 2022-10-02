using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UpgradeSlot : MonoBehaviour
{
    Image _spriteRenderer;

    public GameObject visualFeedback;
    public bool available = true;
    public UpgradeInfo upgradeInfo;
    public abstract void Upgrade();

    private void Start()
    {
        _spriteRenderer = GetComponent<Image>();

        _spriteRenderer.sprite = upgradeInfo.Upicon;
    }
}

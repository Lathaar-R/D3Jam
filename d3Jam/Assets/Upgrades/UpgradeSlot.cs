using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UpgradeSlot : MonoBehaviour
{
    Image _image;
    public GameObject visualFeedback;
    public bool available = true;
    public UpgradeInfo upgradeInfo;
    public abstract void Upgrade();


    private void Start()
    {
        _image = GetComponentsInChildren<Image>()[1];

        _image.sprite = upgradeInfo.Upicon;

    //     itemImage = GameObject.Find("ItemImage");

    //     itemImage.GetComponentsInChildren<Image>()[1].sprite = 
    }

    internal void TurnOff()
    {
        _image.color = Color.gray;
    }
}

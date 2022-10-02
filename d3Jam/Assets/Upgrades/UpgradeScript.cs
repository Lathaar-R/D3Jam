using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour
{
    public GameObject select;
    public UpgradeSlot[] upgradeSlots;
    public UpgradeInfo[] upgrades;
    public GameObject UpgradeUI;
    public bool open;
    public int slot;
    Image itemImage;
    GameObject itemDescription;

    private void OnEnable()
    {
        Invoke(nameof(AddCallback), 1);
    }

    private void OnDisable()
    {
        GameManagerScript.instance.finishLevelCallback -= OnFinishLevel;
    }

    private void OnFinishLevel()
    {
        OpenUpgrades();
    }

    void Start()
    {
        //UpgradeUI = GameObject.Find("UpgradeParent");

        Invoke(nameof(CloseUpgrades), Time.fixedDeltaTime);

        itemImage = GameObject.Find("ImageOfItem").GetComponent<Image>();
        //itemImage = GameObject.Find("ItemIDescription");

        // upgradeSlots = GetComponentsInChildren<UpgradeSlot>();

        // int i = 0;
        // foreach (var item in upgradeSlots)
        // {
        //     if(i > upgrades.Length)
        //         continue;
            

        //     item.GetComponentsInChildren<Image>()[1].sprite = upgrades[i].Upicon;

        //     i++;
        // }
    }



    // Update is called once per frame
    void Update()
    {
        if(!open) return;

        
        if(Input.GetKeyDown(KeyCode.RightArrow))
            slot++;
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
            slot--; 
        
        slot = Mathf.Clamp(slot, 0, upgradeSlots.Length - 1);

        select.transform.position = upgradeSlots[slot].transform.position;

        //Debug.Log(upgradeSlots.Length);

        itemImage.sprite = upgradeSlots[slot].upgradeInfo.Upicon;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            BuyUpgrade();
        }
    }

    private void BuyUpgrade()
    {
        upgradeSlots[slot].Upgrade();
    }

    void AddCallback()
    {
        GameManagerScript.instance.finishLevelCallback += OnFinishLevel;
        GameManagerScript.instance.changingLevelCallback += OnChangeLevel;
    }

    private void OnChangeLevel()
    {
        CloseUpgrades();
    }

    public void OpenUpgrades()
    {
        open = true;
        UpgradeUI.SetActive(true);
    }
    
    public void CloseUpgrades()
    {
        open = false;
        UpgradeUI.SetActive(false);
    }
}

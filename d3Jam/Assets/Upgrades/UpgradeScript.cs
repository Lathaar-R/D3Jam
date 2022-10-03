using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeScript : MonoBehaviour
{
    public GameObject select;
    public UpgradeSlot[] upgradeSlots;
    public UpgradeInfo[] upgrades;
    public GameObject UpgradeUI;
    public bool open;
    public int slot;
    Image itemImage;
    public TextMeshProUGUI itemDescription;

    public GameObject precoProduto;
    public TextMeshProUGUI preco;

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
        preco.text = upgradeSlots[slot].upgradeInfo.price.ToString("000");
        itemDescription.text = upgradeSlots[slot].upgradeInfo.upgradeDescription;

        if(Input.GetKeyDown(KeyCode.Space) && DataManager.instance.GetCoins() >= upgradeSlots[slot].upgradeInfo.price && upgradeSlots[slot].available)
        {
            BuyUpgrade();
        }
    }

    private void BuyUpgrade()
    {
        upgradeSlots[slot].TurnOff();
        upgradeSlots[slot].available = false;
        DataManager.instance.AddCoin(- upgradeSlots[slot].upgradeInfo.price);
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

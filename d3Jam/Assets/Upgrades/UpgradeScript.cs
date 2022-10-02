using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScript : MonoBehaviour
{
    public GameObject select;
    public UpgradeSlot[] upgrades;
    public GameObject UpgradeUI;
    public bool open;
    public int slot;

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

        upgrades = GetComponentsInChildren<UpgradeSlot>();
    }



    // Update is called once per frame
    void Update()
    {
        if(!open) return;

        
        if(Input.GetKeyDown(KeyCode.RightArrow))
            slot++;
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
            slot--; 
        
        slot = Mathf.Clamp(slot, 0, upgrades.Length - 1);

        select.transform.position = upgrades[slot].transform.position;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            BuyUpgrade();
        }
    }

    private void BuyUpgrade()
    {
        upgrades[slot].Upgrade();
    }

    void AddCallback()
    {
        GameManagerScript.instance.finishLevelCallback += OnFinishLevel;
        GameManagerScript.instance.changingLevelCallback += OnChangeLevel;
        Debug.Log("A");
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

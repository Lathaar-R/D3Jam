using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsScript : MonoBehaviour
{
    GameObject _canvas;



    public Vector3 normalPos;
    public Vector3 upgradePos;

    

    private void OnEnable() {
        
        
    }

    private void OnDisable() {
        DataManager.instance.addCoinCallback -= OnAddCoinCallBack;
        GameManagerScript.instance.finishLevelCallback -= OnFinishLevel;
    }

    private void OnFinishLevel()
    {
        transform.localPosition = upgradePos;
        //transform.localScale = 2 * Vector3.one;

        //transform.SetSiblingIndex(10);
    }

    public void GoBackCoinPos()
    {
        transform.position = normalPos;
    }

    private void OnAddCoinCallBack()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = DataManager.instance.GetCoins().ToString();
    }

    void Start()
    {
        _canvas = GameObject.Find("Canvas");

        DataManager.instance.addCoinCallback += OnAddCoinCallBack;
        GameManagerScript.instance.finishLevelCallback += OnFinishLevel;
        
        normalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

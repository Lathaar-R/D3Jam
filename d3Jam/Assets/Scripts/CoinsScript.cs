using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsScript : MonoBehaviour
{
    GameObject _canvas;
    GameObject _coins;


    private void OnEnable() {
        DataManager.instance.addCoinCallback += OnAddCoinCallBack;
        
    }
    private void OnDisable() {
        DataManager.instance.addCoinCallback -= OnAddCoinCallBack;
    }

    private void OnAddCoinCallBack()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = DataManager.instance.GetCoins().ToString();
    }

    void Start()
    {
        _canvas = GameObject.Find("Canvas");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

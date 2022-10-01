using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsScript : MonoBehaviour
{
    GameObject _canvas;



    Vector3 _normalPos = new(-910, -50);
    Vector3 _upgradePos = new(0, -50);

    

    private void OnEnable() {
        DataManager.instance.addCoinCallback += OnAddCoinCallBack;
        GameManagerScript.instance.finishLevelCallback += OnFinishLevel;
        
    }

    private void OnDisable() {
        DataManager.instance.addCoinCallback -= OnAddCoinCallBack;
        GameManagerScript.instance.finishLevelCallback -= OnFinishLevel;
    }

    private void OnFinishLevel()
    {
        transform.position = _upgradePos;
        transform.localScale = 2 * Vector3.one;
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

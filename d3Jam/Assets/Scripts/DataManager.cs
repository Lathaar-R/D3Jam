using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public Action addCoinCallback;
    private int _coins;
    public static DataManager instance;
    public List<Plant> plantsReferences;
    

    public GameObject coinsObject;

    [SerializeField] int level = 1;
    public LevelParameters LevelInfo
    {
        get{return levels[level - 1];}
    }
    public List<LevelParameters> levels;

    public float soilMultiplyer = 1;

    public int inventorySpace = 6;
    public GameObject inventoryUI;

    public float playerSpeedMulti = 1;

    public float lightR = 1;
    public float paciencia = 1;
    public float pocoVel = 1;

    

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        
    }
    private void OnDisable() {
        GameManagerScript.instance.changingLevelCallback -= GoToNextLevel;
    }

    private void Start() 
    {
        coinsObject = Instantiate<GameObject>(coinsObject, GameObject.Find("Canvas").transform);
        GameManagerScript.instance.changingLevelCallback += GoToNextLevel;
    }

    private void GoToNextLevel()
    {
        level++;
    }

    public int GetCoins()
    {
        return _coins;
    }

    public void AddCoin(int coins)
    {
        _coins += coins;
        addCoinCallback?.Invoke();
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    string gameState;

    public Action endLevelCallback;
    public Action finishLevelCallback;
    public Action changingLevelCallback;
    
    public UpgradeScript _upgradeScript;
    public SpawnerScript spawnerScript;

    public Image fadeOutImage;

    public static GameManagerScript instance;


    //private fields
    List<GameObject> vasos;

    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3[] vasosPos;
    [SerializeField] Light2D globalLight;
    //[SerializeField] GameObject inventoryUI;

    [Header("Criacao do Level")]
    [SerializeField] GameObject _vasoPrefab;

    public List<GameObject> sceneObjects;

    public List<GameObject> _objectsOfScene;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }

        Destroy(gameObject);
    }


    void Start()
    {
        CreateLevel();

        spawnerScript.StartSpawning();

    }

    void Update()
    {
        
    }

    public void ChangeGameState(string state)
    {
        if(state == gameState) return;

        switch (state)
        {
            case "play": 
                        CreateLevel();
                        break;
            case "finishedLevel":
                        FinishLevel();
                        break;
            case "newLevel":
                        ChangeLevel();
                        break;
            
        }
    }

    private void ChangeLevel()
    {
        StartCoroutine(nameof(FadeOut), 3);

        Invoke(nameof(CreateLevel), 4);
    }

    void CreateLevel()
    {
        changingLevelCallback?.Invoke();

        CreateVase();

        InstantiateObjects();
    }

    

    void CreateVase()
    {
        for(int i = 0; i < vasosPos.Length; i++)
        {
            _objectsOfScene.Add(Instantiate<GameObject>(_vasoPrefab, vasosPos[i], Quaternion.identity));
        }
    }

    void InstantiateObjects()
    {
        foreach (var item in sceneObjects)
        {
            _objectsOfScene.Add(Instantiate<GameObject>(item, item.transform.position, Quaternion.identity));
        }
    }

    public IEnumerator FadeOut(int time)
    {
        Color c = Color.black;
        c.a = 0;
        while(c.a < 1)
        {
            c.a += (Time.deltaTime / time);
            fadeOutImage.color = c;
            yield return new WaitForEndOfFrame();
        }

    }
    public IEnumerator FadeIn(int time)
    {
        Color c = Color.black;
        c.a = 1;
        while(fadeOutImage.color.a > 0)
        {
            c.a -= (Time.deltaTime / time);
            fadeOutImage.color = c;
            yield return new WaitForEndOfFrame();
        }
    }

    public void FinishLevel()
    {
        PlayerMovment.freePlayer = false;

        StartCoroutine(nameof(FadeOut), 5);    
        
        Invoke(nameof(DestroyAll), 6);

        Invoke(nameof(GoToUpgrades), 6);

        
    }

    void GoToUpgrades()
    {
        StartCoroutine(nameof(FadeIn), 2);

        finishLevelCallback?.Invoke();
    }

    void DestroyAll()
    {
        Debug.Log("Destroy");
        foreach (var obj in _objectsOfScene)
        {
            Destroy(obj);
        }
    }
    
}

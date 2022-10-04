using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    int level = 1;
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
    public List<Vector3> vasosPos;
    public List<Vector3> extraVasosPos;

    [SerializeField] Light2D globalLight;
    //[SerializeField] GameObject inventoryUI;

    [Header("Criacao do Level")]
    [SerializeField] GameObject _vasoPrefab;

    public List<GameObject> sceneObjects;

    public List<GameObject> objectsOfScene;

    public AudioSource gameMusic;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            
            return;
        }

        Destroy(gameObject);
    }


    void Start()
    {
        ChangeGameState("play");
        StartCoroutine(nameof(FadeIn), 2);

        //gameMusic.lo
    }

    void StartGame()
    {
        
    }

    void Update()
    {
        
    }

    public void ChangeGameState(string state)
    {
        if(state == gameState) return;

        gameState = state;
        switch (state)
        {
            case "play": 
                        CreateLevel();
                        spawnerScript.StartSpawning();

                        break;
            case "finishedLevel":
                        FinishLevel();
                        spawnerScript.ResetClients();
                        break;
            case "newLevel":
                        ChangeLevel();
                        break;
            case "GameOver":
                        GameOver();
                        break;
            
        }
    }

    private void GameOver()
    {
        PlayerMovment.freePlayer = false;

        StartCoroutine(nameof(FadeOut), 5);

        Invoke(nameof(GoBackToMenu), 7);
    }

    private void GoBackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void ChangeLevel()
    {
        StartCoroutine(nameof(FadeOut), 3);


        Invoke(nameof(ChangeToPlay), 4);
        
    }

    void ChangeToPlay()
    {
        changingLevelCallback?.Invoke();
        StartCoroutine(nameof(FadeIn), 4);
        ChangeGameState("play");

        DataManager.instance.coinsObject.transform.position = new(-778.5f, 447.5f);
    }

    void CreateLevel()
    {
        CreateVase();

        InstantiateObjects();
    }

    

    void CreateVase()
    {
        for(int i = 0; i < vasosPos.Count; i++)
        {
            objectsOfScene.Add(Instantiate<GameObject>(_vasoPrefab, vasosPos[i], Quaternion.identity));
        }
    }

    void InstantiateObjects()
    {
        foreach (var item in sceneObjects)
        {
            objectsOfScene.Add(Instantiate<GameObject>(item, item.transform.position, Quaternion.identity));
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

        if(level > DataManager.instance.levels.Count)
        {
            SceneManager.LoadScene("FinishScene");
        }
        else
        {
            Invoke(nameof(GoToUpgrades), 6);
        }

        level++;

        
    }

    void GoToUpgrades()
    {
        StartCoroutine(nameof(FadeIn), 2);

        finishLevelCallback?.Invoke();
    }

    void DestroyAll()
    {
        Debug.Log("Destroy");
        foreach (var obj in objectsOfScene)
        {
            Destroy(obj);
            
        }
        objectsOfScene.Clear();
        
    }
    
}

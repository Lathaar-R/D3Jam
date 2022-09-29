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

    

    public SpawnerScript spawnerScript;

    public Image fadeOutImage;

    public static GameManagerScript instance;

    public float fadeToBlackTime;
    public float deactivateUIsTime;


    //private fields
    List<GameObject> vasos;

    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3[] vasosPos;
    [SerializeField] Light2D globalLight;
    //[SerializeField] GameObject inventoryUI;

    [Header("Criacao do Level")]
    [SerializeField] GameObject _vasoPrefab;
    [SerializeField] Vector3 _inicialPlayerPos;
    [SerializeField] Vector3 _inicialLightPos;
    [SerializeField] List<GameObject> _sceneObjects;

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

    void ChangeGameState(string state)
    {
        if(state == gameState) return;

        switch (state)
        {
            case "play": 
                        CreateLevel();
                        break;
            
        }
    }

    void CreateLevel()
    {
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
        foreach (var item in _sceneObjects)
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
            Debug.Log("Fade");

            c.a += fadeToBlackTime * (Time.deltaTime / time);
            fadeOutImage.color = c;
            yield return new WaitForEndOfFrame();
        }

    }
    public IEnumerator FadeIn(int time)
    {
        Color c = Color.black;
        c.a = 255;
        while(fadeOutImage.color.a > 0)
        {
            c.a -= fadeToBlackTime * Time.deltaTime;
            fadeOutImage.color = c;
            yield return new WaitForEndOfFrame();
        }
    }
        

    public void EndLevel()
    {
        PlayerMovment.freePlayer = false;
        StartCoroutine(nameof(FadeOut), 5);
        
        
        Invoke(nameof(DestroyAll), 5);
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public Image fadeOutImage;

    public static GameManagerScript instance;

    public float fadeToBlackTime;
    public float deactivateUIsTime;


    //private fields
    private int _coins;
    GameObject vasoPrefab;
    List<GameObject> vasos;

    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3[] vasosPos;
    [SerializeField] Light2D globalLight;
    //[SerializeField] GameObject inventoryUI;

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
        

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(nameof(RestartLevel));
        }
    }

    public int getCoins()
    {
        return _coins;
    }

    public IEnumerator RestartLevel()
    {
        Color c = Color.black;
        c.a = 0;
        while(fadeOutImage.color.a < 255)
        {
            c.a += fadeToBlackTime * Time.deltaTime;
            fadeOutImage.color = c;
            yield return new WaitForSecondsRealtime(deactivateUIsTime);
        }

        // while (globalLight.intensity > 0)
        // {
        //     globalLight.intensity -= fadeToBlackTime * Time.deltaTime;

        //     yield return new WaitForEndOfFrame();
        // }

        SceneManager.LoadScene("BaseScene", LoadSceneMode.Single);
    }

    public void BuildVasos()
    {
        foreach (var pos in vasosPos)
        {
            vasos.Add(Instantiate<GameObject>(vasoPrefab, pos, Quaternion.identity));
        }
    }

    public void ActivateUIs()
    {
        
    }

    
}

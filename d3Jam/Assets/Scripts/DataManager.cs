using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    
    public static DataManager instance;
    public List<Plant> plantsReferences;

    [SerializeField] int level = 1;
    public LevelParameters LevelInfo
    {
        get{return levels[level - 1];}
    }
    public List<LevelParameters> levels;

    

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    

}

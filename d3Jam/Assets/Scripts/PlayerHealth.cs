using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public List<GameObject> hearts;
    public GameObject healthbar;
    public GameObject heart;

    public void DecreaseHealth()
    {
        health--;

        var h = hearts[0];
        hearts.Remove(h);
        Destroy(h);

        if (health <= 0)
        {
            GameManagerScript.instance.ChangeGameState("GameOver");
        }
    }

    private void OnDestroy()
    {
        Destroy(healthbar);
    }

    void Start()
    {
        healthbar = Instantiate(healthbar, GameObject.Find("Canvas").transform);
        Debug.Log(healthbar.transform);
        hearts.Add(Instantiate(heart, healthbar.transform));
        hearts.Add(Instantiate(heart, healthbar.transform));
        hearts.Add(Instantiate(heart, healthbar.transform));

    }

    
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    static GameObject help;
    bool open;
    void Start()
    {
        if(help)
        {

        }
        else
        {
        help = GameObject.Find("Help");
        help.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            help.SetActive(!help.activeSelf);
        }
    }

    private void OnDestroy() {
        if(help)
            help.SetActive(false);
    }
}

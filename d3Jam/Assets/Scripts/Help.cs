using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    GameObject help;
    bool open;
    void Start()
    {
        help = GameObject.Find("Help");
        help.SetActive(false);
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

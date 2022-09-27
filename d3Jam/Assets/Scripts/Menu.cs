using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string gameScene;
    [SerializeField] private string creditsScene;

    public void PlayGame(){
        OpenScene(gameScene);
    }

    public void Credits(){
        OpenScene(creditsScene);
    }

    public void Quit(){
        Application.Quit();
    }

    void OpenScene(string sceneToLoad){
        SceneManager.LoadScene(sceneToLoad);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstPage : MonoBehaviour
{
    public void OnPlayButton(){
        SceneManager.LoadScene(2);
    }
    public void OnQuitButton(){
        Application.Quit();
    }
    public void OnSettingsButton(){
        SceneManager.LoadScene(1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToLevelsMenu : MonoBehaviour
{
    public void OnBackClick(){
        SceneManager.LoadScene(2);
    }
}
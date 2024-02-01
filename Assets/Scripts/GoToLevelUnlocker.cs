using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevelUnlocker : MonoBehaviour
{
    public void OnLevelClick(){
        SceneManager.LoadScene(4);
    }
}

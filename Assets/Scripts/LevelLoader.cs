using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }


    public void Load(int num){
        LevelResultStatic.Level = num;
        Debug.Log($"Level is {LevelResultStatic.Level}");
        SceneManager.LoadScene("Level"+num.ToString());
    }
}

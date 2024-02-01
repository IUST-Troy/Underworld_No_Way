using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Button[] levelButtons;
    void Start()
    {
        PlayerPrefs.SetInt("Level1",1);

        for (int i = 2; i <= levelButtons.Length; i++)
        {
            if (PlayerPrefs.GetInt("Level"+ i.ToString()) == 1)
            {
                UnlockLevel(i);
            }
            else{
                levelButtons[i-1].interactable = false;
                levelButtons[i-1].GetComponent<Image>().color = Color.black;
            }
        }
    }

    private void UnlockLevel(int Level)
    {
        PlayerPrefs.SetInt("Level" + Level.ToString(), 1 );
        levelButtons[Level -1].interactable = true;
        levelButtons[Level-1].GetComponent<Image>().color = Color.white;
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}

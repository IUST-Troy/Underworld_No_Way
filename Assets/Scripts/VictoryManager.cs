using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    public TMP_Text Label;
    public TMP_Text Prize;
    public TMP_Text FirstTime;
    private int level;
    private int reward;
    // Start is called before the first frame update
    void Start()
    {
        int currentMoney = PlayerPrefs.GetInt("Coins");
        level = LevelResultStatic.Level;
        reward = 100 * level;
        Label.text = $"Level {level} cleared";
        Prize.text = $"Prize: {reward}";
        currentMoney += reward;
        if (PlayerPrefs.GetInt("Level"+(level+1).ToString()) != 1) //first time
        {
            FirstTime.text = $"First Time Prize: {reward * 3}";
            currentMoney += reward*3;
            if (level != 10)
            {
                PlayerPrefs.SetInt("Level"+(level+1).ToString(),1);
            }
        }
        else{
            FirstTime.text = "";
        }
        PlayerPrefs.SetInt("Coins",currentMoney);
    }

    
}

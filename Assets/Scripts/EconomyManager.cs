using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class EconomyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text coinsText;
    private int currentCoins;
    void Start()
    {
        Debug.Log("Here");
        if (PlayerPrefs.HasKey("Coins") == false)
        {
            PlayerPrefs.SetInt("Coins",0);
        }
        if (PlayerPrefs.HasKey("Attack") == false)
        {
            Debug.Log("Hereeeee");
            PlayerPrefs.SetInt("Attack" , 1);
            PlayerPrefs.SetInt("HP" , 1);
            PlayerPrefs.SetFloat("AMP" , 1f);
            Debug.Log(PlayerPrefs.GetFloat("AMP"));
            PlayerPrefs.SetFloat("HPMultiplier" , 1f);
            PlayerPrefs.Save();
        }
        currentCoins = PlayerPrefs.GetInt("Coins");
        UpdateCoins();
    }

    private void UpdateCoins()
    {
        if (coinsText != null)
        {
            coinsText.text = currentCoins.ToString();
        }
    }

    // Update is called once per frame
    // void Update()
    // {

    // }
}

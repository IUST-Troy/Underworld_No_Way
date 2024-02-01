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
        if (PlayerPrefs.HasKey("Coins") == false)
        {
            PlayerPrefs.SetInt("Coins",0);
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

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateManager : MonoBehaviour
{
    public TMP_Text currentMoneyText;
    public TMP_Text currentAttackText;
    public TMP_Text currentHPText;
    public TMP_Text nextAttackText;
    public TMP_Text nextHPText;
    public TMP_Text AttackPriceText;
    public TMP_Text HPPriceText;
    public Button AttackButton;
    public Button HPButton;
    private int currentMoney;
    private float currentAttack;
    private float currentHP;
    private float nextAttack;
    private float nextHP;
    private int AttackPrice;
    private int HPPrice;
    void Start()
    {
        currentMoney = PlayerPrefs.GetInt("Coins");
        currentAttack = PlayerPrefs.GetFloat("AMP");
        currentHP = PlayerPrefs.GetFloat("HPMultiplier");
        nextAttack = currentAttack + (float)0.1;
        nextHP = currentHP + (float)0.1;
        AttackPrice = 100 * PlayerPrefs.GetInt("Attack");
        HPPrice = 100 * PlayerPrefs.GetInt("HP");
        UpdateUI();
    }

    public void UpgradeAttack(){
        currentMoney -= AttackPrice;
        PlayerPrefs.SetInt("Coins",currentMoney);
        int atk = PlayerPrefs.GetInt("Attack");
        atk++;
        PlayerPrefs.SetInt("Attack",atk);
        AttackPrice = 100 * atk;
        currentAttack += (float)0.1;
        PlayerPrefs.SetFloat("AMP",currentAttack);
        nextAttack += (float)0.1;
        UpdateUI();
    }
    public void UpgradeHP(){
        currentMoney -= HPPrice;
        PlayerPrefs.SetInt("Coins",currentMoney);
        int hp = PlayerPrefs.GetInt("HP");
        hp++;
        PlayerPrefs.SetInt("HP",hp);
        HPPrice = 100 * hp;
        currentHP += (float)0.1;
        PlayerPrefs.SetFloat("HPMultiplier",currentHP);
        nextHP += (float)0.1;
        UpdateUI();
    }
    private void UpdateUI()
    {
        currentMoneyText.text = currentMoney.ToString();
        currentAttackText.text = "x"+currentAttack.ToString();
        currentHPText.text = "x"+currentHP.ToString();
        nextAttackText.text = "x"+nextAttack.ToString();
        nextHPText.text = "x"+nextHP.ToString();
        AttackPriceText.text = AttackPrice.ToString();
        HPPriceText.text = HPPrice.ToString();
        AttackButton.interactable = AttackPrice <= currentMoney;
        HPButton.interactable = HPPrice <= currentMoney;
    }

    // Update is called once per frame
    
}

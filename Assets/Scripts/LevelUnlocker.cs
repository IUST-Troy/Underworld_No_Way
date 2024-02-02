using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlocker : MonoBehaviour
{
    public int level;
    public void OnUnlockClick(){
        PlayerPrefs.SetInt("Level"+level.ToString() , 1);
    }
}

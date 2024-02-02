using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeavyAttackButton : MonoBehaviour
{
    public PlayerCombat playerCombat;

    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();

        button.onClick.AddListener(() => playerCombat.HeavyAttack());
    }
}

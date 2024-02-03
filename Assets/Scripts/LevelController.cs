using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public EnemyHealth[] Enemies;
    public PlayerHealth Player;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if(Player.currentHealth <= 0){
            SceneManager.LoadScene("Defeat");
        }
        var sum = Enemies.Sum(x => x.currentHealth);
        if (!(sum > 0))
        {
            SceneManager.LoadScene("Victory");
        }
    }
}

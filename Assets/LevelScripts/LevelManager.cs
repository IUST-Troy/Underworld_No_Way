//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class LevelManager : MonoBehaviour
//{
//    private bool isLevelCleared = false;
//    public Enemy[] enemies;
//    // Start is called before the first frame update
//    void Start()
//    {
//        isLevelCleared = false;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (!isLevelCleared && AreAllEnemiesDefeated())
//        {
//            // Level is cleared
//            isLevelCleared = true;
//            //show level is complete and next level
//        }
//    }

//    private bool AreAllEnemiesDefeated()
//    {
//        // Check if all enemies in the scene are defeated
//        foreach (Enemy enemy in enemies)
//        {
//            if (enemy.IsAlive)
//            {
//                return false;
//            }
//        }
//        return true;
//    }

    


//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerForStrongerEnemies : MonoBehaviour
{

    public static float TimerUntilUpgrade = 70f;
    public static float EnemyCurrentLevel = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimerUntilUpgrade -= Time.deltaTime;
        
        if(TimerUntilUpgrade <= 0)
        {
            EnemyCurrentLevel++;
            EnemyHealth.SetLevel(EnemyCurrentLevel);
            TimerUntilUpgrade = 60f;
        }


        if(EnemyCurrentLevel > 2)
        {
            EnemySpawning.SpawnDelay = 0.33f;
        }
    }
}

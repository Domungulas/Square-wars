using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using Unity.VisualScripting;

public class EnemySpawning : MonoBehaviour
{
    //variables for
    public static float SpawnDelay = 0.85f;
    public float CurrentDelay;

    public static int EnemiesToSpawn = 2;

    public float SpawnDistanceFromPlayer = 25; 

    public Transform Playerpos;

    public GameObject enemy;
    void Start()
    {
        CurrentDelay = SpawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentDelay -= Time.deltaTime;

        

        if (CurrentDelay <= 0) 
        {
            for (int i = 0; i < EnemiesToSpawn;i++) {
                float randomangle = UnityEngine.Random.Range(0, (float)(2 * Math.PI));

                //Vector3 Spawnpos = Playerpos;

                Vector3 Spawnpos = new Vector3((float)(Playerpos.position.x + Math.Sin(randomangle) * SpawnDistanceFromPlayer), (float)(Playerpos.position.y + Math.Cos(randomangle) * SpawnDistanceFromPlayer), 0);

                Instantiate(enemy, Spawnpos, Quaternion.identity);
                CurrentDelay = SpawnDelay;
            }
        }

    }

    public void SetVariables(float spawndelay, int enemiestospawn)
    {
        SpawnDelay = spawndelay;
        EnemiesToSpawn = enemiestospawn;
    }
}

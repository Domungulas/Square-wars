using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class TimerForBoss : MonoBehaviour
{
    // Start is called before the first frame update

    int TimerMin = 3; 
    float TimerSec = 0;
    public TextMeshProUGUI TimerText;

    GameObject player;
    public GameObject boss;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        TimerSec -= Time.deltaTime;

        if (TimerMin == 0 & Math.Floor(TimerSec) == 0)
        {
            TimerText = GetComponent<TextMeshProUGUI>();
            SpawnBoss();
            TimerText.enabled = false;
            GetComponent<TimerForBoss>().enabled = false;
        }

        if (TimerSec <= 0) 
        {
            TimerMin--;
            TimerSec = 60;
            
        }
        
        TimerText.text = string.Format("{0:00}:{1:00}", TimerMin, Math.Floor(TimerSec));
    }

    void SpawnBoss()
    {
        Vector3 bossSpawnPos = new Vector3(player.transform.position.x,player.transform.position.y - 20,0);
        Instantiate(boss, bossSpawnPos, Quaternion.identity);
    }
}

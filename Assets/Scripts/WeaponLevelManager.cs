using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using System;

public class WeaponLevelManager : MonoBehaviour
{
    Button button1;
    Button button2;
    Button button3;

    TextMeshProUGUI text1;
    TextMeshProUGUI text2;
    TextMeshProUGUI text3;

    TextMeshProUGUI info1;
    TextMeshProUGUI info2;
    TextMeshProUGUI info3;

    Canvas upgradeScreenCanvas;

    public static double lvlPellet;
    public static double lvlRocket;
    public static double lvlShuriken;

    public float xpThatEnemiesGive = 0.05f;

    public static double lvlGlobal;

    public GameObject bandana;


    void Start()
    {
        lvlPellet = 1;
        lvlRocket = 0;
        lvlShuriken = 0;
        lvlGlobal = lvlPellet + lvlRocket + lvlShuriken;   

        button1 = GameObject.Find("Choice1").GetComponent<Button>();
        //button1.onClick.AddListener(choice1);
        text1 = GameObject.Find("Text1").GetComponent<TextMeshProUGUI>();
        info1 = GameObject.Find("Info1").GetComponent<TextMeshProUGUI>();

        button2 = GameObject.Find("Choice2").GetComponent<Button>(); 
        //button2.onClick.AddListener(choice2);
        text2 = GameObject.Find("Text2").GetComponent<TextMeshProUGUI>();
        info2 = GameObject.Find("Info2").GetComponent<TextMeshProUGUI>();

        button3 = GameObject.Find("Choice3").GetComponent<Button>();
        //button3.onClick.AddListener(choice3);
        text3 = GameObject.Find("Text3").GetComponent<TextMeshProUGUI>();
        info3 = GameObject.Find("Info3").GetComponent<TextMeshProUGUI>();


        upgradeScreenCanvas = GameObject.Find("UpgradeScreenCanvas").GetComponent<Canvas>();

        UpdateText();

        upgradeScreenCanvas.enabled = false;

        EnemyHealth.xpAmount = xpThatEnemiesGive;

    }


    public void choice1()
    {
        if (!Input.GetKey("space"))
        {
            lvlPellet += 1;
            UpdateText();
            TurnOffCanvas();
            Debug.Log("Clicked 1");
        }
        
    }

    public void choice2()
    {
        if (!Input.GetKey("space"))
        {
            lvlRocket += 1;
            UpdateText();
            TurnOffCanvas();
            Debug.Log("Clicked 2");
        }
    }

    public void choice3()
    {
        if (!Input.GetKey("space"))
        {
            lvlShuriken += 1;
            UpdateText();
            TurnOffCanvas();
            Debug.Log("Clicked 3");

            if (lvlShuriken >= 5)
            {
                bandana.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    void TurnOffCanvas()
    {
        Time.timeScale = 1;
        upgradeScreenCanvas.enabled = false;
    }

    public void TurnOnCanvas()
    {
        Time.timeScale = 0;
        Debug.Log("Screen activated");
        upgradeScreenCanvas.enabled = true;
    }

    public void UpdateText()
    {
        lvlGlobal = lvlPellet + lvlRocket + lvlShuriken;

        if (lvlPellet >= 5)
        {
            text1.text = string.Format("Lvl {0}", lvlPellet);
            info1.text = info1_desc[6];
        }
        else
        {
            text1.text = string.Format("Lvl {0}", lvlPellet);
            info1.text = info1_desc[(int)lvlPellet];
        }

        if (lvlRocket >= 5)
        {
            text2.text = string.Format("Lvl {0}", "max");
            button2.enabled = false;

            info2.text = info2_desc[6];
        }
        else
        {
            text2.text = string.Format("Lvl {0}", lvlRocket);
            info2.text = info2_desc[ (int)lvlRocket + 1];
        }

        if (lvlShuriken >= 5)
        {
            text3.text = string.Format("Lvl {0}", "max");
            button3.enabled = false;
            info3.text = info3_desc[6];
        }
        else
        {
            text3.text = string.Format("Lvl {0}", lvlShuriken);
            info3.text = info3_desc[(int)lvlShuriken + 1];
        }

        GameObject.Find("Player").GetComponent<Shooting>().UpdateLevels(lvlPellet, lvlRocket, lvlShuriken);
        EnemyHealth.xpAmount = EnemyHealth.xpAmount * 0.9f;
    }



    string[] info1_desc =
    {
        "",
        "-Increase damage and pellet speed",
        "-Increase damage and shoot speed",
        "-Increase pellet speed and shoot speed",
        "-Increase pellet speed and shoot speed",
        "-Increase pellet shoot speed",
        "-A bit faster shooting rate \n-A bit more damage"
    };

    string[] info2_desc =
    {
        "",
        "-A rocket launcher that shoots in all 4 directions",
        "-Bigger explosion radius",
        "-Faster shooting rate",
        "-More damage",
        "-Nuke explosion radius",
        ""
    };

    string[] info3_desc =
    {
        "",
        "-A shuriken that flies around you",
        "-Extra shuriken",
        "-Extra shuriken",
        "-Extra shuriken",
        "-You get a cool bandana \n-The shurikens spin faster",
        ""
    };



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    // Start is called before the first frame update
    
    WeaponLevelManager levelmanager;

    float xp = 0;


    private Image xpbar;
    void Start()
    {
        xpbar = GetComponent<Image>();

        levelmanager = GameObject.FindObjectOfType<WeaponLevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

        
        xpbar.fillAmount = xp;

        if(xp > 1)
        {
            xp -= 1;
            levelmanager.TurnOnCanvas();
        }

    }

    public void GetXP(float xpcount)
    {
        xp += xpcount;
    }

}

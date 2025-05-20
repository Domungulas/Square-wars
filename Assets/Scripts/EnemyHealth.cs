using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyHealth : MonoBehaviour
{
    public static float SpawnHealth = 10;

    public float health = 1;
    public float bossScale; // for boss

    public static float BossRunawayHP = 600;
    public static float BossFightHP = 1000;

    public static float xpAmount = 0.05f; 

    XPBar forxp;

    public void TakeDamage(int damage) 
    { 
        health -= damage;

        if (this.gameObject.name == "Boss(Clone)")
        {
            UpdateScale();

            if (health <= BossRunawayHP)
            {
                BossStuff.runaway = true;
            }
            else if (health >= BossFightHP)
            {
                BossStuff.runaway = false;
            }


            if (health <= 0)
            {
                if(this.gameObject.name == "Boss(Clone)")
                {
                    SceneManager.LoadScene("TitleScreen");
                }

                Destroy(this.gameObject);
            }
        }

        if (health <= 0)
        {

            Destroy(gameObject);
            forxp.GetXP(xpAmount);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        forxp = GameObject.FindGameObjectWithTag("XPBar").GetComponent<XPBar>();

        health = SpawnHealth;


        if (this.gameObject.name == "Boss(Clone)")
        {
            health = 2000;
            bossScale = this.gameObject.transform.localScale.x;
            UpdateScale();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" & this.gameObject.name == "Boss(Clone)")
        {
            Destroy(collision.gameObject);
            health += 20;
            UpdateScale();

            if (health <= BossRunawayHP)
            {
                BossStuff.runaway = true;
            }
            else if(health >= BossFightHP)
            {
                BossStuff.runaway = false;
            }
        }


    }
    public void UpdateScale()
    {
        if (health >= 300)
        {
            bossScale = health / 300;
            this.gameObject.transform.localScale = new Vector3(bossScale, bossScale, 0);
        }
    }

    public static void SetLevel(float level)
    { 
        SpawnHealth = 10 + level * 5;
    }

    public float GetHealth()
    {
        return this.health;
    }

    
}

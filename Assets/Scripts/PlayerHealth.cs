using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public float health = 100f;
    private Image HealthBar;

    public double HitCooldown = 0.5f;

    private GameObject blink;

    void Start()
    {
        HealthBar = GameObject.Find("HealthBarGreen").GetComponent<Image>();
        blink = GameObject.Find("PlayerBlink");
        blink.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (HitCooldown > -1)
        {
            HitCooldown -= Time.deltaTime;
        }
        else
        {

        }
    }

    public void TakeDamage(int damage) 
    {
        if (HitCooldown <= 0)
        {
            health -= damage;
            //IsDead();

            HealthBar.fillAmount = 0.5f;
            HealthBar.fillAmount = (float)(health / 100);

            Invoke("EnableBlink", 0f);
            Invoke("DisableBlink", 0.1f);

            HitCooldown = 0.5f;
        }
    }

    public bool IsDead()
    {
        if(health <= 0)
        {
            Die();
            return true;
        }

        return false;
    }

    public void Die()
    {
        //SceneManager.LoadScene("TitleScreen");

        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }

        this.health = 100;

        this.transform.position = new Vector3(0f,0f,0f);

    }

    private void EnableBlink()
    {
        blink.SetActive (true);
    }
    private void DisableBlink()
    {
        blink.SetActive(false);
    }
}

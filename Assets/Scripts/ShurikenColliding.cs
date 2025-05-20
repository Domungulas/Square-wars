using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShurikenColliding : MonoBehaviour
{
    public GameObject SliceEffect;


    float CanCollide = 0.1f;
    float CanCollideBoss = 2f;
    int damage = 10;

    public bool canCollide = false;


    void FixedUpdate()
    {
        if(CanCollide >= 0)
        {
            CanCollide -= Time.deltaTime;
        }
        if (CanCollideBoss >= 0)
        {
            CanCollideBoss -= Time.deltaTime;
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (canCollide == false)
        {
            return;
        }

        if (CanCollideBoss < 0 & collision.gameObject.name == "Boss(Clone)")
        {
            EnemyHealth boss = collision.gameObject.GetComponent<EnemyHealth>();
            boss.TakeDamage(damage);
            //Instantiate(SliceEffect, collision.transform.position, Quaternion.identity);
            CanCollideBoss = 5f;
            return;
            
        }

        else if (CanCollide < 0 & collision.gameObject.tag == "Enemy")
        {
            EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
            enemy.TakeDamage(damage);
            //Instantiate(SliceEffect, collision.transform.position, Quaternion.identity);

            Debug.Log(this.gameObject.name);

            CanCollide = 0.1f;
            return;
        }
    }

}

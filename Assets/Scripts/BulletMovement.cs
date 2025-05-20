using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public GameObject bullet;
    Transform enemyposWhenInstatianted;
    public AudioSource bulletsfx;

    static float weaponLevel;


    //strength variables

    static int damage = 5;
    static int speed = 5;
    

    void Start()
    {

        if (FindClosestEnemy(bullet.transform) != null)
        {
            enemyposWhenInstatianted = FindClosestEnemy(bullet.transform);
            AddHomingToBullet(bullet, enemyposWhenInstatianted);
            //bulletsfx.Play();
        }
        else 
        { 
            Destroy(bullet);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
            enemy.TakeDamage(damage);

            Destroy(gameObject);
        }
    }

    public Transform FindClosestEnemy(Transform bullet)
    {
        Transform target = null;
        GameObject[] targetsList;

        targetsList = GameObject.FindGameObjectsWithTag("Enemy");
        float closestTarget = Mathf.Infinity;

        if (targetsList.Count() == 0)
        {
            target = null;
            return target;
        }
        else
        {
            foreach (GameObject enemy in targetsList)
            {

                float distance = 0;

                if(enemy.name == "Boss(Clone)")
                {
                    distance = (enemy.transform.position - bullet.transform.position).sqrMagnitude - (enemy.GetComponent<EnemyHealth>().GetHealth() / 100 );
                    Debug.Log("radau");
                }
                else
                {
                    distance = (enemy.transform.position - bullet.transform.position).sqrMagnitude;
                }

                if (distance < closestTarget)
                {
                    closestTarget = distance;
                    target = enemy.transform;
                }
            }
        }
        return target;
    }
    public void AddHomingToBullet(GameObject bullet, Transform enemypos)
    {
        Rigidbody2D bulletrb = bullet.GetComponent<Rigidbody2D>();
        bulletrb.velocity = bullet.transform.up * Time.deltaTime;

        

        if (enemypos != null)
        {
            Vector2 direction = (Vector2)enemypos.position - bulletrb.position;

            direction.Normalize();

            float rotationvalue = Vector3.Cross(direction, transform.up).z;
            bulletrb.angularVelocity = -rotationvalue * 10f;
            bulletrb.velocity = direction * speed;


        }
        else
        {
            Vector2 direction = (Vector2)bullet.transform.position;
            direction.Normalize();
            bulletrb.velocity = direction * speed;
        }
    }

    public void SetLevels(double level)
    {
        switch (level)
        {
            case 0:
                break;
            case 1:
                speed = 5;
                damage = 10;
                break;
            case 2:
                damage = 15;
                Shooting.BulletDelay = 0.75f;
                break;
            case 3:
                Shooting.BulletShootTimes = 1;
                speed = 7;
                break;
            case 4:
                speed = 10;
                Shooting.BulletDelay = 0.333f;
                break;
            case 5:
                Shooting.BulletShootTimes = 2;
                ///delete  down there
                speed = 10;
                Shooting.BulletDelay = 0.2f;
                break;
        }

        if(level > 5)
        {


            damage = 15 + ((int)level - 5) * 1;

            if (Shooting.BulletDelay > 0.05)
            {
                Shooting.BulletDelay = 0.25f - ((int)level - 5) * 0.05f;
            }
            
        }

        
    }
}

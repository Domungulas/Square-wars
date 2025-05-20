using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public GameObject rocket;

    public ParticleSystem RocketExplosion;
    public GameObject ExplosionRadius;
    public float speed;
    Rigidbody2D rocketrb;


    int[] speedsx = { 0, 1, 0, -1 };
    int[] speedsy = { 1, 0, -1, 0 };
    static int current = 0;

    int[] rotation = { 0, 270, 180, 90 };



    // Start is called before the first frame update
    void Start()
    {
        SetLevels(WeaponLevelManager.lvlRocket);
        rocketrb = GetComponent<Rigidbody2D>();
        rocketrb.velocity = new Vector3(speed * speedsx[current], speed * speedsy[current],0);
        rocket.transform.Rotate(0, 0, rotation[current]);
        current++;

        if (current == 4) 
        { 
            current = 0;
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
            EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
            Explode();
            Destroy(gameObject);
            enemy.TakeDamage(30);
        }   
    }
    private void Explode() 
    {
        //spawn explosion
        Instantiate(RocketExplosion, rocket.transform.position, Quaternion.identity);
        Instantiate(ExplosionRadius, rocket.transform.position, Quaternion.identity);
    }
    public void SetLevels(double level)
    {
        switch (level)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                GameObject.Find("Player").GetComponent<Shooting>().RocketDelay = 1f;
                break;
            case 4:
                
                break;
            case 5:
                
                break;
        }
    }
}

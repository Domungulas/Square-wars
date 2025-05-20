using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEngine.GraphicsBuffer;

public class Shooting : MonoBehaviour
{
    public static float BulletDelay = 1;
    float BulletShootDelay = 0;
    public static int BulletShootTimes = 0; // how many extra bullets to shoot

    public GameObject Bullet;

    public float RocketDelay = 1.5f;
    float RocketShootDelay = 0;

    public GameObject Rocket;


    double lvlPellet;
    double lvlRocket;
    double lvlShuriken;


    void Start()
    {
        lvlPellet = 1;
        lvlRocket = 0;
        lvlShuriken = 0;

        BulletDelay = 1;
        BulletShootTimes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        BulletShootDelay -= Time.deltaTime;
        RocketShootDelay -= Time.deltaTime;

        float inputx = Input.GetAxis("Horizontal");
        float inputy = Input.GetAxis("Vertical");

        if (BulletShootDelay <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                ShootBullet();


                StartCoroutine(ShootCopyBullets());

                BulletShootDelay = BulletDelay + BulletShootTimes * 0.1f;
            }
        }

        if (RocketShootDelay <= 0 & lvlRocket > 0) 
        {
            if (Input.GetButton("Fire1")) 
            { 
                GameObject PrefabRocket = Instantiate(Rocket, transform.position, Quaternion.identity);
                PrefabRocket.GetComponent<RocketMovement>().SetLevels(lvlRocket);
               // RocketShotFX.Play();

                RocketShootDelay = RocketDelay;
            }
        }

    }

    public void UpdateLevels(double pel,double roc,double shu)
    {
        lvlPellet = pel;
        lvlRocket = roc;
        lvlShuriken = shu;

        GameObject.Find("ShurikenController").GetComponent<ShurikenMovement>().SetLevels(lvlShuriken);

    }

    public void ShootBullet()
    {
        GameObject PrefabBullet = Instantiate(Bullet, transform.position, Quaternion.identity);
        PrefabBullet.GetComponent<BulletMovement>().SetLevels(lvlPellet);
    }

    IEnumerator ShootCopyBullets(float CopyShootDelay = 0.05f)
    {

        //if(BulletShootTimes > 0)
        //{
        //    yield return new WaitForSeconds(CopyShootDelay);
        //    GameObject PrefabBullet = Instantiate(Bullet, transform.position, Quaternion.identity);
        //    PrefabBullet.GetComponent<BulletMovement>().SetLevels(lvlPellet);
        //}

        //if (BulletShootTimes > 1)
        //{
        //    yield return new WaitForSeconds(CopyShootDelay);
        //    GameObject PrefabBullet = Instantiate(Bullet, transform.position, Quaternion.identity);
        //    PrefabBullet.GetComponent<BulletMovement>().SetLevels(lvlPellet);
        //}

        //if (BulletShootTimes > 2)
        //{
        //    yield return new WaitForSeconds(CopyShootDelay);
        //    GameObject PrefabBullet = Instantiate(Bullet, transform.position, Quaternion.identity);
        //    PrefabBullet.GetComponent<BulletMovement>().SetLevels(lvlPellet);
        //}

        //if (BulletShootTimes > 3)
        //{
        //    yield return new WaitForSeconds(CopyShootDelay);
        //    GameObject PrefabBullet = Instantiate(Bullet, transform.position, Quaternion.identity);
        //    PrefabBullet.GetComponent<BulletMovement>().SetLevels(lvlPellet);
        //}

        for(int i = 0; i < BulletShootTimes; i++)
        {
            yield return new WaitForSeconds(CopyShootDelay);
            GameObject PrefabBullet = Instantiate(Bullet, transform.position, Quaternion.identity);
            PrefabBullet.GetComponent<BulletMovement>().SetLevels(lvlPellet);
        }
    }

    
}

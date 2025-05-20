using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenMovement : MonoBehaviour
{
    
    GameObject Player;


    //public GameObject shu1;
    //public GameObject shu2;
    //public GameObject shu3;
    //public GameObject shu4;

    public List<GameObject> shur;

    float Timer = 0;


    //shuriken upgrades
    float SpinSpeed = 1f;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        SetLevels((int)WeaponLevelManager.lvlShuriken);
        //SetLevels(5);


    }

    // Update is called once per frame
    void Update()
    {
        Timer += SpinSpeed * Time.deltaTime;
        //Vector3 shurmovement = new Vector3(8 * MathF.Cos(Timer) + Player.transform.position.x, 6 * MathF.Sin(Timer) + Player.transform.position.y, 0);
        shur[0].transform.position = new Vector3(8 * MathF.Cos(Timer) + Player.transform.position.x, 6 * MathF.Sin(Timer) + Player.transform.position.y, 0);
        shur[2].transform.position = new Vector3(8 * MathF.Cos(Timer + (float)Math.PI/2) + Player.transform.position.x, 6 * MathF.Sin(Timer + (float)Math.PI / 2) + Player.transform.position.y, 0);
        shur[1].transform.position = new Vector3(8 * MathF.Cos(Timer + (float)Math.PI) + Player.transform.position.x, 6 * MathF.Sin(Timer + (float)Math.PI) + Player.transform.position.y, 0);
        shur[3].transform.position = new Vector3(8 * MathF.Cos(Timer + 1.5f *(float)Math.PI) + Player.transform.position.x, 6 * MathF.Sin(Timer + 1.5f * (float)Math.PI) + Player.transform.position.y, 0);

        //shu1.transform.Rotate(2 * new Vector3(0, 0, 1));
        //shu2.transform.Rotate(2 * new Vector3(0, 0, 1));
        //shu3.transform.Rotate(2 * new Vector3(0, 0, 1));
        //shu4.transform.Rotate(2 * new Vector3(0, 0, 1));

        for(int i = 0; i < shur.Count; i++)
        {
            shur[i].transform.Rotate(new Vector3(0, 0, 1));
        }
    }


    public void SetLevels(double level)
    {

        for (int i = 0; i < shur.Count; i++)
        {
            shur[i].GetComponent<SpriteRenderer>().enabled = i < level;
            shur[i].GetComponent<Collider2D>().enabled = i < level;
            shur[i].GetComponent<ShurikenColliding>().canCollide = i < level;

        }

        switch (level)
        {
            //case 0:
                //shu1.GetComponent<SpriteRenderer>().enabled = false;
                //shu2.GetComponent<SpriteRenderer>().enabled = false;
                //shu3.GetComponent<SpriteRenderer>().enabled = false;
                //shu4.GetComponent<SpriteRenderer>().enabled = false;

                //shu1.GetComponent<Collider2D>().enabled = false;
                //shu2.GetComponent<Collider2D>().enabled = false;
                //shu3.GetComponent<Collider2D>().enabled = false;
                ////shu4.GetComponent<Collider2D>().enabled = false;

                //for(int i = 0, i > 4; i++)
                //{
                //    shur[i].GetComponent<SpriteRenderer>().enabled = i ;
                //    shur[i].GetComponent<Collider2D>().enabled = false;

                //}

            //    break;
            //case 1:
            //    //shu1.GetComponent<SpriteRenderer>().enabled = true;
            //    //shu1.GetComponent<Collider2D>().enabled = true;
            //    break;
            //case 2:
            //    shu2.GetComponent<SpriteRenderer>().enabled = true;
            //    shu2.GetComponent<Collider2D>().enabled = true;
            //    break;
            //case 3:
            //    shu3.GetComponent<SpriteRenderer>().enabled = true;
            //    shu3.GetComponent<Collider2D>().enabled = true;
            //    break;
            //case 4:
            //    shu4.GetComponent<SpriteRenderer>().enabled = true;
            //    shu4.GetComponent<Collider2D>().enabled = true;
            //    break;
            case 5:
                SpinSpeed = 1.5f;
                break;
        }
    }
}

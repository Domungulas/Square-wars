using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ScreenShake : MonoBehaviour
{
    GameObject player;
    Image healthbargreen;
    Image healthbarred;


    Transform InitialTransform;

    float ShakeDuration = 50f;

    float ShakeMagnitude = 0.5f;

    float DampingSpeed = 1.0f;

    Vector3 initialPos;

    bool DoShake = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        InitialTransform = this.GetComponent<Transform>();

        //healthbargreen = GameObject.Find("HealthBarGreen").GetComponent<Image>();
        //healthbarred = GameObject.Find("HealthBarRed").GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);


        if (ShakeDuration > 0 & DoShake == true)
        {
            initialPos = InitialTransform.position;
            transform.position = initialPos + (Vector3)Random.insideUnitCircle * ShakeMagnitude;
            ShakeDuration -= Time.deltaTime * DampingSpeed;

         
            //healthbargreen.transform.position = initialPos + (Vector3)Random.insideUnitCircle * ShakeMagnitude;
            //healthbarred.transform.position = initialPos + (Vector3)Random.insideUnitCircle * ShakeMagnitude;

        }
        else
        {
            DoShake = false;
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);

            //healthbargreen.transform.position = initialPos;
            //healthbarred.transform.position = initialPos;

        }
    }

    public void DoTheHarlemShake(float shakeduration, float shakemagnitude)
    {
        ShakeDuration = shakeduration;
        ShakeMagnitude = shakemagnitude;

        DoShake = true;
    }

}

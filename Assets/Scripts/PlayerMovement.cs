using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 speed = new Vector2(5f,5f);
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        float inputx = Input.GetAxis("Horizontal");
        float inputy = Input.GetAxis("Vertical");

        
       Vector2 movement = new Vector2(speed.x * inputx, speed.y * inputy);

        rb.velocity = movement;

       //transform.Translate(movement);
    }

    

}

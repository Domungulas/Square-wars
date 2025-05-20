using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalking : MonoBehaviour
{
    GameObject Player;
    Rigidbody2D rb;

    public int DealtDamage = 10;
    public float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        //SetLevel(WeaponLevelManager.lvlGlobal);
    }

    // Update is called once per frame
    void Update()
    {
        //Rigidbody2D Enemyrb = GetComponent<Rigidbody2D>();
        rb.velocity = (Player.transform.position - gameObject.transform.position).normalized * speed;
        //transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, 0.01f);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
            health.TakeDamage(DealtDamage);
            
        }

    }

    private void SetLevel(float level)
    {
        DealtDamage = 5 * (int)level;
        speed = 1 * level;

    }
    
}

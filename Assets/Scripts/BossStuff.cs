using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossStuff : MonoBehaviour
{
    GameObject player;

    Rigidbody2D bossRB;
    SpriteRenderer BossSpriteRenderer;

    public Sprite NormalBossSprite;
    public Sprite RunawayBossSprite;

    #region 
    public float bossSpeed = 7;
    public int bossDamage = 10;
    public static bool runaway = false;
    #endregion

    void Start()
    {
        player = GameObject.Find("Player");
        bossRB = this.gameObject.GetComponent<Rigidbody2D>();
        BossSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveBoss();
        ChangeSprite();
    }

    private void MoveBoss()
    {
        //this makes the boss runaway

        if (runaway == true)
        {
            bossRB.velocity = -(player.transform.position - gameObject.transform.position).normalized * (bossSpeed + 1);
            Debug.Log((this.gameObject.transform.position - player.transform.position).sqrMagnitude);

            if ((this.gameObject.transform.position - player.transform.position).sqrMagnitude > 650)
            {
                GameObject.Find("Boss(Clone)").GetComponent<EnemyHealth>().health = EnemyHealth.BossRunawayHP + 300;
                GameObject.Find("Boss(Clone)").GetComponent<EnemyHealth>().UpdateScale();
                runaway = false;
            }
        }
        else
        {
            bossRB.velocity = (player.transform.position - gameObject.transform.position).normalized * bossSpeed;

        }
        
    }

    

    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
        health.TakeDamage(bossDamage);
    }

    public void ChangeSprite()
    {
        if (runaway)
        {
            BossSpriteRenderer.sprite = RunawayBossSprite;
        }

        else
        {
            BossSpriteRenderer.sprite = NormalBossSprite;
        }
    }

}

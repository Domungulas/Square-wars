using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    private float DissapearTime = 0.05f;

    ScreenShake Camera;


    Vector3 size = new Vector3(1,1,0);
    int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Main Camera").GetComponent<ScreenShake>();
        SetLevels(WeaponLevelManager.lvlRocket);
        this.gameObject.transform.localScale = size;
    }

    // Update is called once per frame  
    void Update()
    {
        DissapearTime -= Time.deltaTime;
        if (DissapearTime <= 0) 
        {
            Camera.DoTheHarlemShake(0.25f,0.05f);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemy = collision.GetComponent<EnemyHealth>();

        double weaponLevel = WeaponLevelManager.lvlRocket;

        SetLevels(weaponLevel);

        if (collision.gameObject.tag == "Enemy") 
        {
            enemy.TakeDamage(damage);
        }
    }

    public void SetLevels(double level)
    {
        switch (level)
        {
            case 0:
                break;
            case 1:
                size = new Vector3(5, 5, 0);
                break;
            case 2:
                size = new Vector3(5, 5, 0);
                break;
            case 3:
                size = new Vector3(7, 7, 0);
                break;
            case 4:
                size = new Vector3(8, 8, 0);
                damage = 30;
                break;
            case 5:
                size = new Vector3(13, 13, 0);
                break;
        }
    }
}

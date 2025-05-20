using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyTimer : MonoBehaviour
{

    public double TimerForDestroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimerForDestroy -= Time.deltaTime;

        if(TimerForDestroy <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
